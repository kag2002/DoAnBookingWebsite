using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWebsite.Modules.Employees.Dto
{
    public class EmployeeChangePasswordDto
    {
        public int Id { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassWord { get; set; }

        public string ConfirmPassWord { get; set; }
    }
}
