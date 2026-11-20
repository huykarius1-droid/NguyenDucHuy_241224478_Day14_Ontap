using Microsoft.AspNetCore.Mvc;
using NguyenDucHuy_241224478.Models;
namespace NguyenDucHuy_241224478.Components
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly QLNhaSachContext _db;

        public TheLoaiMenuViewComponent(QLNhaSachContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.TheLoais.ToList());

        }
    }
}
