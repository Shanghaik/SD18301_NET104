using AppData.Models;
using AppData.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            // Lấy dữ liệu từ session
            var user = HttpContext.Session.GetString("user");
            if(user == null)
            {
                ViewData["message"] = "Session không tồm tại hoặc đã timeout";
            }else
            {
                ViewData["message"] = $"Hello xin chào {user}";
            }
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
            // HttpContext.Session.Clear(); // Xóa dữ liệu phiên làm việc
            var deleteData = JsonConvert.SerializeObject(user);
            HttpContext.Session.SetString("deleted", deleteData);
            repo.DeleteObj(user);
            return RedirectToAction("Index");
        }
        public IActionResult RollBack()
        {
            var jsonData = HttpContext.Session.GetString("deleted");
            if(jsonData == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var deletedData = JsonConvert.DeserializeObject<User>(jsonData);
                repo.CreateObj(deletedData);
                return RedirectToAction("Index");
            }  
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
                // Thêm username vào session có key là user
                HttpContext.Session.SetString("user", username);
                // Lấy dữ liệu ra 
                var data = HttpContext.Session.GetString("user");
                // TempData["Username"] = username;
                // Sửa dụng session để lưu dữ liệu đăng nhập của user
                return RedirectToAction("Index", "User");
            }
            else return Content("Đăng nhập thất bại");
        }
    }
}
