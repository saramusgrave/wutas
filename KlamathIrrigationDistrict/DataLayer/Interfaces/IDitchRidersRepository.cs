using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Collections.Generic;

namespace KlamathIrrigationDistrict.DataLayer.Interfaces
{
    public interface IDitchRidersRepository
    {
        /*-------------------------Drop Down---------------------------------------*/

         /*Status Drop Down
          * Use: RequestStatus1, RequestStatus2*/
        List<DitchRiderRequests> Status();
        /*Comments Drop Down
         * Use: StaffComments1, StaffComments2*/
        List<DitchRiderRequests> Comments();
        /*Violations Drop Down
         * Use: ViolationID*/
        List<DitchRiderRequests> Violations();
        /*Canals Drop Down
         * Use: CanalsList*/
        List<DitchRiderRequests> Canals();


        /*-------------------------Views---------------------------------------*/

        /*View Customers on Ride
        * Use: Customers*/
        List<DitchRiderRequests> Customers(int id);
        /*View Active Requests On
        * Use: _ActiveRequestsOn*/
        List<DitchRiderRequests> ViewActiveRequestOn(int id);
        /*View Active Requests Off
         * Use: _ActiveRequestsOff*/
        List<DitchRiderRequests> ViewActiveRequestOff(int id);
        /*View Completed Requests
        * Use: CompletedRequests, _ActiveRequestsOn, EditRequestsOn*/
        List<DitchRiderRequests> ViewRequests(int id);
        /*View Pending On Requests
         * Use: Appending_On, EditRequestStatus_On*/
        List<DitchRiderRequests> ViewPending_On(int id);
        /*View Pending Off Requests
         * Use: Appending_Off, EditRequestStatus_Off*/
        List<DitchRiderRequests> ViewPending_Off(int id);
        /*View Wait List On Requests
         * Use: WaitList_On, EditWaitList_On*/
        List<DitchRiderRequests> ViewWaitlist_On(int id);
        /*View Wait List Off Requests
         * Use: WaitList_Off, EditWaitList_Off*/
        List<DitchRiderRequests> ViewWaitlist_Off(int id);
        /*View Customers who are currently running water
         * Use: Customers_On*/
        List<DitchRiderRequests> ViewCustomersWithWater_On(int id);
        /*View Customer History
         * Use: CustomerHistory */
        List<DitchRiderRequests> ViewCustomersHistory(int id);
        /*View Customer History Past 3 days
         * Use: CusttomerRHistory*/
        List<DitchRiderRequests> ViewCustomersRecentHistory(int id);
        /*Get RequestID 
          * Use: ViewRequests*/
        DitchRiderRequests Get(int id);

        /*-------------------------Stored Procedures---------------------------------------*/



        /*Add Requests as if customer Ride  on
         * Use: AddRequestOn*/
        void AddRequest_On(DitchRiderRequests ditchriderrequests);
        /*Add Requests as if customer off
         * Use: _AddREquestOff*/
        void AddRequest_Off(DitchRiderRequests ditchriderrequests);
        /*Edit a Requests as ditch RiderOn
         * Use: EditRequestOn*/
        void EditRequestOn(DitchRiderRequests ditchriderrequests);
        /*Edit a Requests as ditch Rider off
         * Use: EditRequestOff*/
        void EditRequestOff(DitchRiderRequests ditchriderrequests);   
        /*Edit RequestStatus1 
         * Use: EditRequestStatus_On*/
        void EditRequestStatus1_On(DitchRiderRequests ditchriderrequests);
        /*Edit RequestStatus2
         * Use: EditRequestStatus_Off*/
        void EditRequestStatus2_Off(DitchRiderRequests ditchriderrequests);
        /*Violations
         * Use: Violations*/
        void Violations(DitchRiderRequests ditchriderrequests);
        /*Edit Recent History based on user log in and date
         * Use: EditRHistory_On*/
        void EditRHistory_On(DitchRiderRequests ditchriderrequests);

        /*-------------------------Stored Procedures With a Return Value---------------------------------------*/

        /*Store procedure to view how much is in a canal for tomorrow
         * Use: CanalWater, _CanalWater*/
        float WaterCFS_NextDayByCanal(string lateral);
        /*Stored procedure to view how much CFS is in canal for today
         * Use: CanalWater, _CanalWater*/
        float WaterCFS_TodayByCanal(string lateral);
    }
}