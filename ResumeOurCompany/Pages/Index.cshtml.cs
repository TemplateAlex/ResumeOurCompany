using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeOurCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace ResumeOurCompany.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HRDBContext _context;

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public DateTime Date { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HRDBContext db)
        {
            _logger = logger;
            _context = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            Recruit recruit = new Recruit();
            recruit.Author = this.Name;
            recruit.Message = this.Message;
            recruit.Date = this.Date;
            recruit.Email = this.Email;

            _context.Recruits.Add(recruit);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}