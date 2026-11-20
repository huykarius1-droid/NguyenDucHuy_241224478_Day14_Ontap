
using Microsoft.AspNetCore.Mvc;
using NguyenDucHuy_241224478.Models;
using System.Diagnostics;

namespace NguyenDucHuy_241224478.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _db;

        public HomeController(QLNhaSachContext db)
        {
            _db = db;
        }

        // Câu 3: Hiển thị danh sách sách có giá >= 100
        public IActionResult Index()
        {
            var vm = new DanhSachSachVM
            {
                TieuDe = "Nguyễn Đức Huy",
                Sachs = _db.Saches
                    .Where(s => s.Gia != null && s.Gia >= 100)
                    .ToList()
            };

            return View(vm);
        }

        // Câu 4: Hiển thị sách theo thể loại
        public IActionResult SachTheoTheLoai(int id)
        {
            var tl = _db.TheLoais.Find(id);

            if (tl == null)
                return NotFound();

            var vm = new DanhSachSachVM
            {
                TieuDe = tl.TenTl,
                Sachs = _db.Saches
                    .Where(s => s.MaTl == id && s.Gia != null)
                    .ToList()
            };

            return PartialView("NguyenVanAn_MainContent", vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
