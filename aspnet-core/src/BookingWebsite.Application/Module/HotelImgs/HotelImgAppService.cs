using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.HotelImgs.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.HotelImgs
{
    public class HotelImgAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<HotelImg> _hotelImg;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HotelImgAppService(IRepository<HotelImg> hotelImg, IHttpContextAccessor httpContextAccessor)
        {
            _hotelImg = hotelImg;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<HotelImgInputDto>> GetImageByRoom(int id)
        {
            try
            {
                var lstHa = await _hotelImg.GetAllListAsync();

                var lst = lstHa.Where(p=>p.RoomId == id).ToList();

                var dtoLst = lst.Select(entity => new HotelImgInputDto
                {
                    ID = entity.Id,
                    ImgFileName = entity.ImgFileName,
                    RoomId = entity.RoomId
                }).ToList();
                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }


        public async Task<List<HotelImgInputDto>> GetALlListImage()
        {
            try
            {
                var lstAnh = await _hotelImg.GetAllListAsync();
                var dtoLst = lstAnh.Select(entity => new HotelImgInputDto
                {
                    ImgFileName = entity.ImgFileName,
                    RoomId = entity.RoomId
                }).ToList();
                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }

        }

        public async Task<bool> AddNewImage(HotelImgDto input)
        {
            try
            {
                var ha = new HotelImg
                {
                    ImgFileName = input.ImgFileName,
                    RoomId = input.RoomId
                };

                await _hotelImg.InsertAsync(ha);
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateImage(HotelImgInputDto input)
        {
            try
            {
                var item = await _hotelImg.FirstOrDefaultAsync(p => p.Id == input.ID);
                if (item == null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay id: {input.ID}");
                    return false;
                }

                item.ImgFileName = input.ImgFileName;

                await _hotelImg.UpdateAsync(item);
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteImage(int id)
        {
            try
            {
                var checkHa = await _hotelImg.FirstOrDefaultAsync(p => p.Id == id);
                if (checkHa == null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay hinh anh voi id = {id}");
                    return false;
                }
                await _hotelImg.DeleteAsync(checkHa);
                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }
    }
}
