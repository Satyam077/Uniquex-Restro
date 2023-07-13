
using Abby.DataAccess.Data;
using Abby.DataAccess.Migrations;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost( )
        {
                    
                var categoryFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
                if (categoryFromDb != null)
                {
                    _unitOfWork.FoodType.Remove(categoryFromDb);
                    _unitOfWork.Save();
                    TempData["success"] = "FoodType deleted Successfully";
                    return RedirectToPage("Index");
                }
                return Page();          
        }
    }
}
