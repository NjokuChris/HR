using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace HrUI.Areas.Admin.Controllers
{
    public class employeesController : Controller
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET: Admin/employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.bank).Include(e => e.comp_branch).Include(e => e.company).Include(e => e.department).Include(e => e.dept_units).Include(e => e.division).Include(e => e.employee_type).Include(e => e.grade_level).Include(e => e.job_title).Include(e => e.pen_providers);
            return View(employees.ToList());
        }

        // GET: Admin/employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Admin/employees/Create
        public ActionResult Create()
        {
            ViewBag.bank_id = new SelectList(db.banks, "bank_id", "bank_name");
            ViewBag.branch_id = new SelectList(db.comp_branch, "branch_id", "branch_name");
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company1");
            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name");
            ViewBag.dept_unit_id = new SelectList(db.dept_units, "dept_unit_id", "dept_unit");
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division1");
            ViewBag.employee_type_id = new SelectList(db.employee_type, "employee_type_id", "employee_type1");
            ViewBag.grade_level_id = new SelectList(db.grade_level, "level_id", "description");
            ViewBag.job_title_id = new SelectList(db.job_title, "job_title_id", "job_title1");
            ViewBag.pen_provider_id = new SelectList(db.pen_providers, "pen_provider_id", "pen_provider_name");
            return View();
        }

        // POST: Admin/employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employee_id,f_name,m_name,l_name,emp_name,title,employee_no,employee_type_id,department_id,dept_unit_id,division_id,job_title_id,grade_level_id,company_id,gender,hire_date,confirm_date,confirm_status,birth_date,H_address,phone_no,location,state_id,marital_status,state_origin_id,prob_period,bank_id,bank_acc_no,pen_provider_id,pen_pin,image,quali_summ,email,email2,wed_anni_date,no_child,hobby,branch_id,salary_annual")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bank_id = new SelectList(db.banks, "bank_id", "bank_name", employee.bank_id);
            ViewBag.branch_id = new SelectList(db.comp_branch, "branch_id", "branch_name", employee.branch_id);
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company1", employee.company_id);
            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name", employee.department_id);
            ViewBag.dept_unit_id = new SelectList(db.dept_units, "dept_unit_id", "dept_unit", employee.dept_unit_id);
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division1", employee.division_id);
            ViewBag.employee_type_id = new SelectList(db.employee_type, "employee_type_id", "employee_type1", employee.employee_type_id);
            ViewBag.grade_level_id = new SelectList(db.grade_level, "level_id", "description", employee.grade_level_id);
            ViewBag.job_title_id = new SelectList(db.job_title, "job_title_id", "job_title1", employee.job_title_id);
            ViewBag.pen_provider_id = new SelectList(db.pen_providers, "pen_provider_id", "pen_provider_name", employee.pen_provider_id);
            return View(employee);
        }

        // GET: Admin/employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.bank_id = new SelectList(db.banks, "bank_id", "bank_name", employee.bank_id);
            ViewBag.branch_id = new SelectList(db.comp_branch, "branch_id", "branch_name", employee.branch_id);
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company1", employee.company_id);
            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name", employee.department_id);
            ViewBag.dept_unit_id = new SelectList(db.dept_units, "dept_unit_id", "dept_unit", employee.dept_unit_id);
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division1", employee.division_id);
            ViewBag.employee_type_id = new SelectList(db.employee_type, "employee_type_id", "employee_type1", employee.employee_type_id);
            ViewBag.grade_level_id = new SelectList(db.grade_level, "level_id", "description", employee.grade_level_id);
            ViewBag.job_title_id = new SelectList(db.job_title, "job_title_id", "job_title1", employee.job_title_id);
            ViewBag.pen_provider_id = new SelectList(db.pen_providers, "pen_provider_id", "pen_provider_name", employee.pen_provider_id);
            return View(employee);
        }

        // POST: Admin/employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_id,f_name,m_name,l_name,emp_name,title,employee_no,employee_type_id,department_id,dept_unit_id,division_id,job_title_id,grade_level_id,company_id,gender,hire_date,confirm_date,confirm_status,birth_date,H_address,phone_no,location,state_id,marital_status,state_origin_id,prob_period,bank_id,bank_acc_no,pen_provider_id,pen_pin,image,quali_summ,email,email2,wed_anni_date,no_child,hobby,branch_id,salary_annual")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bank_id = new SelectList(db.banks, "bank_id", "bank_name", employee.bank_id);
            ViewBag.branch_id = new SelectList(db.comp_branch, "branch_id", "branch_name", employee.branch_id);
            ViewBag.company_id = new SelectList(db.companies, "company_id", "company1", employee.company_id);
            ViewBag.department_id = new SelectList(db.departments, "department_id", "department_name", employee.department_id);
            ViewBag.dept_unit_id = new SelectList(db.dept_units, "dept_unit_id", "dept_unit", employee.dept_unit_id);
            ViewBag.division_id = new SelectList(db.divisions, "division_id", "division1", employee.division_id);
            ViewBag.employee_type_id = new SelectList(db.employee_type, "employee_type_id", "employee_type1", employee.employee_type_id);
            ViewBag.grade_level_id = new SelectList(db.grade_level, "level_id", "description", employee.grade_level_id);
            ViewBag.job_title_id = new SelectList(db.job_title, "job_title_id", "job_title1", employee.job_title_id);
            ViewBag.pen_provider_id = new SelectList(db.pen_providers, "pen_provider_id", "pen_provider_name", employee.pen_provider_id);
            return View(employee);
        }

        // GET: Admin/employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Admin/employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
