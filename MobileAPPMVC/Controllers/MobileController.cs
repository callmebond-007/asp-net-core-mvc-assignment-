using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAPPMVC.Models;
using MobileAPPMVC.Repository;
using MobileAPPMVC.ViewModels.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Controllers
{
    public class MobileController : Controller
    {
        IMobileRepository _mobileRepository;
        IManufacturerRepository _manufacturerRepository;
        public MobileController(IMobileRepository mobileRepository, IManufacturerRepository manufacturerRepository)
        {
            _mobileRepository = mobileRepository;
            _manufacturerRepository = manufacturerRepository;
        }
        public IActionResult Index()
        {
            var mobiles = _mobileRepository.GetAllMobiles();

            List<MobileDetailsViewModel> mobileDetailsListViewModel = new List<MobileDetailsViewModel>();

            foreach (var mobile in mobiles)
            {
                MobileDetailsViewModel mobileDetailsViewModel = new MobileDetailsViewModel
                {
                    Id = mobile.Id,
                    MobileName = mobile.MobileName,
                    MobileAmount = mobile.MobileAmount,
                    ManufacturerName = mobile.Manufacturer.ManufacturerName
                };
                mobileDetailsListViewModel.Add(mobileDetailsViewModel);
            }

            return View(mobileDetailsListViewModel);
        }
        [HttpGet]
        public IActionResult AddMobile()
        {
            var addMobileViewModel = new AddMobileViewModel();

            //Returns the List<Department> from the DB.
            var manufacturers = _manufacturerRepository.GetAllManufacturers();
            List<SelectListItem> manufacturerSelectListItems = new List<SelectListItem>();


            foreach (var manf in manufacturers)
            {
                // Creating a list of SelectListItem inorder to bind the data to a select tag in the view.
                manufacturerSelectListItems.Add(new SelectListItem { Text = manf.ManufacturerName, Value = manf.ManufacturerId.ToString() });
            }

            //This code will insert a default selected item as --Select Department-- in the UI.          
            manufacturerSelectListItems.Insert(0, new SelectListItem { Text = "--Select-Category", Value = string.Empty });

            //Binding the List<SelectListItem> in the DepartmentList field.
            addMobileViewModel.ManufacturerList = manufacturerSelectListItems;

            return View(addMobileViewModel);
        }
        [HttpPost]
        public IActionResult AddMobile(AddMobileViewModel mobileViewModel)
        {
            if (ModelState.IsValid)
            {
                var mobile = new Mobile
                {
                    MobileName = mobileViewModel.MobileName,
                    MobileAmount = mobileViewModel.MobileAmount,
                    ManufacturerId = mobileViewModel.ManufacturerId
                };

                var addedMobile = _mobileRepository.AddMobile(mobile);

                return RedirectToAction("Index");
            }

            return View(mobileViewModel);

        }
        [HttpGet]
        public IActionResult UpdateMobile(int id)
        {
            var updateMobileViewModel = new UpdateMobileViewModel();
            var mobileToBeEdited = _mobileRepository.GetMobileById(id);


            // Code for filling the departments in the dropdown.
            var manufacturers = _manufacturerRepository.GetAllManufacturers();
            List<SelectListItem> manufacturerSelectListItems = new List<SelectListItem>();
            foreach (var manf in manufacturers)
            {
                manufacturerSelectListItems.Add(new SelectListItem { Text = manf.ManufacturerName, Value = manf.ManufacturerId.ToString() });
            }
            manufacturerSelectListItems.Insert(0, new SelectListItem { Text = "--Select-Category", Value = string.Empty });
            updateMobileViewModel.ManufacturerList = manufacturerSelectListItems;


            //Update the updateEmployeeViewModel fields

            updateMobileViewModel.Id = mobileToBeEdited.Id;
            updateMobileViewModel.MobileName = mobileToBeEdited.MobileName;
            updateMobileViewModel.MobileAmount = mobileToBeEdited.MobileAmount;
            updateMobileViewModel.ManufacturerId = mobileToBeEdited.ManufacturerId;

            return View(updateMobileViewModel);
        }
        [HttpPost]
        public IActionResult UpdateMobile(int id, UpdateMobileViewModel updateMobileViewModel)
        {
            if (ModelState.IsValid)
            {
                Mobile mobile = new Mobile
                {
                    MobileName = updateMobileViewModel.MobileName,
                    MobileAmount = updateMobileViewModel.MobileAmount,
                    ManufacturerId = updateMobileViewModel.ManufacturerId
                };
                _mobileRepository.UpdateMobile(id, mobile);
                return RedirectToAction("Index");
            }

            return View(updateMobileViewModel);

        }
        [HttpGet]
        public IActionResult DeleteMobile(int id)
        {
            var mobileToBeDeleted = _mobileRepository.GetFullMobileDetailsById(id);
            var deleteMobileViewModel = new DeleteMobileViewModel
            {
                Id = mobileToBeDeleted.Id,
                MobileName = mobileToBeDeleted.MobileName,
                MobileAmount = mobileToBeDeleted.MobileAmount,
                ManufacturerName = mobileToBeDeleted.Manufacturer.ManufacturerName
            };
            return View(deleteMobileViewModel);
        }
        [HttpPost]
        public IActionResult DeleteMobile(DeleteMobileViewModel deleteMobileViewModel)
        {
            _mobileRepository.RemoveMobile(deleteMobileViewModel.Id);
            return RedirectToAction("Index");
        }








    }
}




 


