using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammeManagementSystem.Data;
using ProgrammeManagementSystem.Models;

namespace ProgrammeManagementSystem.Controllers
{
    public class ModuleAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModuleAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ModuleAssignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ModuleAssignments.Include(m => m.Lecturer).Include(m => m.Module);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ModuleAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleAssignment = await _context.ModuleAssignments
                .Include(m => m.Lecturer)
                .Include(m => m.Module)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (moduleAssignment == null)
            {
                return NotFound();
            }

            return View(moduleAssignment);
        }

        // GET: ModuleAssignments/Create
        public IActionResult Create()
        {
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID");
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "ModuleID");
            return View();
        }

        // POST: ModuleAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentID,LecturerID,ModuleID")] ModuleAssignment moduleAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moduleAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID", moduleAssignment.LecturerID);
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "ModuleID", moduleAssignment.ModuleID);
            return View(moduleAssignment);
        }

        // GET: ModuleAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleAssignment = await _context.ModuleAssignments.FindAsync(id);
            if (moduleAssignment == null)
            {
                return NotFound();
            }
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID", moduleAssignment.LecturerID);
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "ModuleID", moduleAssignment.ModuleID);
            return View(moduleAssignment);
        }

        // POST: ModuleAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentID,LecturerID,ModuleID")] ModuleAssignment moduleAssignment)
        {
            if (id != moduleAssignment.AssignmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moduleAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleAssignmentExists(moduleAssignment.AssignmentID))
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
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID", moduleAssignment.LecturerID);
            ViewData["ModuleID"] = new SelectList(_context.Modules, "ModuleID", "ModuleID", moduleAssignment.ModuleID);
            return View(moduleAssignment);
        }

        // GET: ModuleAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moduleAssignment = await _context.ModuleAssignments
                .Include(m => m.Lecturer)
                .Include(m => m.Module)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (moduleAssignment == null)
            {
                return NotFound();
            }

            return View(moduleAssignment);
        }

        // POST: ModuleAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moduleAssignment = await _context.ModuleAssignments.FindAsync(id);
            if (moduleAssignment != null)
            {
                _context.ModuleAssignments.Remove(moduleAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleAssignmentExists(int id)
        {
            return _context.ModuleAssignments.Any(e => e.AssignmentID == id);
        }
    }
}
