using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinalAssignment.DataLayer;
using FinalAssignment.DataLayer.Entiry;
using FinalAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FinalAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        readonly DataContext _dataContext;
        public EmployeeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string AddDamedata()
        {
            String[] states = new String[] { "Andhra Pradesh", "Arunachal Pradesh","Bihar", "Chhattisgarh" };
            foreach(var item in states)
            {
                State state = new State() { StateName=item};
                _dataContext.Add(state);
                _dataContext.SaveChanges();
            }
            String[][] citys = new String[][]
            {
                new String[]{ "Visakhapatnam","Vijayawada","Guntur","Nellore","Kurnool","Kadapa"},
                new String[] { "Anjaw", "Changlang", "Lohit", "Tawang"},
                new String[]{ "Arwal","Araria","Bhojpur","Buxar","Nawada","Patna"},
                new String[] { "Raipur", "Bilaspur", "Jagdalpur", "Ambikapur" }
            };
            for (int i = 0; i < citys.Length; i++)
            {
                foreach (var item in citys[i])
                {
                    City city = new City() { CityName = item, StateId = i + 1 };
                    _dataContext.Add(city);
                    _dataContext.SaveChanges();
                }
            }
            String[] departments = new String[] { "IT", "Admin", "HR", "QA", "BA", "CS" };
            foreach (var item in departments)
            {
                Department department = new Department() { DepartmentName = item };
                _dataContext.Add(department);
                _dataContext.SaveChanges();
            }
            return "done";
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewBag.States = _dataContext.States.Select(item => new SelectListItem() { Text = item.StateName, Value = item.StateId + "", Selected = false }).ToList();
            ViewBag.Departments = _dataContext.Departments.Select(item => new SelectListItem() { Text = item.DepartmentName, Value = item.DepartmentId.ToString(), Selected = false }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel model)
        {
            Employee employee = new Employee();
            employee.EmployeeId = model.EmployeeId;
            employee.EmployeeName = model.EmployeeName;
            employee.DateOfBirth = model.DateOfBirth;
            employee.PhoneNumber = model.PhoneNumber.Replace(" ","").Replace("(","").Replace(")","");
            employee.Email = model.Email;
            employee.DepartmentId = model.DepartmentId;
            employee.Address = model.Address;
            employee.CityId = model.CityId;
            employee.Zip = model.Zip.Replace(" ","");
            employee.JoiningDate = model.JoiningDate;
            employee.LastModificationDate = employee.CreationDate = DateTime.Now;
            _dataContext.Add(employee);
            _dataContext.SaveChanges();
            List<EmployeeModel> employeesModel = GetEmployees();
            ViewBag.message = "Data Inserted Successfully";
            return View("Employees", employeesModel);
        }
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var employee = _dataContext.Employees.Find(id);
            var city = _dataContext.Cities.Find(employee.CityId);
            ViewBag.States = _dataContext.States.Select(item => new SelectListItem() { Text = item.StateName, Value = item.StateId + "", Selected = false }).ToList();
            ViewBag.Departments = _dataContext.Departments.Select(item => new SelectListItem() { Text = item.DepartmentName, Value = item.DepartmentId.ToString(), Selected = false }).ToList();
            ViewBag.Cities = _dataContext.Cities.Where(x=>x.StateId==city.StateId).Select(item => new SelectListItem() { Text = item.CityName, Value = item.CityId.ToString(), Selected = false }).ToList();
            EmployeeModel employeeModel = new EmployeeModel() {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId,
                Address = employee.Address,
                StateId = city.StateId,
                CityId = employee.CityId,
                Zip = employee.Zip,
                JoiningDate = employee.JoiningDate
            };
            
            if (employee.LeavingDate.ToString("yyyy") != "0001")
            {
                employeeModel.LeavingDate = employee.LeavingDate;
            }
            return View(employeeModel);
        }
        [HttpPost]
        public IActionResult EditEmployee(EmployeeModel model)
        {
            Employee employee = _dataContext.Employees.Find(model.EmployeeId);
            employee.EmployeeId = model.EmployeeId;
            employee.EmployeeName = model.EmployeeName;
            employee.DateOfBirth = model.DateOfBirth;
            employee.PhoneNumber = model.PhoneNumber.Replace(" ", "").Replace("(", "").Replace(")", "");
            employee.Email = model.Email;
            employee.DepartmentId = model.DepartmentId;
            employee.Address = model.Address;
            employee.CityId = model.CityId;
            employee.Zip = model.Zip.Replace(" ", "");
            employee.JoiningDate = model.JoiningDate;
            if (model.LeavingDate == null)
            {
                employee.LeavingDate = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                employee.LeavingDate = (DateTime)model.LeavingDate;
            }
            employee.LastModificationDate = DateTime.Now;
            _dataContext.SaveChanges();

            List<EmployeeModel> employeesModel = GetEmployees();
            ViewBag.message = "Update Successfully";
            return View("Employees",employeesModel);
        }
        [HttpGet]
        public IActionResult Employees()
        {
            List<EmployeeModel> employeesModel = GetEmployees();
            return View(employeesModel);
        }
        public IActionResult DeleteEmployee(int id)
        {
            _dataContext.Remove(_dataContext.Employees.Find(id));
            _dataContext.SaveChanges();
            List<EmployeeModel> employeesModel = GetEmployees();
            ViewBag.message = "Data Deleted Successfully";
            return View("Employees", employeesModel);
        }
        public IActionResult AddAppraisal()
        {
            List<Employee> employee = new List<Employee>();
            foreach (var item in _dataContext.Employees.Where(e => e.JoiningDate.Year < DateTime.Today.Year).ToList())
            {
                var lastAppraisal = _dataContext.Appraisals.Where(x => x.EmployeeId == item.EmployeeId).OrderByDescending(x => x.NextAppraisal).FirstOrDefault();
                if (lastAppraisal==null ||(( lastAppraisal.NextAppraisal.Month < DateTime.Today.Month || lastAppraisal.NextAppraisal.Year < DateTime.Today.Year ) && (lastAppraisal.NextAppraisal.Month > DateTime.Today.Month || lastAppraisal.NextAppraisal.Year <= DateTime.Today.Year)))
                {
                    employee.Add(item);
                }
            }
            ViewBag.employees = employee.Select(item => new SelectListItem() { Text = item.EmployeeName, Value = item.EmployeeId + "", Selected = false }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddAppraisal(AppraisalModel model,List<IFormFile> files)
        {
            Appraisal appraisal= new Appraisal();
            appraisal.EmployeeId = model.EmployeeId;
            appraisal.CurrentAppraisal = model.CurrentAppraisal;
            appraisal.NextAppraisal = model.NextAppraisal;
            appraisal.Remark = model.Remark;
            model.AllFiles = "";
            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                    continue;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", Path.GetFileName(file.FileName));
                file.CopyToAsync(new FileStream(path, FileMode.Create));
                model.AllFiles += Path.GetFileName(file.FileName);
            }
            appraisal.FilesName = model.AllFiles;
            _dataContext.Add(appraisal);
            _dataContext.SaveChanges();
            return RedirectToAction("Appraisals");
        }
        public IActionResult Appraisals()
        {
            List<AppraisalModel> models = new List<AppraisalModel>();
            foreach (var item in _dataContext.Appraisals.Join(_dataContext.Employees, a => a.EmployeeId, e => e.EmployeeId, (a, e) => new { Appraisal = a, Employee = e }).OrderByDescending(x => x.Appraisal.CurrentAppraisal))
            {
                AppraisalModel appraisalModel = new AppraisalModel();
                appraisalModel.AppraisalId = item.Appraisal.AppraisalId;
                appraisalModel.EmployeeId = item.Appraisal.EmployeeId;
                appraisalModel.EmployeeName = item.Employee.EmployeeName;
                appraisalModel.CurrentAppraisal = item.Appraisal.CurrentAppraisal;
                appraisalModel.NextAppraisal = item.Appraisal.NextAppraisal;
                appraisalModel.Remark = item.Appraisal.Remark;
                models.Add(appraisalModel);
            }
            return View(models);
        }
        public IActionResult AppraisalDetails(int id)
        {
            ViewBag.employees = _dataContext.Employees.Select(item => new SelectListItem() { Text = item.EmployeeName, Value = item.EmployeeId + "", Selected = false }).ToList();
            var appraisal = _dataContext.Appraisals.Find(id);
            AppraisalModel selectedAppraisal = new AppraisalModel();
            selectedAppraisal.EmployeeId = appraisal.EmployeeId;
            selectedAppraisal.CurrentAppraisal = appraisal.CurrentAppraisal;
            selectedAppraisal.NextAppraisal = appraisal.NextAppraisal;
            selectedAppraisal.Files = appraisal.FilesName.Split(',');
            selectedAppraisal.Remark = appraisal.Remark;
            ViewBag.history = _dataContext.Appraisals.Where(x => x.EmployeeId == appraisal.EmployeeId).OrderByDescending(x=>x.CurrentAppraisal).ToList();
            return View(selectedAppraisal);
        }
        public string GetCity(int id)
        {
            return JsonConvert.SerializeObject(_dataContext.Cities.Where(x => x.StateId == id));
        }
        public IActionResult Error()
        {
            return View();
        }
        public List<EmployeeModel> GetEmployees()
        {
            var employees = _dataContext.Employees.Join(_dataContext.Departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new { Employee = e, Department = d }).Join(_dataContext.Cities.Join(_dataContext.States, c => c.StateId, s => s.StateId, (c, s) => new { City = c, State = s }), ed => ed.Employee.CityId, cs => cs.City.CityId, (ed, cs) => new { EmpDep = ed, CS = cs }).OrderByDescending(x => x.EmpDep.Employee.JoiningDate);
            List<EmployeeModel> employeesModel = new List<EmployeeModel>();
            foreach (var item in employees)
            {
                EmployeeModel model = new EmployeeModel() { EmployeeId = item.EmpDep.Employee.EmployeeId, EmployeeName = item.EmpDep.Employee.EmployeeName, Age = DateTime.Today.Year - item.EmpDep.Employee.DateOfBirth.Year, Email = item.EmpDep.Employee.Email, PhoneNumber = item.EmpDep.Employee.PhoneNumber, Departdment = item.EmpDep.Department.DepartmentName, City = item.CS.City.CityName, State = item.CS.State.StateName, JoiningDate = item.EmpDep.Employee.JoiningDate };
                if (item.EmpDep.Employee.LeavingDate.ToString("yyyy") == "0001")
                {
                    model.Status = "Y";
                }
                else
                {
                    model.Status = "N";
                }
                employeesModel.Add(model);
            }
            return employeesModel;

        }

        public string TestInsert()
        {
            var test1Model = new Test1()
            {
                Name = "product1",
                Test2s = new List<Test2>()
            };
            for(int i = 0; i < 3; i++)
            {
                var test2Model = new Test2() {
                    Name = "product Variant ." + i
                };
                test1Model.Test2s.Add(test2Model);
            }
            _dataContext.Add(test1Model);
            _dataContext.SaveChanges();
            return "test";
        }
        public string TestUpdate()
        {
            var test1Model = _dataContext.Test1s.Find(1);
            _dataContext.Entry(test1Model).Collection(s => s.Test2s).Load();
            test1Model.Name = "update test";
            foreach(var item in test1Model.Test2s)
            {
                item.Name = "update test 1";
            }
            var test2NewModel = new Test2
            {
                Name = "new Inserted row 2"
            };
            test1Model.Test2s.Add(test2NewModel);
            _dataContext.Update(test1Model);
            _dataContext.SaveChanges();
            return "test";
        }
    }
}