using Abp.Domain.Repositories;
using BookingWebsite.Modules.RoomCategorys.Dto;
using BookingWebsite.DbEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Module.RoomCategorys
{
    public class RoomCategoryAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<RoomCategory> _roomCategory;

        private readonly IRepository<RoomService> _hotelService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomCategoryAppService(IRepository<RoomCategory> repository, IRepository<RoomService> repository1,
            IHttpContextAccessor httpContextAccessor)
        {
            _roomCategory = repository;
            _hotelService = repository1;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<RoomCategoryOutputDto>> GetAllKindOfRoom()
        {
            try
            {
                var lstRoom = await _roomCategory.GetAllListAsync();
                var lstDv = await _hotelService.GetAllListAsync();

                var dtoLst = lstRoom.Select(entity => new RoomCategoryOutputDto
                {
                    Id = entity.Id,
                    RoomCategoryName = entity.RoomCategoryName,
                    Capacity = entity.Capacity,
                    Describe = entity.Describe,
                    RoomCategoryService = entity.RoomCategoryService,
                    PricePerNight = entity.PricePerNight,
                    ServiceExtendPrice = entity.ServiceExtendPrice,
                    Discount = entity.Discount,
                    RoomCategoryServiceName = (from i in lstDv where i.RoomCategoryId == entity.Id select i.ServiceName).ToList()
                }).ToList();

                return dtoLst;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddNewKind(RoomCategoryInputDto input)
        {
            try
            {
                var lp = new RoomCategory
                {
                    RoomCategoryName = input.RoomCategoryName,
                    Describe = input.Describe,
                    Capacity = input.Capacity,
                    RoomCategoryService = input.RoomCategoryService,
                    ServiceExtendPrice = input.ServiceExtendPrice,
                    PricePerNight = input.PricePerNight,
                    Discount = input.Discount
                };
                await _roomCategory.InsertAsync(lp);

                CurrentUnitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateLP(RoomCategoryDto input)
        {
            try
            {
                var check = await _roomCategory.FirstOrDefaultAsync(p => p.Id == input.Id);
                if (check != null)
                {
                    check.RoomCategoryName = input.RoomCategoryName;
                    check.Describe = input.Describe;
                    check.Capacity = input.Capacity;
                    check.RoomCategoryService = input.RoomCategoryService;
                    check.PricePerNight = input.PricePerNight;
                    check.ServiceExtendPrice = input.ServiceExtendPrice;
                    check.Discount = input.Discount;

                    await _roomCategory.UpdateAsync(check);
                    return true;
                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong ton tai loai phong voi id = {input.Id}");
                    return false;
                }

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteLP(int id)
        {
            try
            {
                var checkLP = await _roomCategory.FirstOrDefaultAsync(p => p.Id == id);

                if (checkLP != null)
                {
                    var dichVu = await _hotelService.GetAllListAsync();
                    var checkDv = dichVu.Where(p => p.RoomCategoryId == checkLP.Id).ToList();
                    if (checkDv.Any())
                    {
                        foreach (var i in checkDv)
                        {
                            await _hotelService.DeleteAsync(i);
                            await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa dich vu: {i}");
                        }
                    }

                    await _roomCategory.DeleteAsync(checkLP);
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"da xoa thuc the loai phong: {checkLP}");
                    return true;

                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay loai phong voi id = {id}");
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
