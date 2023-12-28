using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.SearchingFilter.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.SearchingFilter
{
    public class SearchingFilterAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<Room> _room;
        private readonly IRepository<HotelCategory> _hotelCategory;
        private readonly IRepository<HotelImg> _hotelImg;
        private readonly IRepository<Location> _location;
        private readonly IRepository<HotelUnit> _hotelUnit;
        private readonly IRepository<RoomCategory> _roomCategory;
        private readonly IRepository<RoomService> _hotelService;
        private readonly IRepository<BookingDetail> _bookingDetail;
        private readonly IRepository<FeedbackVote> _feedbackVote;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SearchingFilterAppService(IRepository<Room> phong,
            IRepository<HotelCategory> hinhThuc, IRepository<HotelImg> hinhAnh,
            IRepository<Location> diaDiem, IRepository<RoomCategory> loaiPhong,
            IRepository<RoomService> dichvu,
            IRepository<BookingDetail> bookingDetail,
            IRepository<FeedbackVote> nhanXet,
            IHttpContextAccessor httpContextAccessor, IRepository<HotelUnit> donViKinhDoanh)
        {
            _room = phong;
            _hotelCategory = hinhThuc;
            _hotelImg = hinhAnh;
            _location = diaDiem;
            _roomCategory = loaiPhong;
            _hotelService = dichvu;
            _httpContextAccessor = httpContextAccessor;
            _hotelUnit = donViKinhDoanh;
            _bookingDetail = bookingDetail;
            _feedbackVote = nhanXet;
        }

        public async Task<List<RoomSearchingFilterDto>> SearchingRoom(InfoBookingDto input)
        {
            try
            {

               /* await _httpContextAccessor.HttpContext.Session.SetObjectAsync("infoBooking", input);*/

                var lstP = await _room.GetAllListAsync();
                var lstDVKD = await _hotelUnit.GetAllListAsync();

                var dvkds = lstDVKD.Where(p => p.LocationId == input.LocationId).ToList();

                var dtoList = new List<RoomSearchingFilterDto>();

                foreach (var item in dvkds)
                {
                    var phongs = lstP.Where(p => p.HotelUnitId == item.Id).ToList();

                    if (phongs == null || !phongs.Any())
                    {
                        await _httpContextAccessor.HttpContext.Response.WriteAsync($"Không tìm thấy phòng thuộc địa điểm có id = {input.LocationId}");
                        return null;
                    }
                    else
                    {
                        var hinhAnh = await _hotelImg.GetAllListAsync();
                        var dichVu = await _hotelService.GetAllListAsync();
                        var loaiPhong = await _roomCategory.GetAllListAsync();
                        var chiTiet = await _bookingDetail.GetAllListAsync();
                        var nhanXet = await _feedbackVote.GetAllListAsync();

                        foreach (var i in phongs)
                        {
                            var diaDiem = await _location.FirstOrDefaultAsync(p => p.Id == input.LocationId);
                            var hotelCategory = await _hotelCategory.FirstOrDefaultAsync(p => p.Id == i.HotelCategoryId);

                            var dtoP = new RoomSearchingFilterDto
                            {
                                HotelUnitId = item.Id,
                                UnitName = item.UnitName,
                                RoomId = i.Id,
                                RoomAvatarFileName = i.RoomAvatarFileName,
                                LocationDetail = item.LocationDetail,

                                BookingCount = i.BookingCount,
                                AverageVotePoint = i.AverageVotePoint,
                                AverageVoteStar = i.AverageVoteStar,

                                HotelCategoryId = hotelCategory.Id,
                                HotelCategory = hotelCategory.HotelCategoryName,
                                LowestRoomPrice = loaiPhong.Where(p => p.HotelUnitId == i.HotelUnitId).Select(q => q.PricePerNight).Min(),
                                ListRoomCategory = loaiPhong.Where(p => p.HotelUnitId == i.HotelUnitId).Select(e => new RoomCategorySearchingFilterDto
                                {
                                    RoomCategoryId = e.Id,
                                    PricePerNight = e.PricePerNight,
                                    Discount = e.Discount,
                                    RoomAvatar = e.RoomAvatar

                                }).ToList(),
                            };

                            dtoList.Add(dtoP);
                        }
                    }
                }
                dtoList = dtoList.OrderByDescending(q => q.BookingCount).ToList();

                /*await _httpContextAccessor.HttpContext.Session.SetObjectAsync("lstRoom", dtoList);*/

                return dtoList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost()]
        public async Task<List<RoomSearchingFilterDto>> GetRoomsByLocationAndFilter(SearchingFilterRoomInputDto input)
        {
            try
                {

                /* var dtoList = await _httpContextAccessor.HttpContext.Session.GetObjectAsync<List<PhongSearchinhFilterDto>>("lstRoom");*/

                var dtoList = input.lst;
                //Filter then sort
                if (input.FreeCancel == true)
                {

                    var lstItem1 = new List<RoomSearchingFilterDto>();

                    var lstItem = new List<RoomSearchingFilterDto>();

                    var filteredRooms = dtoList.Where(p => p.ListRoomCategory.Select(q => q.FreeCancel).ToString().ToLower() == "true").ToList();

                    if (input.LowestRoomPrice <= 0 && input.HighestRoomPrice <= 0 && !input.StarVote.Any() && !input.HotelCategoryId.Any())
                    {
                        lstItem = filteredRooms;
                    }
                    else
                    {
                        if (input.LowestRoomPrice >= 0 )
                        {
                            if(input.HighestRoomPrice != 0 && input.HighestRoomPrice >= input.LowestRoomPrice)
                            {
                                filteredRooms = filteredRooms.Where(room =>
                                                           (input.LowestRoomPrice <= room.LowestRoomPrice &&
                                                           room.LowestRoomPrice <= input.HighestRoomPrice)
                                                       ).ToList();

                            }
                            else
                            {
                                await _httpContextAccessor.HttpContext.Response.WriteAsync("gia phong nhap sai");
                                return null;
                            }
                        }
                        else
                        {
                            await _httpContextAccessor.HttpContext.Response.WriteAsync("gia phong trong");
                            return null;
                        }
                        
                        if (input.StarVote.Any())
                        {
                            foreach (var e in input.StarVote)
                            {
                                var item = filteredRooms.Where(room => room.AverageVoteStar == e).ToList();
                                lstItem1.AddRange(item);
                            }
                            if (input.HotelCategoryId.Any())
                            {
                                foreach (var i in input.HotelCategoryId)
                                {
                                    var item = lstItem1.Where(room => room.HotelCategoryId == i).ToList();

                                    lstItem.AddRange(item);
                                }
                            }
                            else
                            {
                                lstItem = lstItem1;
                            }
                        }
                        else
                        {
                            if (input.HotelCategoryId.Any())
                            {
                                foreach (var i in input.HotelCategoryId)
                                {
                                    var item = filteredRooms.Where(room => room.HotelCategoryId == i).ToList();

                                    lstItem.AddRange(item);
                                }
                            }
                            else
                            {
                                lstItem = filteredRooms;
                            }
                        }
                    }


                    if (input.SortCondition == 1)
                    {
                        lstItem = lstItem.OrderByDescending(q => q.LowestRoomPrice).ToList();
                    }
                    else if (input.SortCondition == 2)
                    {
                        lstItem = lstItem.OrderBy(q => q.LowestRoomPrice).ToList();
                    }
                    else if (input.SortCondition == 3)
                    {
                        lstItem = lstItem.OrderByDescending(q => q.AverageVotePoint).ToList();
                    }
                    else
                    {
                        lstItem = lstItem.OrderByDescending(q => q.BookingCount).ToList();
                    }

                    /*var totalCount = lstItem.Count;

                    var pagedRooms = lstItem
                        .Skip((input.pageIndex - 1) * input.pageSize)
                        .Take(input.pageSize)
                        .ToList();

                    return new PagedResultDto<PhongSearchinhFilterDto>(totalCount, pagedRooms);*/
                    return lstItem;
                }
                else
                {
                    var lstItem1 = new List<RoomSearchingFilterDto>();

                    var lstItem = new List<RoomSearchingFilterDto>();

                    var filteredRooms = dtoList;

                    if (input.LowestRoomPrice <= 0 && input.HighestRoomPrice <= 0 && !input.StarVote.Any() && !input.HotelCategoryId.Any())
                    {
                        lstItem = filteredRooms;
                    }
                    else
                    {
                        if (input.LowestRoomPrice >= 0)
                        {
                            if (input.HighestRoomPrice!=0 && input.HighestRoomPrice >= input.LowestRoomPrice)
                            {
                                filteredRooms = filteredRooms.Where(room =>
                                                           (input.LowestRoomPrice <= room.LowestRoomPrice &&
                                                           room.LowestRoomPrice <= input.HighestRoomPrice)
                                                       ).ToList();

                            }
                            else
                            {
                                await _httpContextAccessor.HttpContext.Response.WriteAsync("gia phong nhap sai");
                                return null;
                            }
                        }
                        else
                        {
                            await _httpContextAccessor.HttpContext.Response.WriteAsync("gia phong trong");
                            return null;
                        }

                        if (input.StarVote.Any())
                        {
                            foreach (var e in input.StarVote)
                            {
                                var item = filteredRooms.Where(room => room.AverageVoteStar == e).ToList();
                                lstItem1.AddRange(item);
                            }
                            if (input.HotelCategoryId.Any())
                            {
                                foreach (var i in input.HotelCategoryId)
                                {
                                    var item = lstItem1.Where(room => room.HotelCategoryId == i).ToList();

                                    lstItem.AddRange(item);
                                }
                            }
                            else
                            {
                                lstItem = lstItem1;
                            }
                        }
                        else
                        {
                            if (input.HotelCategoryId.Any())
                            {
                                foreach (var i in input.HotelCategoryId)
                                {
                                    var item = filteredRooms.Where(room => room.HotelCategoryId == i).ToList();

                                    lstItem.AddRange(item);
                                }
                            }
                            else
                            {
                                lstItem = filteredRooms;
                            }
                        }
                    }

                    if (input.SortCondition == 1)
                    {
                        lstItem = lstItem.OrderByDescending(q => q.LowestRoomPrice).ToList();
                    }
                    else if (input.SortCondition == 2)
                    {
                        lstItem = lstItem.OrderBy(q => q.LowestRoomPrice).ToList();
                    }
                    else if (input.SortCondition == 3)
                    {
                        lstItem = lstItem.OrderByDescending(q => q.AverageVotePoint).ToList();
                    }
                    else
                    {
                        lstItem = lstItem.OrderByDescending(q => q.BookingCount).ToList();
                    }

                    /* var totalCount = lstItem.Count;

                     var pagedRooms = lstItem
                         .Skip((input.pageIndex - 1) * input.pageSize)
                         .Take(input.pageSize)
                         .ToList();

                     return new PagedResultDto<PhongSearchinhFilterDto>(totalCount, pagedRooms);*/
                    return lstItem;

                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
