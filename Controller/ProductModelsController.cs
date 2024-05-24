//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using optimization.Models;

//namespace optimization.Controller
//{
//    public class ProductModelsController : Controller
//    {
//        private readonly optimizationContext _context;

//        public ProductModelsController(optimizationContext context)
//        {
//            _context = context;
//        }

//        // GET: ProductModels
//        public async Task<IActionResult> Index()
//        {
//              return _context.ProductModel != null ? 
//                          View(await _context.ProductModel.ToListAsync()) :
//                          Problem("Entity set 'optimizationContext.ProductModel'  is null.");
//        }

//        // GET: ProductModels/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.ProductModel == null)
//            {
//                return NotFound();
//            }

//            var productModel = await _context.ProductModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (productModel == null)
//            {
//                return NotFound();
//            }

//            return View(productModel);
//        }

//        // GET: ProductModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ProductModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,BranchID,Name,Price,Amount")] ProductModel productModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(productModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(productModel);
//        }

//        // GET: ProductModels/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.ProductModel == null)
//            {
//                return NotFound();
//            }

//            var productModel = await _context.ProductModel.FindAsync(id);
//            if (productModel == null)
//            {
//                return NotFound();
//            }
//            return View(productModel);
//        }

//        // POST: ProductModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int? id, [Bind("ID,BranchID,Name,Price,Amount")] ProductModel productModel)
//        {
//            if (id != productModel.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(productModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ProductModelExists(productModel.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(productModel);
//        }

//        // GET: ProductModels/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.ProductModel == null)
//            {
//                return NotFound();
//            }

//            var productModel = await _context.ProductModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (productModel == null)
//            {
//                return NotFound();
//            }

//            return View(productModel);
//        }

//        // POST: ProductModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int? id)
//        {
//            if (_context.ProductModel == null)
//            {
//                return Problem("Entity set 'optimizationContext.ProductModel'  is null.");
//            }
//            var productModel = await _context.ProductModel.FindAsync(id);
//            if (productModel != null)
//            {
//                _context.ProductModel.Remove(productModel);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ProductModelExists(int? id)
//        {
//          return (_context.ProductModel?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
