using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; } // Nullable - có thể rỗng
        public string Password { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; } // Ngày sinh
        // DÙng để thể hiện 1 user có thể liên kết kết (có) nhiều hòa đơn đi kèm
        public virtual ICollection<HoaDon> HoaDons { get; set;}

    }
}
