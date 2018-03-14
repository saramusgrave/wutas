using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IDitchRidersRepository
    {
        /*-----------------------------------------------------
         -----All Ditch Riders--------------------------------*/

        //Views

        //Used to get Drop Down From SQL RequestStatus1 and RequestStatus2
        List<DitchRiderRequests> Status();
        //Used to get Drop Down From SQL Ditch Rider Comments
        List<DitchRiderRequests> Comments();

        //Stored Procedures

        //Get Request ID
        DitchRiderRequests Get(int id);

        
        /*------------------------------------------------------
         -----*Ride 4-------------------------------------------*/

         //Views

        //View Customers on Ride 4
        List<DitchRiderRequests> Customers4();
        //View Active Requests on for Ride 4
        List<DitchRiderRequests> ViewActiveRequestOn4();
        //View Active Requests off for Ride 4
        List<DitchRiderRequests> ViewActiveRequestOff4();
        //View completed Request List for Ride 4 
        List<DitchRiderRequests> ViewRequests4();
       //View Requests with RequestStatus1 = Pending
        List<DitchRiderRequests> ViewPending_4On();
        //View Requests with RequestStatus2 = Pending
        List<DitchRiderRequests> ViewPending_4Off();
        //View Waitlist On
        List<DitchRiderRequests> ViewWaitlist_4On();
        //Waitlist Off
        List<DitchRiderRequests> ViewWaitlist_4Off();
        //View Customers on Ride 4 who currently have water running
        List<DitchRiderRequests> ViewCustomersWithWater_4On();

        //Stored Procedures

        //Add Requests as if customer Ride 4 on
        void AddRequest_4On(DitchRiderRequests ditchriderrequests);
        //Add Requests as if customer off
        void AddRequest_4Off(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider4On
        void EditRequest4On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider4 off
        void EditRequest4Off(DitchRiderRequests ditchriderrequests);   
        //Edit RequestStatus1 
        void EditRequestStatus1_On(DitchRiderRequests ditchriderrequests);
        //Edit RequestStatus2
        void EditRequestStatus2_Off(DitchRiderRequests ditchriderrequests);
        //Store procedure to view how much is in a canal.
        void WaterCFS_NextDayByCanal(DitchRiderRequests lateral);
        


        /*------------------------------------------------------
         -----*Ride 5-------------------------------------------*/

        //Views

        //View completed Request List for Ride 5
        List<DitchRiderRequests> ViewRequests5();

        //Stored Proceudres

        //Add Requests as if customer Ride 5
        void AddRequest5On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider5On
        void EditRequest5On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider5 off
        void EditRequest5Off(DitchRiderRequests ditchriderrequests);
    }
}