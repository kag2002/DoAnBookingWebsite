using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BookingWebsite.Authorization.Roles;
using BookingWebsite.Authorization.Users;
using BookingWebsite.MultiTenancy;
using BookingWebsite.DbEntities;

namespace BookingWebsite.EntityFrameworkCore
{
    public class BookingWebsiteDbContext : AbpZeroDbContext<Tenant, Role, User, BookingWebsiteDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<BookingDetail> BwBookingDetail { get; set; }

        public DbSet<BookingForm> BwBookingForm { get; set; }

        public DbSet<Location> BwLocation { get; set; }

        public DbSet<RoomService> BwRoomService { get; set; }

        public DbSet<HotelImg> BwHotelImg { get; set; }

        public DbSet<RoomCategory> BwRoomCategory { get; set; }

        public DbSet<Customer> BwCustomer { get; set; }

        public DbSet<CustomerLevel> BwCustomerLevel { get; set; }

        public DbSet<HotelCategory> BwHotelCategory { get; set; }

        public DbSet<Employee> BwEmployee { get; set; }

        public DbSet<FeedbackVote> BwFeedbackVote { get; set; }

        public DbSet<Room> BwRoom { get; set; }

        public DbSet<HotelUnit> BwHotelUnit { get; set; }

        public DbSet<BookingPolicy> BwBookingPolicy { get; set; }

        public DbSet<HotelService> BwHotelService { get; set; }

        public DbSet<Contact> BwContact { get; set; }

        public BookingWebsiteDbContext(DbContextOptions<BookingWebsiteDbContext> options)
            : base(options)
        {
        }
    }
}
