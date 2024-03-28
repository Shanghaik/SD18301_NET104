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
        public IActionResult Index(string name = "87t7r7r68r76dsz")
        {
            ViewData["count"] = 0;
            var data = repo.GetAll(); // Lấy tất cả danh sách của User
            // Lấy danh sách cần tìm kiếm theo tên có chứa chuỗi được nhập vào
            var searchList = repo.GetAll().Where(p => p.Name.Contains(name)).ToList();
            if (searchList.Count != 0)
            {     
                ViewData["count"] = searchList.Count; // Số lượng bản ghi đã được tìm thấy
                return View(searchList);
            }
            else return View(data);
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
        public IActionResult Details(Guid id) // Details
        {
            var user = repo.GetByID(id);
            return View(user);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Lấy ra user có thông tin trùng với username và password được nhập vào
            var user = repo.GetAll().FirstOrDefault(p => p.UserName == username && p.Password == password);
            if (user != null)
            {
                TempData["Username"] = username;
                return RedirectToAction("Index", "User");
            }
            else return Content("Đăng nhập thất bại");
        }
    }
}
