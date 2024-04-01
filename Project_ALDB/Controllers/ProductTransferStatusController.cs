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
    public class ProductTransferStatusController : Controller
    {
        private readonly ALDBContext _context;

        public ProductTransferStatusController(ALDBContext context)
        {
            _context = context;
        }

        // GET: ProductTransferStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductTransferStatus.ToListAsync());
        }

        // GET: ProductTransferStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTransferStatus = await _context.ProductTransferStatus
                .FirstOrDefaultAsync(m => m.TransferID == id);
            if (productTransferStatus == null)
            {
                return NotFound();
            }

            return View(productTransferStatus);
        }

        // GET: ProductTransferStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTransferStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransferID,ProductID,Status,DateTransferred")] ProductTransferStatus productTransferStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTransferStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTransferStatus);
        }

        // GET: ProductTransferStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTransferStatus = await _context.ProductTransferStatus.FindAsync(id);
            if (productTransferStatus == null)
            {
                return NotFound();
            }
            return View(productTransferStatus);
        }

        // POST: ProductTransferStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransferID,ProductID,Status,DateTransferred")] ProductTransferStatus productTransferStatus)
        {
            if (id != productTransferStatus.TransferID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTransferStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTransferStatusExists(productTransferStatus.TransferID))
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
            return View(productTransferStatus);
        }

        // GET: ProductTransferStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTransferStatus = await _context.ProductTransferStatus
                .FirstOrDefaultAsync(m => m.TransferID == id);
            if (productTransferStatus == null)
            {
                return NotFound();
            }

            return View(productTransferStatus);
        }

        // POST: ProductTransferStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTransferStatus = await _context.ProductTransferStatus.FindAsync(id);
            if (productTransferStatus != null)
            {
                _context.ProductTransferStatus.Remove(productTransferStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTransferStatusExists(int id)
        {
            return _context.ProductTransferStatus.Any(e => e.TransferID == id);
        }
    }
}
