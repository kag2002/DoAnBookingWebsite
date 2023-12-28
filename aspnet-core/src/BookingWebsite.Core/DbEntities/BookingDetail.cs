using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class BookingDetail : FullAuditedEntity
    {
        public int RoomStateId { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        public int AdultCount { get; set; }

        public int ChildrenCount { get; set; }

        public int RoomCount { get; set; }

        public double OverstayFee { get; set; }

        public DateTime? DateCancel { get; set; }

        public double CancelFee { get; set; }

        public double TotalBill { get; set; }

        public int RoomId { get; set; }

        public int RoomCategoryId { get; set; }

        public int BookingFormId { get; set; }

        public ICollection<FeedbackVote> FeedbackVotes { get; set; }
    }
}
