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
//    public class BranchModelsController : Controller
//    {
//        private readonly optimizationContext _context;

//        public BranchModelsController(optimizationContext context)
//        {
//            _context = context;
//        }

//        // GET: BranchModels
//        public async Task<IActionResult> Index()
//        {
//            return _context.BranchModel != null ?
//                        View(await _context.BranchModel.ToListAsync()) :
//                        Problem("Entity set 'optimizationContext.BranchModel'  is null.");
//        }

//        // GET: BranchModels/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.BranchModel == null)
//            {
//                return NotFound();
//            }

//            var branchModel = await _context.BranchModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (branchModel == null)
//            {
//                return NotFound();
//            }

//            return View(branchModel);
//        }

//        // GET: BranchModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: BranchModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,Address,Name,PhoneNumber")] BranchModel branchModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(branchModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(branchModel);
//        }

//        // GET: BranchModels/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.BranchModel == null)
//            {
//                return NotFound();
//            }

//            var branchModel = await _context.BranchModel.FindAsync(id);
//            if (branchModel == null)
//            {
//                return NotFound();
//            }
//            return View(branchModel);
//        }

//        // POST: BranchModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int? id, [Bind("ID,Address,Name,PhoneNumber")] BranchModel branchModel)
//        {
//            if (id != branchModel.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(branchModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!BranchModelExists(branchModel.ID))
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
//            return View(branchModel);
//        }

//        // GET: BranchModels/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.BranchModel == null)
//            {
//                return NotFound();
//            }

//            var branchModel = await _context.BranchModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (branchModel == null)
//            {
//                return NotFound();
//            }

//            return View(branchModel);
//        }

//        // POST: BranchModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int? id)
//        {
//            if (_context.BranchModel == null)
//            {
//                return Problem("Entity set 'optimizationContext.BranchModel'  is null.");
//            }
//            var branchModel = await _context.BranchModel.FindAsync(id);
//            if (branchModel != null)
//            {
//                _context.BranchModel.Remove(branchModel);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool BranchModelExists(int? id)
//        {
//            return (_context.BranchModel?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
