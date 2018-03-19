using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IDitchRidersRepository
    {

        //Views

        //Used to get Drop Down From SQL RequestStatus1 and RequestStatus2
        List<DitchRiderRequests> Status();
        //Used to get Drop Down From SQL Ditch Rider Comments
        List<DitchRiderRequests> Comments();
        //View Customers on Ride 
        List<DitchRiderRequests> Customers4(int id);
        //View Active Requests on for Ride 
        List<DitchRiderRequests> ViewActiveRequestOn4(int id);
        //View Active Requests off for Ride 
        List<DitchRiderRequests> ViewActiveRequestOff4(int id);
        //View completed Request List for Ride  
        List<DitchRiderRequests> ViewRequests4(int id);
        //View Requests with RequestStatus1 = Pending
        List<DitchRiderRequests> ViewPending_4On(int id);
        //View Requests with RequestStatus2 = Pending
        List<DitchRiderRequests> ViewPending_4Off(int id);
        //View Waitlist On
        List<DitchRiderRequests> ViewWaitlist_4On(int id);
        //Waitlist Off
        List<DitchRiderRequests> ViewWaitlist_4Off(int id);
        //View Customers on Ride  who currently have water running
        List<DitchRiderRequests> ViewCustomersWithWater_4On(int id);
        //View Customer History
        List<DitchRiderRequests> ViewCustomersHistory(int id);
        //View Customer History Past 3 days
        List<DitchRiderRequests> ViewCustomersRecentHistory(int id);


        
        //Stored Procedures

        //Get Request ID
        DitchRiderRequests Get(int id);
        //Add Requests as if customer Ride  on
        void AddRequest_4On(DitchRiderRequests ditchriderrequests);
        //Add Requests as if customer off
        void AddRequest_4Off(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch RiderOn
        void EditRequest4On(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider off
        void EditRequest4Off(DitchRiderRequests ditchriderrequests);   
        //Edit RequestStatus1 
        void EditRequestStatus1_On(DitchRiderRequests ditchriderrequests);
        //Edit RequestStatus2
        void EditRequestStatus2_Off(DitchRiderRequests ditchriderrequests);
        //Store procedure to view how much is in a canal.
        //int WaterCFS_NextDayByCanal(DitchRiderRequests lateral);
        int WaterCFS_NextDayByCanal(DitchRiderRequests lateral);
    }
}