using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly RazorApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(RazorApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost(int? id)
        {
            Category obj = _db.Categories.Find(Category.Id);

            if (Category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Succesfully";
            return RedirectToPage("Index");
        }
        
    }
}
