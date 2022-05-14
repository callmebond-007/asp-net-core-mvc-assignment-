using MobileAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Repository
{
    public class ManufacturerRepository
    {
        MobileDbContext _mobileDbContext;
        public ManufacturerRepository(MobileDbContext mobileDbContext)
        {
            _mobileDbContext = mobileDbContext;
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return _mobileDbContext.Manufacturers.ToList();
        }

    }
}
