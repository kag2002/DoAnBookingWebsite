using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.HotelServices.Dto;
using BookingWebsite.Modules.RoomServices.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.HotelServices
{
    public class HotelServiceAppService : BookingWebsiteAppServiceBase
    {

        private readonly IRepository<HotelService> _hotelService;

        private readonly IRepository<HotelUnit> _hotelUnit;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HotelServiceAppService(IRepository<HotelService> dichVuChung,
            IRepository<HotelUnit> donViKinhDoanh,
            IHttpContextAccessor httpContextAccessor)
        {
            _hotelService = dichVuChung;
            _hotelUnit = donViKinhDoanh;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<HotelServiceOutputDto>> GetAllListHotelService()
        {
            try
            {
                var lstDvc = await _hotelService.GetAllListAsync();

                var dto = lstDvc.Select(e => new HotelServiceOutputDto
                {
                    Id = e.Id,
                    ServiceName = e.ServiceName,
                    Detail = e.Detail,
                    HotelUnitId = e.HotelUnitId

                }).ToList();

                return dto;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddNewDvc(HotelServiceInputDto input)
        {
            try
            {
                var check = await _hotelUnit.FirstOrDefaultAsync(p => p.Id == input.HotelUnitId);

                if (check != null)
                {
                    var dvc = new HotelService
                    {
                        ServiceName = input.ServiceName,
                        Detail = input.Detail,
                        HotelUnitId = input.HotelUnitId
                    };

                    await _hotelService.InsertAsync(dvc);
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

        public async Task<bool> UpdateDvc(HotelServiceOutputDto input)
        {
            try
            {
                var check = await _hotelService.FirstOrDefaultAsync(p => p.Id == input.Id);

                if (check != null)
                {
                    check.ServiceName = input.ServiceName;
                    check.Detail = input.Detail;
                    check.HotelUnitId = input.HotelUnitId;

                    await _hotelService.UpdateAsync(check);
                    return true;
                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay dvu voi id = {input.Id}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteDvc(int id)
        {
            try
            {
                var checkDv = await _hotelService.FirstOrDefaultAsync(p => p.Id == id);
                if (checkDv != null)
                {

                    await _hotelService.DeleteAsync(checkDv);
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa dich vu {checkDv}");
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
