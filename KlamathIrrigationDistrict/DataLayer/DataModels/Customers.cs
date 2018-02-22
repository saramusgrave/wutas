using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //Customers Table
    public class Customers
    {
        //-------------------------------------------------------------------------------------
        //Customers(int CustomerID, int TrackingID, String Name, Decimal TotalAllotment)
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int TrackingID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        public int Zip { get; set; }
        public decimal TotalAllotment { get; set; }
        public List<Customers> customers { get; set; }
        //-------------------------------------------------------------------------------------

        //List of items to allow input for requests
        public int RequestID { get; set; }

        public string Structure { get; set; }

        //references 'CustomerCFS1 - meaning on
        public decimal CustomerCFS_1 { get; set; }

        //rerence the first pair of comments when water turned on
        public string CustomerComments_1 { get; set; }

        //date submit of requests
        public DateTime TimeStampCustomer1 { get; set; }

        //date in which customer would like the water turned off
        public DateTime CustomerDate1 { get; set; }

        public DateTime _GetCustomerDate = DateTime.Now;

        //will display 'confirm' if completed task
        public string RequestStatus1 { get; set; }

        //reference 'customercfs2' - water turned on again
        public int CustomerCFS_2 { get; set; }

        //second set of comments when customer wants to use more water
        public string CustomerComments_2 { get; set; }

        //date of submit request 2 for same plot of land
        public DateTime TimeStampCustomer2 { get; set; }

        //end of timestamp 2 for request
        public DateTime CustomerDate2 { get; set; }

        //the request status of second round of applied request
        public String RequestStatus2 { get; set; }


        //-------------------------------------------------------------------------------------
        //DitchRider Variables for Customer to see when viewing the customer history
        
        //The staff id for completing task - first set of water usage
        public int KIDStaffID_1 { get; set; }

        //name that links with staffID
        public String StaffName_1 { get; set; }

        //time at which rider accepted or rejected water request
        public DateTime TimeStampStaff1 { get; set; }

        //time staf member completed the task if accepted it
        public DateTime StaffDate1 { get; set; }

        //will be referenced when customer viewing history of applied CFS
        public int StaffCFS1 { get; set; }

        //will be referenced to allow customer to view staff comments
        public string StaffComments1 { get; set; }

        //the second id referenceing staff on a request
        public int KIDStaffID_2 { get; set; }

        //reference ID, display actual staff name
        public string StaffName_2 { get; set; }

        //second time of rider accepting or rejecting request
        public DateTime TimeStampStaff2 { get; set; }

        //date in which ditchrider completed task
        public DateTime StaffDate2 { get; set; }

        //will be referenced when customer viewing history of applied CFS
        public int StaffCFS2 { get; set; }

        //will be referenced to allow customer to view staff comments
        public string StaffComments2 { get; set; }

    }
}