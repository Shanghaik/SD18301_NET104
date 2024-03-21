using AppData.Models;
using AppData.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class UserController : Controller
    {
        AllRepository<User> repo;
        SD18301_NET104Context context;
        public UserController()
        {
            // Khởi tạo DbContext
            context = new SD18301_NET104Context();
            // Khởi tạo 1 repo với 2 tham số bao gồm: context và DBSet<User> để khi dùng thì
            // DBset được trỏ đến có thể thao tác trên bảng User
            repo = new AllRepository<User>(context, context.Users);
        }
        // 1. Lấy ra data
        public IActionResult Index()
        {
            var data = repo.GetAll(); // Lấy tất cả danh sách của User
            return View(data);
        }
        // 3. Tạo mới
        public IActionResult Create() // Action này để mở form - trả về view Create để điền thông tin
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user) // Action này để xử lý dã ta và thêm vào Db
        {
            user.Id = Guid.NewGuid();   
            repo.CreateObj(user);
            return RedirectToAction("Index");
        }
        // Sửa
        public IActionResult Update(Guid id) // Action này để mở form - trả về view Update để điền thông tin
        {
            var user = repo.GetByID(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User user) // Action này để xử lý dã ta và thêm vào Db
        {
            repo.UpdateObj(user);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var user = repo.GetByID(id);
            repo.DeleteObj(user);
            return RedirectToAction("Index");
        }
    }
}
