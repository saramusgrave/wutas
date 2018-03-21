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
        List<DitchRiderRequests> Customers(int id);
        //View Active Requests on for Ride 
        List<DitchRiderRequests> ViewActiveRequestOn(int id);
        //View Active Requests off for Ride 
        List<DitchRiderRequests> ViewActiveRequestOff(int id);
        //View completed Request List for Ride  
        List<DitchRiderRequests> ViewRequests(int id);
        //View Requests with RequestStatus1 = Pending
        List<DitchRiderRequests> ViewPending_On(int id);
        //View Requests with RequestStatus2 = Pending
        List<DitchRiderRequests> ViewPending_Off(int id);
        //View Waitlist On
        List<DitchRiderRequests> ViewWaitlist_On(int id);
        //Waitlist Off
        List<DitchRiderRequests> ViewWaitlist_Off(int id);
        //View Customers on Ride  who currently have water running
        List<DitchRiderRequests> ViewCustomersWithWater_On(int id);
        //View Customer History
        List<DitchRiderRequests> ViewCustomersHistory(int id);
        //View Customer History Past 3 days
        List<DitchRiderRequests> ViewCustomersRecentHistory(int id);
                
        //Stored Procedures

        //Get Request ID
        DitchRiderRequests Get(int id);
        //Add Requests as if customer Ride  on
        void AddRequest_On(DitchRiderRequests ditchriderrequests);
        //Add Requests as if customer off
        void AddRequest_Off(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch RiderOn
        void EditRequestOn(DitchRiderRequests ditchriderrequests);
        //Edit a Requests as ditch Rider off
        void EditRequestOff(DitchRiderRequests ditchriderrequests);   
        //Edit RequestStatus1 
        void EditRequestStatus1_On(DitchRiderRequests ditchriderrequests);
        //Edit RequestStatus2
        void EditRequestStatus2_Off(DitchRiderRequests ditchriderrequests);
        //Store procedure to view how much is in a canal for tomorrow
        int WaterCFS_NextDayByCanal(string lateral);
        //Stored procedure to view how much CFS is in canal for today
        int WaterCFS_TodayByCanal(string lateral);
    }
}