using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public DateTime SoldDate { get; set; } // Ngày bán
        public decimal TotalMoney { get; set; } // Tổng tiền
        public int Status { get; set; } // Trạng thái 
        public Guid UserID { get; set; }
        // Thiếu 1 vài thuộc tính chưa cho vào đâu
        public virtual User User { get; set; }
    }
}
