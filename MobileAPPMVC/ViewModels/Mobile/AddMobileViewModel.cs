using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.ViewModels.Mobile
{
    public class AddMobileViewModel
    {
        [Required(ErrorMessage = "Mobile Name is mandatory")]
        public string MobileName { get; set; }

        [Required(ErrorMessage = "Mobile Amount is mandatory")]
        public double MobileAmount { get; set; }

        [Required(ErrorMessage = "Manufacturer is mandatory")]
        public int ManufacturerId { get; set; }

        public List<SelectListItem> ManufacturerList { get; set; }

    }
}
