using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using BookingWebsite.Authorization.Users;
using BookingWebsite.DbEntities;
using BookingWebsite.Modules.FeedbackVotes.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.FeedbackVotes
{
    public class FeedbackVoteAppService : BookingWebsiteAppServiceBase
    {
        private readonly IRepository<FeedbackVote> _feedbackVote;

        private readonly IRepository<Customer> _customer;

        private readonly IRepository<BookingDetail> _bookingDetail;

        private readonly IRepository<BookingForm> _bookingForm;

        private readonly IHttpContextAccessor _httpContextAccessor;
/*
        private readonly UserManager _abpUser;
*/
        public FeedbackVoteAppService(IRepository<FeedbackVote> feedbackVote, IRepository<Customer> customer, IHttpContextAccessor httpContextAccessor)
        {
            _feedbackVote = feedbackVote;
            _customer = customer;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<FeedbackVoteDto>> GetAllList()
        {
            try
            {
                var lstNx = await _feedbackVote.GetAllListAsync();
                var lstPd = await _bookingForm.GetAllListAsync();
                var lstKh = await _customer.GetAllListAsync();
                var lstCt = await _bookingDetail.GetAllListAsync();

                var result = (from nx in lstNx
                             join ct in lstCt on nx.BookingDetailId equals ct.Id
                             join pd in lstPd on ct.BookingFormId equals pd.Id
                             select new FeedbackVoteDto
                             {
                                 Feedback = nx.Feedback,
                                 VoteStar = nx.VoteStar,
                                 VotePoint = nx.VotePoint,
                                 BookingDetailId = ct.Id,
                                 RoomId = ct.RoomId
                             }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                await _httpContextAccessor.HttpContext.Response.WriteAsync($"error : {ex.Message}");
                return null;
            }
        }





    }
}
