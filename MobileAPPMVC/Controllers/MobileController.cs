using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Controllers
{
    public class MobileController : Controller
    {
        public IActionResult Index()
        {
            IMobileRepository _employeeRepository;
            IManufacturerRepository _manufacturerRepository;
            public MobileController(IMobileRepository mobileRepository, IManufacturerRepository manufacturerRepository)
            {
                _mobileRepository = mobileRepository;
                _manufacturerRepository = manufacturerRepository;
            }
            public IActionResult Index()
            {
                var mobiles = _mobileRepository.GetAllmobiles();
                return View(employees);
            }


            public IActionResult AddEmployee()
            {
                var addEmployeeViewModel = new AddEmployeeViewModel();

                //Returns the List<Department> from the DB.
                var departments = _departmentRepository.GetAllDepartments();
                List<SelectListItem> departmentSelectListItems = new List<SelectListItem>();


                foreach (var dept in departments)
                {
                    // Creating a list of SelectListItem inorder to bind the data to a select tag in the view.
                    departmentSelectListItems.Add(new SelectListItem { Text = dept.DepartmentName, Value = dept.DepartmentId.ToString() });
                }

                //This code will insert a default selected item as --Select Department-- in the UI.          
                departmentSelectListItems.Insert(0, new SelectListItem { Text = "--Select-Department", Value = string.Empty });

                //Binding the List<SelectListItem> in the DepartmentList field.
                addEmployeeViewModel.DepartmentList = departmentSelectListItems;

                return View(addEmployeeViewModel);

        }
    }
}
