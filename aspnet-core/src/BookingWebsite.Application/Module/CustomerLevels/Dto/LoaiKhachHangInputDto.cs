using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Module.CustomerLevels.Dto
{
    public class CustomerLevelInputDto
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public double DiscountRatio { get; set; }
    }
}
