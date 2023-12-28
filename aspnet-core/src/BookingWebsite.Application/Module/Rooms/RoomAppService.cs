using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.Phongs.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWebsite.Authorization.Users;
using BookingWebsite.Modules.BookingPolicys.Dto;
using BookingWebsite.Modules.HotelServices.Dto;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using BookingWebsite.Modules.Rooms.Dto;

namespace BookingWebsite.Modules.Phongs
{
    public class RoomAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<Room> _room;
        private readonly IRepository<HotelCategory> _hotelCategory;
        private readonly IRepository<HotelUnit> _hotelUnit;
        private readonly IRepository<HotelImg> _hotelImg;
        private readonly IRepository<Location> _location;
        private readonly IRepository<RoomCategory> _roomCategory;
        private readonly IRepository<RoomService> _roomService;
        private readonly IRepository<FeedbackVote> _feedback;
        private readonly IRepository<BookingDetail>  _bookingDetail;
        private readonly IRepository<BookingForm> _phieuDatPhong;
        private readonly IRepository<BookingPolicy> _bookingPolicy;
        private readonly IRepository<HotelService> _hotelService;


        private readonly UserManager _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomAppService(IRepository<Room> room, IRepository<HotelCategory> hotelCategory,
            IRepository<HotelImg> hotelImg, IRepository<Location> location,
            IRepository<RoomCategory> roomCategory, IRepository<RoomService> roomService,
            IRepository<FeedbackVote> feedbackVote, IRepository<BookingDetail> bookingDetail,
            IRepository<Customer> customer, IRepository<BookingForm> phieuDatPhong,
             UserManager userManager,
            IRepository<BookingPolicy> bookingPolicy, IRepository<HotelService> hotelService,
            IHttpContextAccessor httpContextAccessor, IRepository<HotelUnit> hotelUnit)
        {
            _room = room;
            _hotelCategory = hotelCategory;
            _hotelImg = hotelImg;
            _location = location;
            _roomCategory = roomCategory;
            _hotelService = hotelService;
            _feedback = feedbackVote;
            _bookingDetail = bookingDetail;
            _httpContextAccessor = httpContextAccessor;
            _hotelUnit = hotelUnit;
            _phieuDatPhong = phieuDatPhong;
            _userManager = userManager;
            _bookingPolicy = bookingPolicy;
            _roomService = roomService;
        }

