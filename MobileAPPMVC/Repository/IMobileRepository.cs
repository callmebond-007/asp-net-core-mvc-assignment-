using MobileAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Repository
{
    interface IMobileRepository
    {
        List<Mobile> GetAllMobiles();

        Mobile AddMobile(Mobile mobile);

        Mobile GetMobileById(int id);

        Mobile GetFullMobileDetailsById(int id);

        void UpdateMobile(int id, Mobile mobile);

        void RemoveMobile(int id);

    }
}
