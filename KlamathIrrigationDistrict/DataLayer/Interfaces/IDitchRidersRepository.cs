using KlamathIrrigationDistrict.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        void AddRequest_4On(DitchRiderRequests ditchriderrequests);
        //Add Requests as if customer off
        void AddRequest_4Off(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider4On
        void EditRequest4On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider4 off
        void EditRequest4Off(DitchRiderRequests ditchriderrequests);
        //View Requests with RequestStatus1 = Pending
        List<DitchRiderRequests> ViewPending_4On();
        //View Requests with RequestStatus2 = Pending
        List<DitchRiderRequests> ViewPending_4Off();
        //Edit RequestStatus1 
        void EditRequestStatus1_On(DitchRiderRequests ditchriderrequests);
        //Edit RequestStatus2
        void EditRequestStatus2_Off(DitchRiderRequests ditchriderrequests);
        //View Waitlist On
        List<DitchRiderRequests> ViewWaitlist_4On();
        //Waitlist Off
        List<DitchRiderRequests> ViewWaitlist_4Off();


        List<SelectListItem> RequestStatus_2();
        List<DitchRiderRequestStatus> Status();



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