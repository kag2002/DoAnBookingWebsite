using Abp.Domain.Repositories;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.Contacts.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Contacts
{
    public class ContactAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<Contact> _contact;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactAppService(IRepository<Contact> contact, IHttpContextAccessor httpContextAccessor)
        {
            _contact = contact;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<DanhSachOutputDto>> GetDanhSachContact()
        {
            try
            {
                var lst = await _contact.GetAllListAsync();

                var dto = lst.Select(e => new DanhSachOutputDto
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    Content = e.Content,
                    userId = e.CreatorUserId
                }).ToList();
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<DanhSachOutputDto>> GetDanhSachContactByUserId(int userId)
        {
            try
            {
                if (userId == 0)
                {
                    throw new Exception($"{userId} is invalid !");
                }

                var lst = await _contact.GetAllListAsync();

                var dto = lst.Where(p => p.CreatorUserId == userId).Select(e => new DanhSachOutputDto
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    Content = e.Content,
                    userId = e.CreatorUserId
                }).ToList();
                return dto;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> ClientSendToMessage(MessageDto input)
        {
            try
            {
                var message = new Contact
                {
                    FullName = input.FullName,
                    Email = input.Email,
                    PhoneNumber = input.PhoneNumber,
                    Content = input.Content
                };

                await _contact.InsertAsync(message);

                using (var smtpClient = new SmtpClient("smtp.gmail.com")) // Change to Gmail's SMTP server
                {
                    smtpClient.Port = 587;
                   smtpClient.Credentials = new NetworkCredential("lethienkhang2002@gmail.com", "hfkinaalbpwwrebr"); // Use your email and app password
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("lethienkhang2002@gmail.com", "BookingWebsite.com"); // Use your email
                    mailMessage.To.Add(input.Email);
                    mailMessage.Subject = "Hello " + input.FullName + ","; // Chủ đề của mail
                    mailMessage.Body = "Thank you !"; // nội dung email
                    mailMessage.IsBodyHtml = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Test send to email
        public async Task<bool> ServerSendToMailClient(MailDto input)
        {
            try
            {
                /*var serverEmail = "xuantientran662@gmail.com";
                var clientEmail = input.Email;
                var subject = "Xin chào, "+ input.FullName + " !";
                var body = "success";

                var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("1d115a4ccaae2c", "d90cefcd50b191"),
                    EnableSsl = true
                };

                client.Send(serverEmail, clientEmail, subject, body);
                return true;*/

                using (var smtpClient = new SmtpClient("smtp.gmail.com")) // Change to Gmail's SMTP server
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("your_email", "your_app_password"); // Use your email and app password
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("your_email","BookingWebsite.com"); // Use your email
                    mailMessage.To.Add(input.Email);
                    mailMessage.Subject = "Hello "+input.FullName+","; // Chủ đề của mail
                    mailMessage.Body = "Thank you !"; // nội dung email
                    mailMessage.IsBodyHtml = true;

                    await smtpClient.SendMailAsync(mailMessage);

                    return true;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
