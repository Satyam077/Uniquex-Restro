
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public FoodType FoodType { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            FoodType = _db.FoodType.Find(id);
        }

        public async Task<IActionResult> OnPost(FoodType foodType)
        {
          
            if(ModelState.IsValid)
            {
                 _db.FoodType.Update(foodType);
                await _db.SaveChangesAsync();
                TempData["success"] = "FoodType updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}
