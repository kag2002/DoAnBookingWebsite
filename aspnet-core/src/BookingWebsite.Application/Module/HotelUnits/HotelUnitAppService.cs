using Abp.Domain.Repositories;
using BookingWebsite;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.HotelUnits.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.HotelUnits
{
    public class HotelUnitAppService : BookingWebsiteAppServiceBase
    {

        private readonly IRepository<Location> _location;

        private readonly IRepository<HotelUnit> _unitHotel;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HotelUnitAppService(IRepository<Location> location, IRepository<HotelUnit> unitHotel, IHttpContextAccessor httpContextAccessor)
        {
            _location = location;
            _unitHotel = unitHotel;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<HotelUnitInputDto>> GetUnitByLocationId(int id)
        {

            try
            {
                var lstDonVi = await _unitHotel.GetAllListAsync();

                var unit = lstDonVi.Where(p=>p.LocationId == id).Select(e => new HotelUnitInputDto
                {
                   LocationId = e.LocationId,
                   Id = e.Id,
                   UnitName = e.UnitName,
                   LocationDetail = e.LocationDetail,
                   HotelAvatar = e.HotelAvatar,
                   Intro = e.Intro

                }).ToList();

                return unit;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"Error: {ex.Message}");
                return null;
            }

        }


        public async Task<bool> AddNewUnit(HotelUnitDto input)
        {
            try
            {
                var newUnit = new HotelUnit
                {
                    UnitName = input.UnitName,
                    LocationDetail = input.LocationDetail,
                    HotelAvatar = input.HotelAvatar,
                    Intro = input.Intro,
                    LocationId = input.LocationId
                };
                await _unitHotel.InsertAsync(newUnit);
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"Error: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> UpdateUnit(HotelUnitInputDto input)
        {
            try
            {
                var unit = await _unitHotel.FirstOrDefaultAsync(p => p.Id == input.Id);
                if(unit == null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"Không tìm thấy don vi có id = {input.Id}");
                    return false;
                }
                unit.UnitName = input.UnitName;
                unit.LocationDetail = input.LocationDetail;
                unit.HotelAvatar = input.HotelAvatar;
                unit.Intro = input.Intro;
                unit.LocationId = input.LocationId;

                await _unitHotel.UpdateAsync(unit);
                return true;

            }
            catch(Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"Error: {ex.Message}");
                return false;
            }

        }



    }
}
