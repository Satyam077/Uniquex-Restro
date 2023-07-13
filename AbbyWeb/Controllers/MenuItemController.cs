using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AbbyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) { 

            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var menuItemList = _unitOfWork.MenuItem.GetAll(includeproperties: "Category,FoodType");
            return Json(new { data = menuItemList });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromdb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
            //delete old image
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromdb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath)) 
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.MenuItem.Remove(objFromdb);
            _unitOfWork.Save();
            return Json(new {success = true, message="Deleted Succesfully"});
        }
    }
}
