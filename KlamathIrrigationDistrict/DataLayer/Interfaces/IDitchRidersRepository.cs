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
        /*Ride 4*/
        //View Customers on Ride 4
        List<DitchRiderCustomers> Customers4();
        //View Active Requests on for Ride 4
        List<DitchRiderRequests> ViewActiveRequestOn4();
        //View Active Requests off for Ride 4
        List<DitchRiderRequests> ViewActiveRequestOff4();
        //View completed Request List for Ride 4 
        List<DitchRiderRequests> ViewRequests4();
        //Add Requests as if customer Ride 4 on
        void AddRequest4On(DitchRiderRequests ditchriderrequests);
        //Add Requests as if customer off
        void AddRequest4Off(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider4On
        void EditRequest4On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider4 off
        void EditRequest4Off(DitchRiderRequests ditchriderrequests);



        /*Ride 5*/
        //View completed Request List for Ride 5
        List<DitchRiderRequests> ViewRequests5();
        //Add Requests as if customer Ride 5
        void AddRequest5On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider5On
        void EditRequest5On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider5 off
        void EditRequest5Off(DitchRiderRequests ditchriderrequests);
    }
}