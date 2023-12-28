using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.RoomCategorys.Dto;
using BookingWebsite.Modules.SearchingFilter.Dto;
using BookingWebsite.Module.HotelCategorys.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Module.HotelCategorys
{
    public class RoomCategoryAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<HotelCategory> _hotelCategory;
        private readonly IRepository<Room> _room;
        private readonly IRepository<HotelImg> _hotelImg;
        private readonly IRepository<HotelUnit> _hotelUnit;
        private readonly IRepository<RoomCategory> _roomCategory;
        private readonly IRepository<RoomService> _roomService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomCategoryAppService(IRepository<HotelCategory> hotelCategory,
            IRepository<Room> room, IRepository<HotelImg> hotelImg,
            IRepository<HotelUnit> hotelUnit,
            IRepository<RoomCategory> roomCategory,
            IRepository<RoomService> roomService,
            IHttpContextAccessor httpContextAccessor)
        {
            _hotelCategory = hotelCategory;
            _room = room;
            _hotelImg = hotelImg;
            _hotelUnit = hotelUnit;
            _roomCategory = roomCategory;
            _roomService = roomService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<RoomSearchingFilterDto>> GetRoomByForm(int id)
        {
            try
            {
                var lstHtp = await _hotelCategory.GetAllListAsync();
                var lstPhong = await _room.GetAllListAsync();
                var lstDvkd = await _hotelUnit.GetAllListAsync();
                var lstLp = await _roomCategory.GetAllListAsync();
                var lstDv = await _roomService.GetAllListAsync();
                var lstha = await _hotelImg.GetAllListAsync();

                var lstP = lstPhong.Where(p => p.HotelCategoryId == id).ToList();

                var dtoLstP = lstP.Select(e => new RoomSearchingFilterDto
                {
                    HotelUnitId = e.HotelUnitId,
                    UnitName = _hotelUnit.FirstOrDefault(p => p.Id == e.HotelUnitId).UnitName,
                    RoomId = e.Id,
                    RoomAvatarFileName = e.RoomAvatarFileName,
                    LocationDetail = _hotelUnit.FirstOrDefault(p => p.Id == e.HotelUnitId).LocationDetail,

                    BookingCount = e.BookingCount,
                    AverageVotePoint = e.AverageVotePoint,
                    AverageVoteStar = e.AverageVoteStar,

                    HotelCategoryId = id,
                    HotelCategory = _hotelCategory.FirstOrDefault(p => p.Id == e.HotelCategoryId).HotelCategoryName,
                    LowestRoomPrice = lstLp.Where(p => p.HotelUnitId == e.HotelUnitId).Select(q => q.PricePerNight).Min(),
                    ListRoomCategory = lstLp.Where(p => p.HotelUnitId == e.HotelUnitId).Select(x => new RoomCategorySearchingFilterDto
                    {
                        RoomCategoryId = x.Id,
                        PricePerNight = x.PricePerNight,
                        Discount = x.Discount

                    }).ToList(),

                }).ToList();
                return dtoLstP;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"erorr : {ex.Message}");
                return null;
            }

        }

        public async Task<List<HotelCategoryFullDto>> GetAllForms()
        {
            try
            {
                var lst = await _hotelCategory.GetAllListAsync();

                var dtoList = lst.Select(entity => new HotelCategoryFullDto
                {
                    Id = entity.Id,
                    HotelCategoryName = entity.HotelCategoryName,
                    HotelAvatar = entity.HotelAvatar
                }).ToList();

                return dtoList;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"erorr : {ex.Message}");
                return null;
            }

        }


        public async Task<bool> AddNewForm(HotelCategoryDto input)
        {
            try
            {
                var htkd = new HotelCategory
                {
                    HotelCategoryName = input.HotelCategoryName,
                    HotelAvatar = input.HotelAvatar
                };

                await _hotelCategory.InsertAsync(htkd);

                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateForm(HotelCategoryFullDto input)
        {
            try
            {
                var item = await _hotelCategory.FirstOrDefaultAsync(p => p.Id == input.Id);
                if (item == null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay loai phong voi id = {input.Id}");
                    return false;
                }

                item.HotelCategoryName = input.HotelCategoryName;
                item.HotelAvatar = input.HotelAvatar;

                await _hotelCategory.UpdateAsync(item);
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteForm(int id)
        {
            try
            {
                var checkHt = await _hotelCategory.FirstOrDefaultAsync(p => p.Id == id);
                if (checkHt == null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay loai phong voi id = {id}");
                    return false;
                }
                else
                {
                    var room = await _room.GetAllListAsync();
                    var checkPhong = room.Where(p => p.HotelCategoryId == checkHt.Id).ToList();

                    if (checkPhong.Any())
                    {
                        foreach (var i in checkPhong)
                        {
                            i.HotelCategoryId = null;
                        }
                    }

                    await _hotelCategory.DeleteAsync(checkHt);
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa hinh thuc kinh doanh {checkHt}");
                    return true;
                }

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

    }
}
