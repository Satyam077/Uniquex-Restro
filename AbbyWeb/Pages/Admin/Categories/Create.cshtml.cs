using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
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
                await _db.Category.AddAsync(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}
