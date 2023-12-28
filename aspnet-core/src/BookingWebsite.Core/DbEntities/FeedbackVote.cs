using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class FeedbackVote : FullAuditedEntity, IMayHaveTenant
    {
        public string Feedback { get; set; }

        public float VotePoint { get; set; }

        public float VoteStar { get; set; }

        public int BookingDetailId { get; set; }

        public int? TenantId { get; set; }
    }
}
