using Ark.CrossCutting.Classes;
using Ark.Domain.Enumerators;
using Ark.Domain.Models.Entities.Interno;
using ArkServer.WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArkServer.WebApp.Controllers
{
    [Authorize]
    [Authorize(Roles = "USER_SYSTEM")]
    public class EmailSistemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailSistemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmailSistemas
        public async Task<IActionResult> Index()
        {
              return _context.emails != null ? 
                          View(await _context.emails.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.emails'  is null.");
        }

        // GET: EmailSistemas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.emails == null)
            {
                return NotFound();
            }

            var emailSistema = await _context.emails
                .FirstOrDefaultAsync(m => m.id == id);
            if (emailSistema == null)
            {
                return NotFound();
            }

            return View(emailSistema);
        }

        // GET: EmailSistemas/Create
        public IActionResult Create()
        {
            var tipoEmail = typeof(TypeEmailEnum).GetEnumValuesWithDescription<TypeEmailEnum>();
            ViewData["TipoEmailId"] = new SelectList(tipoEmail, "Key", "Value");
            return View();
        }

        // POST: EmailSistemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmailSistema emailSistema)
        {
            if (ModelState.IsValid)
            {
                emailSistema.id = Guid.NewGuid();
                _context.Add(emailSistema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var tipoEmail = typeof(TypeEmailEnum).GetEnumValuesWithDescription<TypeEmailEnum>();
            ViewData["TipoEmailId"] = new SelectList(tipoEmail, "Key", "Value", emailSistema.typeEmail);
            return View(emailSistema);
        }

        // GET: EmailSistemas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.emails == null)
            {
                return NotFound();
            }

            var emailSistema = await _context.emails.FindAsync(id);
            if (emailSistema == null)
            {
                return NotFound();
            }

            var tipoEmail = typeof(TypeEmailEnum).GetEnumValuesWithDescription<TypeEmailEnum>();
            ViewData["TipoEmailId"] = new SelectList(tipoEmail, "Key", "Value", emailSistema.typeEmail);
            return View(emailSistema);
        }

        // POST: EmailSistemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmailSistema emailSistema)
        {
            if (id != emailSistema.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailSistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailSistemaExists(emailSistema.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var tipoEmail = typeof(TypeEmailEnum).GetEnumValuesWithDescription<TypeEmailEnum>();
            ViewData["TipoEmailId"] = new SelectList(tipoEmail, "Key", "Value", emailSistema.typeEmail);
            return View(emailSistema);
        }

        // GET: EmailSistemas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.emails == null)
            {
                return NotFound();
            }

            var emailSistema = await _context.emails
                .FirstOrDefaultAsync(m => m.id == id);
            if (emailSistema == null)
            {
                return NotFound();
            }

            return View(emailSistema);
        }

        // POST: EmailSistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.emails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.emails'  is null.");
            }
            var emailSistema = await _context.emails.FindAsync(id);
            if (emailSistema != null)
            {
                _context.emails.Remove(emailSistema);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailSistemaExists(Guid id)
        {
          return (_context.emails?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
