using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.DbEntities
{
    public class RoomCategory : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string RoomCategoryName { get; set; }

        public int TotalRoomCount { get; set; }

        public int Capacity { get; set; }

        public int EmptyRoomCount { get; set; }

        public string Describe { get; set; }

        public string RoomAvatar { get; set; }

        public string RoomCategoryService { get; set; }

        public double PricePerNight { get; set; }

        public double ServiceExtendPrice { get; set; }

        public bool FreeCancelBook { get; set; }

        public double CancelBookFee { get; set; }

        public double Discount { get; set; }

        public double SpecialDiscount { get; set; }

        public int HotelUnitId { get; set; }

        public ICollection<RoomService> RoomServices { get; set; }

    }
}
