using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(FoodType foodType)
        {
            
            if(ModelState.IsValid)
            {
                _unitOfWork.FoodType.Add(foodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}
