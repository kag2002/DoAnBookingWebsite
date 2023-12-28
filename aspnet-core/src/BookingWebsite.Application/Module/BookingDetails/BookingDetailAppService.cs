using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.BookingDetails.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.BookingDetails
{
    public class BookingDetailAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<BookingDetail> _bookingDetail;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingDetailAppService(IRepository<BookingDetail> bookingDetail, IHttpContextAccessor httpContextAccessor)
        {
            _bookingDetail = bookingDetail;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<BookingDetailDto>> GetAllList()
        {
            try
            {
                var lstChiTiet = await _bookingDetail.GetAllListAsync();
                var dtoList = lstChiTiet.Select(e => new BookingDetailDto
                {
                    Id = e.Id,
                    RoomId = e.RoomId,
                    BookingFormId = e.BookingFormId,
                    RoomStateId = e.RoomStateId,
                    CheckIn = e.CheckIn,
                    CheckOut = e.CheckOut,
                    AdultCount = e.AdultCount,
                    ChildrenCount = e.ChildrenCount,
                    RoomCount = e.RoomCount,
                    OverstayFee = e.OverstayFee,
                    DateCancel = e.DateCancel,
                    CancelFee = e.CancelFee,
                    TotalBill = e.TotalBill

                }).ToList();
                return dtoList;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }

    }
}
