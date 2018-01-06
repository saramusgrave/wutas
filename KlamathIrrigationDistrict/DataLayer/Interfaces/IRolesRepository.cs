using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    interface IRolesRepository
    {
        List<Roles> GetUserRole(string FullName);
        List<Roles> GetRoles();
        Roles GetRoles(int id);
        void SaveRoles(Roles roles);
    }
}
