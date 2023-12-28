using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.Employees.Dto;
using BookingWebsite.Module.CustomerLevels.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Module.CustomerLevels
{
    public class CustomerLevelAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<CustomerLevel> _customerLevel;

        private readonly IRepository<Customer> _customer;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerLevelAppService(IRepository<CustomerLevel> customerLevel, IRepository<Customer> customer, IHttpContextAccessor httpContextAccessor)
        {
            _customerLevel = customerLevel;
            _customer = customer;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetClientByTypeDto>> GetClientByType(int id)
        {
            try
            {
                var lstLkh = await _customerLevel.GetAllListAsync();
                var lstKh = await _customer.GetAllListAsync();

                var customer = lstKh.Where(p => p.CustomerLevelId == id).ToList();

                var dtoKh = customer.Select(e => new GetClientByTypeDto
                {
                    CustomerLevelId = e.CustomerLevelId,
                    Level = lstLkh.FirstOrDefault(p => p.Id == e.CustomerLevelId).Level,
                    CustomerId = e.Id,
                    IdCardNumber = e.IdCardNumber,
                    FullName = e.FullName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    BirthDate = e.BirthDate,
                    Address = e.Address,
                    Gender = e.Gender,
                    UserName = e.UserName
                }).ToList();

                return dtoKh;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return null;
            }

        }

        public async Task<List<CustomerLevelInputDto>> GetAllList()
        {
            try
            {
                var lst = await _customerLevel.GetAllListAsync();

                var dtoLst = lst.Select(entity => new CustomerLevelInputDto
                {
                    Id = entity.Id,
                    Level = entity.Level,
                    DiscountRatio = entity.DiscountRatio
                }).ToList();

                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddNewItem(CustomerLevelDto input)
        {
            try
            {
                var newItem = new CustomerLevel
                {
                    Level = input.Level,
                    DiscountRatio = input.DiscountRatio
                };

                await _customerLevel.InsertAsync(newItem);

                return true;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateInfoItem(CustomerLevelInputDto input)
        {
            try
            {
                var check = await _customerLevel.FirstOrDefaultAsync(p => p.Id == input.Id);
                if (check != null)
                {
                    check.Level = input.Level;
                    check.DiscountRatio = input.DiscountRatio;

                    await _customerLevel.UpdateAsync(check);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteItem(int id)
        {
            try
            {
                var check = await _customerLevel.FirstOrDefaultAsync(p => p.Id == id);
                if (check != null)
                {
                    var customer = await _customer.GetAllListAsync();
                    var checkKH = customer.Where(p => p.CustomerLevelId == check.Id).ToList();

                    if (checkKH.Count > 0)
                    {
                        foreach (var i in checkKH)
                        {
                            i.CustomerLevelId = null;
                        }
                    }

                    await _customerLevel.DeleteAsync(check);
                    return true;
                }
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"khong tim thay loai khach hang voi id = {id}");
                return false;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }


    }
}
