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
//    public class EmployeeModelsController : Controller
//    {
//        private readonly optimizationContext _context;

//        public EmployeeModelsController(optimizationContext context)
//        {
//            _context = context;
//        }

//        // GET: EmployeeModels
//        public async Task<IActionResult> Index()
//        {
//              return _context.EmployeeModel != null ? 
//                          View(await _context.EmployeeModel.ToListAsync()) :
//                          Problem("Entity set 'optimizationContext.EmployeeModel'  is null.");
//        }

//        // GET: EmployeeModels/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.EmployeeModel == null)
//            {
//                return NotFound();
//            }

//            var employeeModel = await _context.EmployeeModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (employeeModel == null)
//            {
//                return NotFound();
//            }

//            return View(employeeModel);
//        }

//        // GET: EmployeeModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: EmployeeModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,BranchID,Password,ConfirmPassword,Email")] EmployeeModel employeeModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(employeeModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(employeeModel);
//        }

//        // GET: EmployeeModels/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.EmployeeModel == null)
//            {
//                return NotFound();
//            }

//            var employeeModel = await _context.EmployeeModel.FindAsync(id);
//            if (employeeModel == null)
//            {
//                return NotFound();
//            }
//            return View(employeeModel);
//        }

//        // POST: EmployeeModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int? id, [Bind("ID,BranchID,Password,ConfirmPassword,Email")] EmployeeModel employeeModel)
//        {
//            if (id != employeeModel.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(employeeModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!EmployeeModelExists(employeeModel.ID))
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
//            return View(employeeModel);
//        }

//        // GET: EmployeeModels/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.EmployeeModel == null)
//            {
//                return NotFound();
//            }

//            var employeeModel = await _context.EmployeeModel
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (employeeModel == null)
//            {
//                return NotFound();
//            }

//            return View(employeeModel);
//        }

//        // POST: EmployeeModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int? id)
//        {
//            if (_context.EmployeeModel == null)
//            {
//                return Problem("Entity set 'optimizationContext.EmployeeModel'  is null.");
//            }
//            var employeeModel = await _context.EmployeeModel.FindAsync(id);
//            if (employeeModel != null)
//            {
//                _context.EmployeeModel.Remove(employeeModel);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool EmployeeModelExists(int? id)
//        {
//          return (_context.EmployeeModel?.Any(e => e.ID == id)).GetValueOrDefault();
//        }
//    }
//}
