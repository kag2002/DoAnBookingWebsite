using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.RoomServices.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.RoomServices
{
    public class RoomServiceAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<RoomService> _roomService;

        private readonly IRepository<RoomCategory> _roomCategory;

        private readonly IRepository<FeedbackVote> _feedback;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomServiceAppService(IRepository<RoomService> roomService, IRepository<RoomCategory> roomCategory, IRepository<FeedbackVote> feedback, IHttpContextAccessor httpContextAccessor)
        {
            _roomService = roomService;
            _roomCategory = roomCategory;
            _feedback = feedback;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<RoomServiceOutputDto>> GetServiceByKindOfRoom(int id)
        {
            try
            {
                var lstDv = await _roomService.GetAllListAsync();
                var lstLp = await _roomCategory.GetAllListAsync();

                var lst = lstDv.Where(x => x.RoomCategoryId == id).ToList();

                var dtoLst = lst.Select(entity => new RoomServiceOutputDto
                {
                    Id = entity.Id,
                    ServiceName = entity.ServiceName,
                    Describe = entity.Describe,
                    RoomCategoryName = lstLp.FirstOrDefault(p => p.Id == entity.RoomCategoryId).RoomCategoryName ?? string.Empty

                }).ToList();

                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }



        public async Task<List<RoomServiceOutputDto>> GetAllDv()
        {
            try
            {
                var lstDv = await _roomService.GetAllListAsync();
                var lstLp = await _roomCategory.GetAllListAsync(); 

                var dtoLst = lstDv.Select(entity => new RoomServiceOutputDto
                {
                    Id = entity.Id,
                    ServiceName = entity.ServiceName,
                    Describe = entity.Describe,
                    RoomCategoryName = lstLp.FirstOrDefault(p => p.Id == entity.RoomCategoryId)?.RoomCategoryName ?? string.Empty

                }).ToList();

                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddNewDv(RoomServiceInputDto input)
        {
            try
            {
                var check = await _roomCategory.FirstOrDefaultAsync(p => p.Id == input.RoomCategoryId);

                if (check != null)
                {
                    var dv = new RoomService
                    {
                        ServiceName = input.ServiceName,
                        Describe = input.Describe,
                        RoomCategoryId = input.RoomCategoryId
                    };

                    await _roomService.InsertAsync(dv);
                    return true;
                }
                else
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay loai phong voi id = {input.RoomCategoryId}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateDv(RoomServiceDto input)
        {
            try
            {
                var check = await _roomService.FirstOrDefaultAsync(p => p.Id == input.Id);

                if (check != null)
                {
                    check.ServiceName = input.ServiceName;
                    check.Describe = input.Describe;

                    await _roomService.UpdateAsync(check);
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

        public async Task<bool> DeleteDv(int id)
        {
            try
            {
                var checkDv = await _roomService.FirstOrDefaultAsync(p => p.Id == id);
                if (checkDv != null)
                {
                    
                    await _roomService.DeleteAsync(checkDv);
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
