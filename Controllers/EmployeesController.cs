using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADBMS.Models;

namespace ADBMS.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HRMSContext db;

        public EmployeesController(HRMSContext context)
        {
            db = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
              return View(await db.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Employees == null)
            {
                return NotFound();
            }

            var employee = await db.Employees
                .FirstOrDefaultAsync(m => m.Ssn == id);

            switch (employee.DeptNum)
            {
                case "1":
                    employee.DeptNum = "Services";
                    break;
                case "2":
                    employee.DeptNum = "Finance";
                    break;
                case "3":
                    employee.DeptNum = "Operations";
                    break;
                case "4":
                    employee.DeptNum = "HR";
                    break;
                case "5":
                    employee.DeptNum = "IT";
                    break;
                case "6":
                    employee.DeptNum = "BizOps";
                    break;
                case "7":
                    employee.DeptNum = "SecurityOperations";
                    break;
                case "8":
                    employee.DeptNum = "Other";
                    break;
            }

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DeptName"] = new SelectList(db.Departments, "DeptName", "DeptName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ssn,FirstName,MiddleName,LastName,Dob,EmpAddress,DeptNum")] Employee employee)
        {
            switch (employee.DeptNum)
            {
                case "Services":
                    employee.DeptNum = 1.ToString();
                    break;
                case "Finance":
                    employee.DeptNum = 2.ToString();
                    break;
                case "Operations":
                    employee.DeptNum = 3.ToString();
                    break;
                case "HR":
                    employee.DeptNum = 4.ToString();
                    break;
                case "IT":
                    employee.DeptNum = 5.ToString();
                    break;
                case "BizOps":
                    employee.DeptNum = 6.ToString();
                    break;
                case "SecurityOperations":
                    employee.DeptNum = 7.ToString();
                    break;
                case "Other":
                    employee.DeptNum = 8.ToString();
                    break;
            }
            var checkSSN = db.Employees.Where(x => x.Ssn == employee.Ssn).ToList();


            if (ModelState.IsValid)
            {
                try
                {
                    if (checkSSN is null)
                    {
                        db.Add(employee);
                        await db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                }

                catch(Exception)
                {
                    
                }

            }
            TempData["Failure"] = "User already exists!";
            return RedirectToAction("Index");
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Employees == null)
            {
                return NotFound();
            }

            var employee = await db.Employees.FindAsync(id);
            switch (employee.DeptNum)
            {
                case "1":
                    employee.DeptNum = "Services";
                    break;
                case "2":
                    employee.DeptNum = "Finance";
                    break;
                case "3":
                    employee.DeptNum = "Operations";
                    break;
                case "4":
                    employee.DeptNum = "HR";
                    break;
                case "5":
                    employee.DeptNum = "IT";
                    break;
                case "6":
                    employee.DeptNum = "BizOps";
                    break;
                case "7":
                    employee.DeptNum = "SecurityOperations";
                    break;
                case "8":
                    employee.DeptNum = "Other";
                    break;
            }
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["EmpDeptName"] = new SelectList(db.Departments, "DeptName", "DeptName");
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ssn,FirstName,MiddleName,LastName,Dob,EmpAddress,DeptNum")] Employee employee)
        {
            if (id != employee.Ssn)
            {
                return NotFound();
            }

            switch (employee.DeptNum)
            {
                case "Services":
                    employee.DeptNum = 1.ToString();
                    break;
                case "Finance":
                    employee.DeptNum = 2.ToString();
                    break;
                case "Operations":
                    employee.DeptNum = 3.ToString();
                    break;
                case "HR":
                    employee.DeptNum = 4.ToString();
                    break;
                case "IT":
                    employee.DeptNum = 5.ToString();
                    break;
                case "BizOps":
                    employee.DeptNum = 6.ToString();
                    break;
                case "SecurityOperations":
                    employee.DeptNum = 7.ToString();
                    break;
                case "Other":
                    employee.DeptNum = 8.ToString();
                    break;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(employee);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Ssn))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Employees == null)
            {
                return NotFound();
            }

            var employee = await db.Employees
                .FirstOrDefaultAsync(m => m.Ssn == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Employees == null)
            {
                return Problem("Entity set 'HRMSContext.Employees'  is null.");
            }
            var employee = await db.Employees.FindAsync(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return db.Employees.Any(e => e.Ssn == id);
        }
    }
}