        public async Task<GetRoomInfoDto> GetRoomById(int Id)
        {
            try
            {
                var room = await _room.FirstOrDefaultAsync(p=>p.Id == Id);
                if(room == null)
                {
                    throw new Exception("Phong khong ton tai");
                }
                else
                {
                    var lstHt = await _hotelCategory.FirstOrDefaultAsync(p => p.Id == room.HotelCategoryId);

                    var lstDvkd = await _hotelUnit.FirstOrDefaultAsync(p => p.Id == room.HotelUnitId);

                    var lstDd = await _location.FirstOrDefaultAsync(p => p.Id == lstDvkd.LocationId);

                    //var lp = await _roomCategory.GetAllListAsync();
                    //var lstLp = lp.Where(p => p.HotelUnitId == lstDvkd.Id).ToList(); CODE hoi dai

                    var listRoomCategory = await this._roomCategory.GetAll().Where(e => e.HotelUnitId == lstDvkd.Id).ToListAsync();
                    //var lstLpIds = lp.Select(p => p.Id).ToList();
                    var lstLpIds = await this._roomCategory.GetAll().Select(e => e.Id).ToListAsync();

                    var dv = await _roomService.GetAllListAsync();

                    var anh = await _hotelImg.GetAllListAsync();
                    var lstA = anh.Where(p => p.RoomId == room.Id).ToList();

                    var ct = await _bookingDetail.GetAllListAsync();
                    var lstCt = ct.Where(p => p.RoomId == room.Id).ToList();
                    var lstCtIds = lstCt.Select(p => p.Id).ToList();

                    var lstNx = await _feedback.GetAllListAsync();

                    var lstDvc = await _hotelService.GetAllListAsync();
                    var Dvc = lstDvc.Where(p=>p.HotelUnitId == room.HotelUnitId).ToList();

                    var lstCsc = await _bookingPolicy.GetAllListAsync();
                    var Csc = lstCsc.Where(p => p.HotelUnitId == room.HotelUnitId).ToList();

                    var dtoLst = new GetRoomInfoDto
                    {
                        LocationId = lstDd.Id,
                        LocationName = lstDd.LocationName,
                        LocationInfor = lstDd.LocationInfor,

                        HotelUnitId = lstDvkd.Id,
                        UnitName = lstDvkd.UnitName,
                        LocationDetail = lstDvkd.LocationDetail,

                        HotelCategoryId = lstHt.Id,
                        HotelCategory = lstHt.HotelCategoryName,

                        RoomId = room.Id,
                        Describe = room.Describe,
                        RoomAvatarFileName = room.RoomAvatarFileName,

                        BookingCount = room.BookingCount,
                        AverageVotePoint = room.AverageVotePoint,
                        AverageVoteStar =room.AverageVoteStar,
                        /*lstNx.Where(p => lstCtIds.Contains(p.DetailDatRoomId)).Select(p => p.StarVote).ToList().Sum() / lstNx.Where(p => lstCtIds.Contains(p.DetailDatRoomId)).Select(p => p.StarVote).ToList().Count(),*/
                        ListRoomCategory = listRoomCategory.Select(e => new RoomCategorySearchingDto
                        {
                            RoomCatergoryId = e.Id,
                            RoomCategory = e.RoomCategoryName,
                            Capacity = e.Capacity,
                            TotalRoomCount = e.TotalRoomCount,
                            EmptyRoomCount = e.EmptyRoomCount,
                            FreeCancelBook = e.FreeCancelBook,
                            PricePerNight = e.PricePerNight,
                            Discount=e.Discount,
                            SpecialDiscount = e.SpecialDiscount,
                            ServiceExtendPrice = e.PricePerNight,
                            RoomAvatar = e.RoomAvatar,
                            Service = dv.Where(p => p.RoomCategoryId == e.Id).Select(q => new ServiceSearchingDto
                            {
                                ServiceId = q.Id,
                                ServiceName = q.ServiceName,
                                Describe = q.Describe,
                            }).ToList(),
                        }).ToList(),

                        BookingPolicy = Csc.Select(e=> new BookingPolicyDto
                        {
                            Id = e.Id,
                            CheckInfor = e.CheckInfor,
                            Breakfast = e.Breakfast,
                            Checkin = e.Checkin,
                            Checkout = e.Checkout,
                            RoomPolicy=e.RoomPolicy,
                            ChildrenPolicy = e.ChildrenPolicy,
                            SubBedPolicy = e.SubBedPolicy,
                            PetPolicy = e.PetPolicy,
                            PaymentMethod = e.PaymentMethod
                        }).ToList(),

                        HotelService = Dvc.Select(e => new HotelServiceDto{
                            Id = e.Id,
                            ServiceName=e.ServiceName,
                            Detail = e.Detail
                        }).ToList(),

                        HinhAnh = lstA.Select(p => p.ImgFileName).ToList()
                    };
                    return dtoLst;
                }
                
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<GetRoomInfoDto>> GetRoomsByLocationId(int locationId)
        {
            try
            {
                var lstP = await _room.GetAllListAsync();
                var lstDVKD = await _hotelUnit.GetAllListAsync();

                var dvkds = lstDVKD.Where(p => p.LocationId == locationId).ToList();

                var dtoList = new List<GetRoomInfoDto>();

                var hotelImg = await _hotelImg.GetAllListAsync();
                var roomService = await _roomService.GetAllListAsync();
                var roomCategory = await _roomCategory.GetAllListAsync();
                var bookingDetail = await _bookingDetail.GetAllListAsync();
                var feedback = await _feedback.GetAllListAsync();
                var hotelService = await _hotelService.GetAllListAsync();
                var bookingPolicy = await _bookingPolicy.GetAllListAsync();

                foreach (var item in dvkds)
                {
                    var rooms = lstP.Where(p => p.HotelUnitId == item.Id).ToList();

                    if (rooms == null || !rooms.Any())
                    {
                        await _httpContextAccessor.HttpContext.Response.WriteAsync($"Không tìm thấy phòng thuộc địa điểm có id = {locationId}");
                        return null;
                    }
                    else
                    {
                        foreach (var i in rooms)
                        {
                            var location = await _location.FirstOrDefaultAsync(p => p.Id == locationId);
                            var hotelCategory = await _hotelCategory.FirstOrDefaultAsync(p => p.Id == i.HotelCategoryId);

                            var dtoP = new GetRoomInfoDto
                            {
                                LocationId = location.Id,
                                LocationName = location.LocationName,
                                LocationInfor = location.LocationInfor,

                                HotelUnitId = item.Id,
                                UnitName = item.UnitName,
                                LocationDetail = item.LocationDetail,

                                HotelCategory = hotelCategory?.HotelCategoryName,
                                HotelCategoryId = hotelCategory.Id,

                                RoomId = i.Id,
                                Describe = i.Describe,
                                RoomAvatarFileName = i.RoomAvatarFileName,

                                BookingCount = i.BookingCount,
                                AverageVoteStar = i.AverageVoteStar,
                                AverageVotePoint = i.AverageVotePoint,

                                ListRoomCategory = roomCategory.Where(p => p.HotelUnitId == i.HotelUnitId).Select(e => new RoomCategorySearchingDto
                                {
                                    RoomCatergoryId = e.Id,
                                    RoomCategory = e.RoomCategoryName,
                                    Capacity = e.Capacity,
                                    TotalRoomCount = e.TotalRoomCount,
                                    EmptyRoomCount = e.EmptyRoomCount,
                                    FreeCancelBook = e.FreeCancelBook,
                                    PricePerNight = e.PricePerNight,
                                    ServiceExtendPrice = e.ServiceExtendPrice,
                                    RoomAvatar = e.RoomAvatar,
                                    Service = roomService.Where(p => p.RoomCategoryId == e.Id).Select(q => new ServiceSearchingDto
                                    {
                                        ServiceId = q.Id,
                                        ServiceName = q.ServiceName,
                                        Describe = q.Describe

                                    }).ToList()
                                }).ToList(),

                                BookingPolicy = bookingPolicy.Where(p=>p.HotelUnitId == i.HotelUnitId).Select(e=> new BookingPolicyDto
                                {
                                    Id = e.Id,
                                    CheckInfor = e.CheckInfor,
                                    Breakfast = e.Breakfast,
                                    Checkin = e.Checkin,
                                    Checkout = e.Checkout,
                                    RoomPolicy = e.RoomPolicy,
                                    ChildrenPolicy = e.ChildrenPolicy,
                                    SubBedPolicy = e.SubBedPolicy,
                                    PetPolicy = e.PetPolicy,
                                    PaymentMethod = e.PaymentMethod
                                }).ToList(),

                                HotelService = hotelService.Where(p=>p.HotelUnitId == i.HotelUnitId).Select(e => new HotelServiceDto
                                {
                                    Id = e.Id,
                                    ServiceName = e.ServiceName,
                                    Detail = e.Detail
                                }).ToList(),

                                HinhAnh = hotelImg.Where(p => p.RoomId == i.Id).Select(p => p.ImgFileName).ToList(),
                            };

                            dtoList.Add(dtoP);
                        }
                    }
                }
                return dtoList;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"Error: {ex.Message}");
                return null;
            }
        }


        public async Task<List<GetRoomInfoDto>> GetAllRoom()
        {
            try
            {
                var lstP = await _room.GetAllListAsync();
                var dv = await _roomService.GetAllListAsync();
                var lp = await _roomCategory.GetAllListAsync();
                var anh = await _hotelImg.GetAllListAsync();
                var lstNx = await _feedback.GetAllListAsync();
                var dvc = await _hotelService.GetAllListAsync();
                var csc = await _bookingPolicy.GetAllListAsync();

                var dtoLst = new List<GetRoomInfoDto>();

                foreach (var i in lstP)
                {
                    var lstHt = await _hotelCategory.FirstOrDefaultAsync(p => p.Id == i.HotelCategoryId);

                    var lstDvkd = await _hotelUnit.FirstOrDefaultAsync(p => p.Id == i.HotelUnitId);

                    var lstDd = await _location.FirstOrDefaultAsync(p => p.Id == lstDvkd.LocationId);

                    var dto = new GetRoomInfoDto
                    {
                        LocationId = lstDd.Id,
                        LocationName = lstDd.LocationName,
                        LocationInfor = lstDd.LocationInfor,

                        HotelUnitId = lstDvkd.Id,
                        UnitName = lstDvkd.UnitName,
                        LocationDetail = lstDvkd.LocationDetail,

                        HotelCategoryId = lstHt.Id,
                        HotelCategory = lstHt.HotelCategoryName,

                        RoomId = i.Id,
                        Describe = i.Describe,
                        RoomAvatarFileName = i.RoomAvatarFileName,

                        BookingCount = i.BookingCount,
                        AverageVotePoint = i.AverageVotePoint,
                        AverageVoteStar = i.AverageVoteStar,

                        ListRoomCategory = lp.Where(p => p.HotelUnitId == lstDvkd.Id).Select(e => new RoomCategorySearchingDto
                        {
                            RoomCatergoryId = e.Id,
                            RoomCategory = e.RoomCategoryName,
                            Capacity =e.Capacity,
                            TotalRoomCount = e.TotalRoomCount,
                            EmptyRoomCount = e.EmptyRoomCount,
                            FreeCancelBook = e.FreeCancelBook,
                            PricePerNight = e.PricePerNight,
                            ServiceExtendPrice = e.ServiceExtendPrice,
                            RoomAvatar = e.RoomAvatar,

                            Service = dv.Where(p => p.RoomCategoryId == e.Id).Select(q => new ServiceSearchingDto
                            {
                                ServiceId = q.Id,
                                ServiceName = q.ServiceName,
                                Describe = q.Describe

                            }).ToList(),

                        }).ToList(),

                        BookingPolicy = csc.Where(p => p.HotelUnitId == i.HotelUnitId).Select(e => new BookingPolicyDto
                        {
                            Id = e.Id,
                            CheckInfor = e.CheckInfor,
                            Breakfast = e.Breakfast,
                            Checkin = e.Checkin,
                            Checkout = e.Checkout,
                            RoomPolicy = e.RoomPolicy,
                            ChildrenPolicy = e.ChildrenPolicy,
                            SubBedPolicy = e.SubBedPolicy,
                            PetPolicy = e.PetPolicy,
                            PaymentMethod = e.PaymentMethod
                        }).ToList(),

                        HotelService = dvc.Where(p => p.HotelUnitId == i.HotelUnitId).Select(e => new HotelServiceDto
                        {
                            Id = e.Id,
                            ServiceName = e.ServiceName,
                            Detail = e.Detail
                        }).ToList(),

                        HinhAnh = anh.Where(p => p.RoomId == i.Id).Select(p => p.ImgFileName).ToList()
                    };

                    dtoLst.Add(dto);
                }

                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }


        public async Task<bool> AddNewRoom(RoomDto input)
        {
            try
            {
                var lp = new Room
                {
                    Describe = input.Describe,
                    RoomAvatarFileName = input.AvatarFileName,
                    HotelUnitId = input.HotelUnitId,
                    HotelCategoryId = input.RoomCategoryId,

                };
                await _room.InsertAsync(lp);
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }

        }


        public async Task<bool> UpdateRoom(RoomInputDto input)
        {
            try
            {
                var checkP = await _room.FirstOrDefaultAsync(p => p.Id == input.Id);

                if (checkP != null)
                {
                    if (input.Describe != null)
                    {
                        checkP.Describe = input.Describe;
                    }

                    if (input.RoomAvatarFileName != null)
                    {
                        checkP.RoomAvatarFileName = input.RoomAvatarFileName;
                    }
                    if (input.RoomCategoryId != null)
                    {
                        checkP.HotelCategoryId = input.RoomCategoryId;
                    }

                    await _room.UpdateAsync(checkP);
                    return true;
                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong ton tai loai room voi id = {input.Id}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }



        public async Task<bool> DeleteRoom(int id)
        {
            try
            {
                var checkP = await _room.FirstOrDefaultAsync(p=>p.Id == id);

                if (checkP != null)
                {
                    var hotelImg = await _hotelImg.GetAllListAsync();
                    var checkHa = hotelImg.Where(p => p.RoomId == checkP.Id).ToList();
                    if (checkHa.Any())
                    {
                        foreach (var i in checkHa)
                        {
                            await _hotelImg.DeleteAsync(i);
                            await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa hinh anh {i}");
                        }
                    }

                    var bookingDetail = await _bookingDetail.GetAllListAsync();
                    var checkCtdp = bookingDetail.Where(p=>p.RoomId == checkP.Id).ToList();
                    if(checkCtdp.Any())
                    {
                        var feedback = await _feedback.GetAllListAsync();
                        foreach (var i in checkCtdp)
                        {
                            var checkNx = feedback.Where(p=>p.BookingDetailId == i.Id).ToList();
                            if (checkNx.Any())
                            {
                                foreach(var j in checkNx)
                                {
                                    await _feedback.DeleteAsync(j);
                                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa nhan xet {j}");

                                }
                            }
                            await _bookingDetail.DeleteAsync(i);
                            await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa chi tiet dat room {i}");
                        }
                    }

                    await _room.DeleteAsync(checkP);
                    return true;
                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong ton tai room voi id = {id}");
                    return false;
                }


            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }

        }


        public async Task<GetRoomInforToBookOutputDto> GetInfoRoomToBook(int roomCategoryId)
        {
            try
            {
                /*var infoRoom = await _httpContextAccessor.HttpContext.Session.GetObjectAsync<InfoBookingDto>("InfoBooking");*/

                var info = await _roomCategory.FirstOrDefaultAsync(p=>p.Id ==  roomCategoryId);

                var dvkd = await _hotelUnit.FirstOrDefaultAsync(p => p.Id == info.HotelUnitId);

                var room = await _room.FirstOrDefaultAsync(p => p.HotelUnitId == dvkd.Id);

                var dto = new GetRoomInforToBookOutputDto
                {
                    hotelUnitId = dvkd.Id,
                    unitName = dvkd.UnitName,
                    roomId = room.Id,
                    roomCategoryId = info.Id,
                    RoomCategoryName = info.RoomCategoryName,
                    roomCapacity =info.Capacity,
                    roomDescibe = info.Describe,
                    roomCategoryService = info.RoomCategoryService,
                    pricePerNight = info.PricePerNight,
                    serviceExtendPrice = info.ServiceExtendPrice,
                    discount = info.Discount,
                    specialDiscount = info.Discount,
                    freeCancelBook = info.FreeCancelBook,
                    tenFIleAnh=info.RoomAvatar
                    
                };
                return dto;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }


        public async Task<ClientBookRoomOutputDto> ClientBookRoom(ClientBookRoomInputDto input)
        {
            try
            {
                /*
                var infoRoom = await GetInfoRoomToBook(input.roomCategoryId);*/

                
                var infoBookingCofirm = new ClientBookRoomOutputDto
                {
                    BookingOnBehalf = input.BookingOnBehalf,
                    FullName = input.FullName,
                    IdCardNumber = input.IdCardNumber,
                    PhoneNumber = input.PhoneNumber,
                    Email = input.Email,
                    SpecialRequest = input.SpecialRequest
                };

/*
                await _httpContextAccessor.HttpContext.Session.SetObjectAsync("infoBookingConFirm", infoBookingCofirm);*/
                return infoBookingCofirm;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }

        public async Task<bool> ConfirmBookRoom(ConfirmDto input)
        {
            try
            {
                /*var infoBooking = await _httpContextAccessor.HttpContext.Session.GetObjectAsync<ClientBookRoomOutputDto>("infoBookingConFirm");
*/

                var newPhieuDat = new BookingForm
                {
                    FullName = input.FullName,
                    PhoneNumber = input.PhoneNumber,
                    IdCardNumber = input.IdCardNumber,
                    Email = input.Email,
                    DateCheckin = (DateTime)input.DateCheckin,
                    DateCheckout = (DateTime)input.DateCheckout,
                    BookingOnBehalf = input.BookingOnBehalf,
                    SpecialRequest = input.SpecialRequest
                };

                var idPhieuDat = await _phieuDatPhong.InsertAndGetIdAsync(newPhieuDat);

                var bookingDetailPhieuDat = new BookingDetail
                {
                    RoomStateId = 1,
                    CheckIn = "Từ 14h" + input.DateCheckin.ToString(),
                    CheckOut = "Trước 12h" + input.DateCheckout.ToString(),
                    AdultCount = input.AdultCount,
                    ChildrenCount = input.ChildrenCount,
                    RoomCount = input.RoomCount,
                    OverstayFee = 0,
                    DateCancel = null,
                    CancelFee = 0,
                    BookingFormId = idPhieuDat,
                    RoomId = input.RoomId,
                    TotalBill = input.TotalBill
                };

                await _bookingDetail.InsertAsync(bookingDetailPhieuDat);
                try
                {
                    await CurrentUnitOfWork.SaveChangesAsync();

                    /*var serverEmail = "xuantientran662@gmail.com";
                    var clientEmail = input.Email;
                    var subject = "Thư xác nhận.";
                    var body = "";

                    var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("1d115a4ccaae2c", "d90cefcd50b191"),
                        EnableSsl = true
                    };

                    client.Send(serverEmail, clientEmail, subject, body);*/

                    using (var smtpClient = new SmtpClient("smtp.gmail.com")) // Change to Gmail's SMTP server
                    {
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new NetworkCredential("lethienkhang2002@gmail.com", "hfkinaalbpwwrebr"); // Use your email and app password
                        smtpClient.EnableSsl = true;

                        var mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("lethienkhang2002@gmail.com", "BookingWebsite.com"); // Use your email
                        mailMessage.To.Add(input.Email);
                        mailMessage.Subject = "Hello " + input.FullName + ","; // Chủ đề của mail
                        mailMessage.Body = "Cảm ơn vì đã tin tưởng đặt phòng tại StayEase !"; // nội dung email
                        mailMessage.IsBodyHtml = true;

                        await smtpClient.SendMailAsync(mailMessage);

                        return true;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            catch(Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

    }
}
