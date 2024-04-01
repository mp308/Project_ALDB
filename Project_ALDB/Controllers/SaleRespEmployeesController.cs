using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_ALDB.Data;
using Project_ALDB.Models;

namespace Project_ALDB.Controllers
{
    public class SaleRespEmployeesController : Controller
    {
        private readonly ALDBContext _context;

        public SaleRespEmployeesController(ALDBContext context)
        {
            _context = context;
        }

        // GET: SaleRespEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleRespEmployee.ToListAsync());
        }

        // GET: SaleRespEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRespEmployee = await _context.SaleRespEmployee
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (saleRespEmployee == null)
            {
                return NotFound();
            }

            return View(saleRespEmployee);
        }

        // GET: SaleRespEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleRespEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNumber,FirstName,LastName,Email,Phone,Department,HireDate,Salary")] SaleRespEmployee saleRespEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleRespEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleRespEmployee);
        }

        // GET: SaleRespEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRespEmployee = await _context.SaleRespEmployee.FindAsync(id);
            if (saleRespEmployee == null)
            {
                return NotFound();
            }
            return View(saleRespEmployee);
        }

        // POST: SaleRespEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeNumber,FirstName,LastName,Email,Phone,Department,HireDate,Salary")] SaleRespEmployee saleRespEmployee)
        {
            if (id != saleRespEmployee.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleRespEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleRespEmployeeExists(saleRespEmployee.EmployeeNumber))
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
            return View(saleRespEmployee);
        }

        // GET: SaleRespEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRespEmployee = await _context.SaleRespEmployee
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (saleRespEmployee == null)
            {
                return NotFound();
            }

            return View(saleRespEmployee);
        }

        // POST: SaleRespEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleRespEmployee = await _context.SaleRespEmployee.FindAsync(id);
            if (saleRespEmployee != null)
            {
                _context.SaleRespEmployee.Remove(saleRespEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleRespEmployeeExists(int id)
        {
            return _context.SaleRespEmployee.Any(e => e.EmployeeNumber == id);
        }
    }
}
