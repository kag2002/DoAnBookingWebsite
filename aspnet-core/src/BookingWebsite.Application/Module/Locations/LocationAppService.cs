using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingWebsite;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using BookingWebsite.DbEntities;
using System.IO;
using BookingWebsite.Module.LocationManagement.Dto;
using BookingWebsite.Modules.DiaDiems.Dto;

namespace BookingWebsite.Module.Locations
{
    public class LocationAppService : BookingWebsiteAppServiceBase
    {


        private readonly IRepository<Location> _location;

        private readonly IRepository<HotelUnit> _hotelUnit;

        private readonly IRepository<Room> _room;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocationAppService(IRepository<Location> location, IRepository<HotelUnit> hotelUnit, IRepository<Room> phong, IHttpContextAccessor httpContextAccessor)
        {
            _location = location;
            _hotelUnit = hotelUnit;
            _room = phong;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<LocationFullDto>> GetAllLocations()
        {
            try
            {
                var lst = await _location.GetAllListAsync();

                var dtoLst = lst.Select(entity => new LocationFullDto
                {
                    Id = entity.Id,
                    LocationName = entity.LocationName,
                    LocationInfor = entity.LocationInfor,
                    ImgName = entity.ImgName
                }).ToList();

                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddNewLocation(LocationDto input)
        {
            try
            {
                var item = new Location
                {
                    LocationName = input.LocationName,
                    LocationInfor = input.LocationInfor,
                };

                await _location.InsertAsync(item);
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateLocation(LocationFullDto input)
        {
            try
            {
                var item = await _location.FirstOrDefaultAsync(p => p.Id == input.Id);

                if (item == null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong ton tai dia danh voi id = {input.Id}");
                    return false;
                }
                else
                {
                    item.LocationName = input.LocationName;
                    item.LocationInfor = input.LocationInfor;
                    item.ImgName = input.ImgName;

                    await _location.UpdateAsync(item);
                    return true;
                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteLocation(int id)
        {
            try
            {
                var checkDD = await _location.FirstOrDefaultAsync(p => p.Id == id);
                if (checkDD == null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong co dia diem voi id = {id}");
                    return false;
                }
                else
                {
                    var DVKD = await _hotelUnit.GetAllListAsync();

                    var checkDvkd = DVKD.Where(p => p.LocationId == checkDD.Id).ToList();

                    if (checkDvkd.Any())
                    {
                        foreach (var i in checkDvkd)
                        {
                            i.LocationId = null;
                        }
                    }

                    await _location.DeleteAsync(checkDD);
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa dia diem {checkDD}");
                    return true;
                }

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UploadImage(int id, IFormFile imageFile, string path)
        {
            try
            {
                if (imageFile != null & imageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(imageFile.Name);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    var location = await _location.FirstOrDefaultAsync(p => p.Id == id);

                    if (location != null)
                    {
                        location.ImgName = fileName.ToString();
                        await _location.UpdateAsync(location);
                        return true;
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }

}
