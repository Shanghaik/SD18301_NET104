using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    internal interface IAllRepository<T> where T : class // Generic nhưng giới hạn class
    {
        // Read (Get) - lấy
        public ICollection<T> GetAll(); // Lấy tất
        public T GetByID(dynamic id); // Lấy theo ID
        // Create - Tạo mới
        public bool CreateObj(T obj); // Tạo mới đối tượng trong CSDL truyền vào cả đối tượng
        // Update - Sửa đối tượng trong DB
        public bool UpdateObj(T obj);
        // Delete - Xóa đối tượng trong DB
        public bool DeleteObj(T obj);

    }
}
