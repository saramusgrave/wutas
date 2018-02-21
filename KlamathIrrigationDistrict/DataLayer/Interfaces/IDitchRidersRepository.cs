using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IDitchRidersRepository
    {
        //Get Request ID
        DitchRiderRequests Get(int id);
        //View Request List
        List<DitchRiderRequests> ViewRequests();
        //Add Requests as if customer
        void AddRequest(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider
        void EditRequest(DitchRiderRequests ditchriderrequests);
    }
}