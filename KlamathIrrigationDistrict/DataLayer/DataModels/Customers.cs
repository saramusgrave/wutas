using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.DataLayer.DataModels
{
    //Customers Table
    public class Customers
    {
        //constuctor for Customers
        //public Customers() { }

        //NEED TO CHANGE ALL CFS variables to float

        //-------------------------------------------------------------------------------------
        //Customers(int CustomerID, int TrackingID, String Name, Decimal TotalAllotment)
        //public string Position { get; set { "Customer"}; }

        //variables for setting Request Date View
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int TrackingID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        public int Zip { get; set; }        
        public List<Customers> customers { get; set; }

        //-------------------------------------------------------------------------------------
        //customer information regarding the ride, lateral, and MTL
        public string Lateral { get; set; }

        //this number holds the entirety of allotment
        public decimal TotalAllotment { get; set; }

        //this number will change given the user's request
        public decimal CurrentAllotment { get; set; }

        public int Ride { get; set; }

        public int CustomerMTLHisID { get; set; }

        public int Violations { get; set; }

        //-------------------------------------------------------------------------------------
        //info to obtain the staff info for contact
        public string Staff_Position { get; set; }
        [StringLength(50)]
        public string Staff_FirstName { get; set; }
        [StringLength(50)]
        public string Staff_LastName { get; set; }
        [EmailAddress]
        public string Staff_Email { get; set; }
        [Phone]
        [StringLength(13)]
        public string Staff_PhoneNumber { get; set; }

        //-------------------------------------------------------------------------------------
        //List of items to allow input for requests
        public int RequestID { get; set; }

        public string Structure { get; set; }

        //references 'CustomerCFS1 - meaning on
        public float CustomerCFS_1 { get; set; }

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
        public float CustomerCFS_2 { get; set; }

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

        //name that links with staffID
        public String StaffName_1 { get; set; }

        //time at which rider accepted or rejected water request
        public DateTime TimeStampStaff1 { get; set; }

        //time staf member completed the task if accepted it
        public DateTime StaffDate1 { get; set; }

        //will be referenced when customer viewing history of applied CFS
        public float StaffCFS1 { get; set; }

        //will be referenced to allow customer to view staff comments
        public string StaffComments1 { get; set; }

        //reference ID, display actual staff name
        public string StaffName_2 { get; set; }

        //second time of rider accepting or rejecting request
        public DateTime TimeStampStaff2 { get; set; }

        //date in which ditchrider completed task
        public DateTime StaffDate2 { get; set; }

        //will be referenced when customer viewing history of applied CFS
        public float StaffCFS2 { get; set; }

        //will be referenced to allow customer to view staff comments
        public string StaffComments2 { get; set; }

    }
}