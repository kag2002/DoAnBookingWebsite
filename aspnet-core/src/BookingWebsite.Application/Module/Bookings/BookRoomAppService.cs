using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.Bookings.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.DatPhongs
{
    public class BookRoomAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<BookingForm> _booking;

        private readonly IRepository<Employee> _employee;

        private readonly IRepository<Customer> _customer;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookRoomAppService(IRepository<BookingForm> booking, IRepository<Employee> employee, IRepository<Customer> customer, IHttpContextAccessor httpContextAccessor)
        {
            _booking = booking;
            _employee = employee;
            _customer = customer;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<BookingFormDto>> GetAllList()
        {
            try
            {
                var lstDatPhong = await _booking.GetAllListAsync();
                var lstKH = await _customer.GetAllListAsync();
                var lstNV = await _employee.GetAllListAsync();

                var dtoLstDP = lstDatPhong.Select(entity => new BookingFormDto
                {
                    Id = entity.Id,
                    DateCheckin = entity.DateCheckin,
                    DateCheckout = entity.DateCheckout,
                    /*Customer = lstKH.Where(p => p.Id == entity.CustomerId).Select(p => p.HoTen).ToString(),
                    Employee = lstNV.Where(p => p.Id == entity.EmployeeId).Select(p => p.HoTen).ToString()*/

                }).ToList();

                return dtoLstDP;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }

        /*public async Task<bool> CreateNewTicket(BookingFormInputDto input)
        {
            try
            {
                var newTicket = new BookingForm
                {
                    DateCheckin = input.DateCheckin,
                    DateCheckout = input.DateCheckout,
                    CustomerId = input.CustomerId,
                    EmployeeId = input.EmployeeId
                };

                await _booking.InsertAsync(newTicket);
                return true;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }*/

        public async Task<bool> UpdateTicket(BookingFormOutputDto input)
        {
            try
            {
                var check = await _booking.FirstOrDefaultAsync(p => p.Id == input.Id);
                if (check != null)
                {
                    check.DateCheckin = input.DateCheckin;
                    check.DateCheckout = input.DateCheckout;

                    await _booking.UpdateAsync(check);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return false;
            }
        }



    }
}
