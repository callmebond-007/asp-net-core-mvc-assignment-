using MobileAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Repository
{
    public interface IManufacturerRepository
    {
         List<Manufacturer> GetAllManufacturers();
    }

}

