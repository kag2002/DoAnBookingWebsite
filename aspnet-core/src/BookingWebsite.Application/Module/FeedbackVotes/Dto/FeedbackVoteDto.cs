using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.FeedbackVotes.Dto
{
    public class FeedbackVoteDto
    {
        public int CustomerId { get; set; }

        public string Customer { get; set; }

        public string Feedback { get; set; }

        public float VotePoint { get; set; }

        public float VoteStar { get; set; }

        public int BookingDetailId { get; set; }

        public int RoomId { get; set; }

    }
}
