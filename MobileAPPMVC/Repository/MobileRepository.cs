using Microsoft.EntityFrameworkCore;
using MobileAPPMVC.MDBContext;
using MobileAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Repository
{
    public class MobileRepository : IMobileRepository
    {
        MobileDbContext _mobileDbContext;
        public MobileRepository(MobileDbContext mobileDbContext)
        {
            _mobileDbContext = mobileDbContext;
        }

        public Mobile AddMobile(Mobile mobile)
        {
            _mobileDbContext.Mobiles.Add(mobile);
            _mobileDbContext.SaveChanges();
            return mobile;

        }

        public List<Mobile> GetAllMobiles()
        {
            return _mobileDbContext.Mobiles.Include(m => m.Manufacturer).ToList();
        }

        public Mobile GetFullMobileDetailsById(int id)
        {
            var existingMobile = _mobileDbContext.Mobiles.Include(m => m.Manufacturer).FirstOrDefault(e => e.Id == id);
            return existingMobile;

        }

        public Mobile GetMobileById(int id)
        {
            var existingMobile = _mobileDbContext.Mobiles.FirstOrDefault(e => e.Id == id);
            return existingMobile;

        }

        public void RemoveMobile(int id)
        {
            var existingMobile = _mobileDbContext.Mobiles.FirstOrDefault(e => e.Id == id);
            if (existingMobile == null)
            {
                throw new Exception($"Mobile with Id ={id} is not found for deletion");
            }

            _mobileDbContext.Mobiles.Remove(existingMobile);
            _mobileDbContext.SaveChanges();

        }

        public void UpdateMobile(int id, Mobile mobile)
        {
            var existingMobile = _mobileDbContext.Mobiles.FirstOrDefault(e => e.Id == id);
            if (existingMobile != null)
            {
                existingMobile.MobileName = mobile.MobileName;
                existingMobile.MobileAmount = mobile.MobileAmount;
                existingMobile.ManufacturerId = mobile.ManufacturerId;
                _mobileDbContext.SaveChanges();
            }

        }

    }
}
