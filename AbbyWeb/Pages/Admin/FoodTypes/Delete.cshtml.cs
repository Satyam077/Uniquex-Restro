
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public FoodType FoodType { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            FoodType = _db.FoodType.Find(id);
        }

        public async Task<IActionResult> OnPost( )
        {
                    
                var categoryFromDb = _db.FoodType.Find(FoodType.Id);
                if(categoryFromDb != null)
                {
                    _db.FoodType.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "FoodType deleted Successfully";
                    return RedirectToPage("Index");
                }
                return Page();          
        }
    }
}
