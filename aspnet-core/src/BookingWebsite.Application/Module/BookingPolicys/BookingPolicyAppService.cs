using Abp.Domain.Repositories;
using BookingWebsite.Modules.BookingPolicys.Dto;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.BookingPolicys.Dto;
using BookingWebsite.Modules.RoomServices.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.BookingPolicys
{
    public class BookingPolicyAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<BookingPolicy> _bookingPolicy;

        private readonly IRepository<HotelUnit> _hotelUnit;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingPolicyAppService(IRepository<BookingPolicy> chinhSachChung,
            IRepository<HotelUnit> donViKinhDoanh,
            IHttpContextAccessor httpContextAccessor)
        {
            _bookingPolicy = chinhSachChung;
            _hotelUnit = donViKinhDoanh;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BookingPolicyOutputDto> GetPolicyByDVKDId(int dvkdId)
        {
            try
            {
                var policy = await _bookingPolicy.FirstOrDefaultAsync(p => p.HotelUnitId == dvkdId);
                var dto = new BookingPolicyOutputDto
                {
                    Id=policy.Id,
                    CheckInfor = policy.CheckInfor,
                    Breakfast = policy.Breakfast,
                    Checkin = policy.Checkin,
                    Checkout = policy?.Checkout,
                    RoomPolicy = policy?.RoomPolicy,
                    ChildrenPolicy = policy?.ChildrenPolicy,
                    SubBedPolicy = policy?.SubBedPolicy,
                    PetPolicy = policy?.PetPolicy,
                    PaymentMethod = policy?.PaymentMethod,
                    HotelUnitId = dvkdId
                };
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookingPolicyOutputDto>> GetAllListChinhSach()
        {
            try
            {
                var lstCs = await _bookingPolicy.GetAllListAsync();

                var dto = lstCs.Select(e => new BookingPolicyOutputDto
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
                    PaymentMethod = e.PaymentMethod,
                    HotelUnitId = e.HotelUnitId

                } ).ToList();

                return dto;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }


        public async Task<bool> AddNewCsc(BookingPolicyInputDto input)
        {
            try
            {
                var check = await _hotelUnit.FirstOrDefaultAsync(p => p.Id == input.HotelUnitId);

                if (check != null)
                {
                    var csc = new BookingPolicy
                    {
                        CheckInfor = input.CheckInfor,
                        Breakfast = input.Breakfast,
                        Checkin = input.Checkin,
                        Checkout =input.Checkout,
                        RoomPolicy = input.RoomPolicy,
                        ChildrenPolicy = input.ChildrenPolicy,
                        SubBedPolicy = input.SubBedPolicy,
                        PetPolicy = input.PetPolicy,
                        PaymentMethod = input.PaymentMethod,
                        HotelUnitId = input.HotelUnitId

                    };

                    await _bookingPolicy.InsertAsync(csc);
                    return true;
                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay don vi kinh doanh voi id = {input.HotelUnitId}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }


        public async Task<bool> UpdateCsc(BookingPolicyOutputDto input)
        {
            try
            {
                var check = await _bookingPolicy.FirstOrDefaultAsync(p => p.Id == input.Id);

                if (check != null)
                {
                    check.Breakfast = input.Breakfast;
                    check.CheckInfor = input.CheckInfor;
                    check.Checkin = input.Checkin;
                    check.Checkout = input.Checkout;
                    check.RoomPolicy = input.RoomPolicy;
                    check.ChildrenPolicy = input.ChildrenPolicy;
                    check.SubBedPolicy = input.SubBedPolicy;
                    check.PetPolicy = input.PetPolicy;
                    check.PaymentMethod = input.PaymentMethod;
                    check.HotelUnitId = input.HotelUnitId;

                    await _bookingPolicy.UpdateAsync(check);
                    return true;
                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay chinh sach chung voi id = {input.Id} cua don vi kinh doang {input.HotelUnitId}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }


        public async Task<bool> DeleteCsc(int id)
        {
            try
            {
                var checkCsc = await _bookingPolicy.FirstOrDefaultAsync(p => p.Id == id);
                if (checkCsc != null)
                {
                    await _bookingPolicy.DeleteAsync(checkCsc);
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa dich vu {checkCsc}");
                    return true;

                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay dvu voi id = {id}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

    }
}
