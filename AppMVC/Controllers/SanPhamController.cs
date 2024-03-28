using AppData.Models;
using AppData.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class SanPhamController : Controller
    {
        SD18301_NET104Context context;
        AllRepository<SanPham> repo;
        public SanPhamController()
        {
            context = new SD18301_NET104Context();
            repo= new AllRepository<SanPham>(context, context.SanPham);
        }
        // GET: SanPhamController
        public ActionResult Index()
        {
            var allSanPham = repo.GetAll();
            return View(allSanPham);
        }

        // GET: SanPhamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SanPhamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        public ActionResult Create(SanPham sp, IFormFile imgFile)
        {
           // Thực hiện tạo 1 đường dẫn để trỏ tới thư mục wwwroot - nơi chứa ảnh
           var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
            // vd kết quả thu được sẽ có dạng wwwroot/img/concho.png;
            // Copy ảnh tải lên vào thư mục root
            var stream = new FileStream(path, FileMode.Create); 
            imgFile.CopyTo(stream); // Copy cái ảnh mà được các bạn chọn vào cái stream đó
            // Cập nhật đường dẫn ảnh 
            sp.ImgUrl = imgFile.FileName;
            repo.CreateObj(sp); // tạo sản phẩm với đường dẫn ảnh
            return RedirectToAction("Index");
        } // Crit

        // GET: SanPhamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPhamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
