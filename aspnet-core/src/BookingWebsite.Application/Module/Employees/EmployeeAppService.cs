using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.Employees.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Employees
{
    public class EmployeeAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<Employee> _employee;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeAppService(IRepository<Employee> employee, IHttpContextAccessor httpContextAccessor)
        {
            _employee = employee;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<EmployeeOutputDto>> GetAllListNv()
        {
            try
            {
                var lstNv = await _employee.GetAllListAsync();

                var dtoLst = lstNv.Select(entity => new EmployeeOutputDto
                {
                    Id = entity.Id,
                    FullName = entity?.FullName,
                    PhoneNumber = entity.PhoneNumber,
                    BirthPlace = entity?.BirthPlace,
                    Email = entity?.Email,
                    BirthDate = entity.BirthDate,
                    Address = entity?.Address,
                    Gender = entity.Gender,
                    EmployeeAvatar = entity.EmployeeAvatar,
                    UserName = entity?.UserName
                }).ToList();

                return dtoLst;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> RegisterForStaff(EmployeeDto input)
        {
            try
            {
                var checkUsername = await _employee.FirstOrDefaultAsync(p => p.UserName == input.UserName);
                if (checkUsername != null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"tai khoan {input.UserName} da ton tai");
                    return false;
                }

                var checkSDt = await _employee.FirstOrDefaultAsync(p => p.UserName == input.UserName);
                if (checkSDt != null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"SDT nay da duoc dang ki");
                    return false;
                }

                var checkEmail = await _employee.FirstOrDefaultAsync(p => p.Email == input.Email);
                if (checkEmail != null)
                {
                    await _httpContextAccessor.HttpContext.Response.WriteAsync($"Email nay da duoc dang ki");
                    return false;
                }

                var newStaff = new Employee
                {
                    FullName = input.FullName,
                    PhoneNumber = input.PhoneNumber,
                    BirthPlace = input.BirthPlace,
                    Email = input.Email,
                    BirthDate = input.BirthDate,
                    Address = input.Address,
                    Gender = input.Gender,
                    UserName = input.UserName,
                    Password = input.Password,
                };

                await _employee.InsertAsync(newStaff);
                return true;

            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateInfoStaff(EmpolyeeInputDto input)
        {
            try
            {
                var check = await _employee.FirstOrDefaultAsync(p => p.Id == input.Id);
                if (check != null)
                {
                    check.FullName = input.FullName;
                    check.PhoneNumber = input.PhoneNumber;
                    check.BirthPlace = input.BirthPlace;
                    check.Email = input.Email;
                    check.BirthDate = input.BirthDate;
                    check.Address = input.Address;
                    check.Gender = input.Gender;

                    await _employee.UpdateAsync(check);
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

        public async Task<bool> ChangePasswordNV(EmployeeChangePasswordDto input)
        {
            try
            {
                var checkPass = await _employee.FirstOrDefaultAsync(p => p.Id == input.Id);

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
