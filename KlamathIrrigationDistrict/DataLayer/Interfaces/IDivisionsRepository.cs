using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IDivisionsRepository
    {
        Divisions Get(string DivisionID);
        List<Divisions> ViewDivisions();
        void Save(Divisions divisions);
    }
}