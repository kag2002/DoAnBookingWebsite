using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Employees.Dto
{
    public class EmployeeOutputDto
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public long? PhoneNumber { get; set; }

        public string? BirthPlace { get; set; }

        public string? Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Address { get; set; }

        public int? Gender { get; set; }

        public string EmployeeAvatar { get; set; }

        public string? UserName { get; set; }


    }
}