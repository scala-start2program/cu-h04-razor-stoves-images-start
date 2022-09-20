using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Wba.StovePalace.Data;
using Wba.StovePalace.Models;

namespace Wba.StovePalace.Pages.Stoves
{
    public class DetailsModel : PageModel
    {
        private readonly Wba.StovePalace.Data.StoveContext _context;

        public DetailsModel(Wba.StovePalace.Data.StoveContext context)
        {
            _context = context;
        }

      public Stove Stove { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stove == null)
            {
                return NotFound();
            }

            var stove = await _context.Stove.FirstOrDefaultAsync(m => m.Id == id);
            if (stove == null)
            {
                return NotFound();
            }
            else 
            {
                Stove = stove;
            }
            return Page();
        }
    }
}
