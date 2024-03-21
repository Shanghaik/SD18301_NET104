using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repository
{
    public class AllRepository<T> : IAllRepository<T> where T : class
    {
        // Khai báo DBContext
        SD18301_NET104Context _context;
        // Tạo ra 1 DBSet riêng, khi nào cần dừng chính thức thì mình lại gán 
        DbSet<T> _dbSet;
        public AllRepository() // Không tham số
        {
            _context = new SD18301_NET104Context();
        }
        public AllRepository(SD18301_NET104Context context, DbSet<T> dbSet) // Có tham số
        {
            _context = context;
            _dbSet = dbSet;
        }
        // Thay vì trỏ trực tiếp đến 1 DBSet để thực hiện CRUD thì chúng ta tạo ra 1 DBSet
        // để viết các phương thức sau đó khi chúng ta cần dùng Repos thì chúng ta sẽ
        // gán DBSet cần dùng vào trong Constructor
        public bool CreateObj(T obj)
        {
            try
            {
                _dbSet.Add(obj); // Thêm
                _context.SaveChanges();  // Lưu lại
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteObj(T obj)
        {
            try
            {
                _dbSet.Remove(obj); // Thêm
                _context.SaveChanges();  // Lưu lại
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(dynamic id)
        {
            return _dbSet.Find(id);// Phương thức Find mà truyền trực tiếp tham số chỉ dùng với PK
        }

        public bool UpdateObj(T obj)
        {
            try
            {
                _dbSet.Update(obj); // Thêm
                _context.SaveChanges();  // Lưu lại
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
