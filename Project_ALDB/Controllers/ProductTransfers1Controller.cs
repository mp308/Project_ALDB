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
    public class ProductTransfers1Controller : Controller
    {
        private readonly ALDBContext _context;

        public ProductTransfers1Controller(ALDBContext context)
        {
            _context = context;
        }

        // GET: ProductTransfers1
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductTransfer.ToListAsync());
        }

        // GET: ProductTransfers1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTransfer = await _context.ProductTransfer
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productTransfer == null)
            {
                return NotFound();
            }

            return View(productTransfer);
        }

        // GET: ProductTransfers1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTransfers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,CategoryID,Unit,Price,Quantity,CustomerID,ContactCusPhoneNum,ShippingName,Address,City,State,PostalCode,SaleRespEmployeeNumber")] ProductTransfer productTransfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTransfer);
        }

        // GET: ProductTransfers1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTransfer = await _context.ProductTransfer.FindAsync(id);
            if (productTransfer == null)
            {
                return NotFound();
            }
            return View(productTransfer);
        }

        // POST: ProductTransfers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,CategoryID,Unit,Price,Quantity,CustomerID,ContactCusPhoneNum,ShippingName,Address,City,State,PostalCode,SaleRespEmployeeNumber")] ProductTransfer productTransfer)
        {
            if (id != productTransfer.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTransfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTransferExists(productTransfer.ProductID))
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
            return View(productTransfer);
        }

        // GET: ProductTransfers1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTransfer = await _context.ProductTransfer
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productTransfer == null)
            {
                return NotFound();
            }

            return View(productTransfer);
        }

        // POST: ProductTransfers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTransfer = await _context.ProductTransfer.FindAsync(id);
            if (productTransfer != null)
            {
                _context.ProductTransfer.Remove(productTransfer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTransferExists(int id)
        {
            return _context.ProductTransfer.Any(e => e.ProductID == id);
        }
    }
}
