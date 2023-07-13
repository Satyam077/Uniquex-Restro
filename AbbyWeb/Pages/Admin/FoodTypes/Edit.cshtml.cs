
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost(FoodType foodType)
        {
          
            if(ModelState.IsValid)
            {
                _unitOfWork.FoodType.Update(foodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}
