using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Module.Customers.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Module.Customers
{
    public class CustomerAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<Customer> _customer;

        private readonly IRepository<CustomerLevel> _customerLevel;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerAppService(IRepository<Customer> customer, IRepository<CustomerLevel> customerLevel, IHttpContextAccessor httpContextAccessor)
        {
            _customer = customer;
            _customerLevel = customerLevel;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CustomerOutputDto>> GetAllListClient()
        {
            try
            {
                var lstKh = await _customer.GetAllListAsync();

                var customerLevel = await _customerLevel.GetAllListAsync();

                var dtoLst = lstKh.Select(entity => new CustomerOutputDto
                {
                    Id = entity.Id,
                    IdCardNumber = entity.IdCardNumber,
                    FullName = entity.FullName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    BirthDate = entity.BirthDate,
                    Address = entity.Address,
                    Gender = entity.Gender,
                    CustomerLevel = customerLevel.FirstOrDefault(p => p.Id == entity.CustomerLevelId).Level,
                    UserName = entity.UserName
                }).ToList();

                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> RegisterForClient(CustomerInputDto input)
        {
            try
            {
                var checkUser = await _customer.FirstOrDefaultAsync(p => p.UserName == input.UserName);
                if (checkUser != null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"tai khoan {input.UserName} da ton tai");
                    return false;
                }

                var checkCccd = await _customer.FirstOrDefaultAsync(p => p.IdCardNumber == input.IdCardNumber);
                if (checkCccd != null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"so cccd nay da duoc dang ki");
                    return false;
                }

                var checkEmail = await _customer.FirstOrDefaultAsync(p => p.Email == input.Email);
                if (checkEmail != null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"Email nay da duoc dang ki");
                    return false;
                }

                var checkSDt = await _customer.FirstOrDefaultAsync(p => p.PhoneNumber == input.PhoneNumber);
                if (checkSDt != null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"SDT nay da duoc dang ki");
                    return false;
                }

                var newClient = new Customer
                {
                    UserName = input.UserName,
                    Password = input.Password,
                    IdCardNumber = input.IdCardNumber,
                    FullName = input.FullName,
                    PhoneNumber = input.PhoneNumber,
                    Email = input.Email,
                    BirthDate = input.BirthDate,
                    Gender = input.Gender,
                    Address = input.Address,
                    CustomerLevelId = 1
                };

                await _customer.InsertAsync(newClient);
                //CurrentUnitOfWork.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateInfoClient(CustomerDto input)
        {
            try
            {
                var check = await _customer.FirstOrDefaultAsync(p => p.Id == input.Id);
                if (check != null)
                {
                    check.IdCardNumber = input.IdCardNumber;
                    check.FullName = input.FullName;
                    check.PhoneNumber = input.PhoneNumber;
                    check.Email = input.Email;
                    check.Address = input.Address;
                    check.Gender = input.Gender;
                    check.BirthDate = input.BirthDate;

                    await _customer.UpdateAsync(check);
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


        public async Task<bool> ChangePasswordKH(CustomerChangePasswordDto input)
        {
            try
            {
                var checkPass = await _customer.FirstOrDefaultAsync(p => p.Id == input.Id);

                if (checkPass != null)
                {
                    if (input.CurrentPassword == checkPass.Password)
                    {
                        if (input.NewPassWord == input.ConfirmPassWord)
                        {
                            checkPass.Password = input.NewPassWord;
                            return true;
                        }
                        else
                        {
                            await _httpContextAccessor.HttpContext.Response.WriteAsync("Xac nhan mat khau moi that bai!");
                            return false;
                        }
                    }
                    else
                    {
                        await _httpContextAccessor.HttpContext.Response.WriteAsync("Mat khau cu khong chinh xac!");
                        return false;
                    }
                }
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
