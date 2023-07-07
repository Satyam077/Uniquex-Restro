
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost(Category category)
        {
            //custom validations
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty ,"Can't be same as Name");
            }
            if(ModelState.IsValid)
            {
                 _db.Category.Update(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}
