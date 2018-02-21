using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    public class OfficeStaffRepository : IOfficeStaffRepository
    {
        public KIDStaff Get(int id)
        {
            KIDStaff p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM KIDStaff";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new KIDStaff();
                            p.StaffID = int.Parse(reader["StaffID"].ToString());
                            p.Position = int.Parse(reader["Position"].ToString());
                            p.FirstName = reader["FirstName"].ToString();
                            p.LastName = reader["LastName"].ToString();
                            p.Password = reader["Password"].ToString();
                            p.Email = reader["Email"].ToString();
                            p.PhoneNumber = reader["PhoneNumber"].ToString();
                            p.StaffStatus = Boolean.Parse(reader["StaffStatus"].ToString());
                            p.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                            p.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                            p.ModifiedDateTime = DateTime.Parse(reader["ModifiedDateTime"].ToString());
                            p.ModifiedUser = reader["ModifiedUser"].ToString();
                        }
                    }
                }
            }
            return (p);
        }
        public List<KIDStaff> ViewStaff()
        {
            List<KIDStaff> StaffList = new List<KIDStaff>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM KIDStaff ORDER BY StaffID ASC";
                    //command.CommandText = "SELECT Positions.Position, StaffID, FirstName, LastName, Password, Email, PhoneNumber,StaffStatus, StartDate, EndDate, ModifiedDateTime, ModifiedUser FROM KIDStaff, Positions WHERE Positions.PositionID = KIDStaff.Position ORDER BY  KIDStaff.StaffStatus DESC,KIDStaff.StaffID ASC  ";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KIDStaff Staff = new KIDStaff();
                            Staff.StaffID = int.Parse(reader["StaffID"].ToString());
                            Staff.Position = int.Parse(reader["Position"].ToString());
                            Staff.FirstName = reader["FirstName"].ToString();
                            Staff.LastName = reader["LastName"].ToString();
                            Staff.Password = reader["Password"].ToString();
                            Staff.Email = reader["Email"].ToString();
                            Staff.PhoneNumber = reader["PhoneNumber"].ToString();
                            Staff.StaffStatus = Boolean.Parse(reader["StaffStatus"].ToString());
                            Staff.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                            Staff.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                            Staff.ModifiedDateTime = DateTime.Parse(reader["ModifiedDateTime"].ToString());
                            Staff.ModifiedUser = reader["ModifiedUser"].ToString();
                            StaffList.Add(Staff);
                        }
                    }
                }
            }
            return (StaffList);
        }
        //From Allen
        //public KIDStaff StaffMember()
        //{
        //    KIDStaff staffmember = new KIDStaff();

        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.Text;
        //            command.CommandText = "SELECT FirstName, LastName, Positions.Position FROM KIDStaff, Positions WHERE Positions.PositionID = KIDStaff.Position";
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    staffmember.FirstName = reader["FirstName"].ToString();
        //                    staffmember.LastName = reader["LastName"].ToString();
        //                    staffmember.Position = reader["Position"].ToString();
        //                }
        //            }
        //        }
        //    }
        //    return (staffmember);
        //}
        //public List<SelectListItem> PositionTypes()
        //{
        //    List<SelectListItem> PositionList = new List<SelectListItem>();
        //    //List<Positions> PositionList = new List<Positions>();
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "SELECT Position FROM Positions ORDER BY PositionID";
        //            command.CommandType = CommandType.Text;

        //            connection.Open();

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Positions p = new Positions();
        //                    new SelectListItem() { Text = p.Position, Value = p.PositionID.ToString() };                                                   
        //                }
        //            }
        //        }
        //    }
        //    return (PositionList);
        //}





        //not from allen

        //Add KID Staff member
        public virtual void AddStaff(KIDStaff kidstaff)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Staff_AddStaff";

                    command.Parameters.AddWithValue("@Position", kidstaff.Position);
                    command.Parameters.AddWithValue("@FirstName", kidstaff.FirstName);
                    command.Parameters.AddWithValue("@LastName", kidstaff.LastName);
                    command.Parameters.AddWithValue("@Password", kidstaff.Password);
                    command.Parameters.AddWithValue("@Email", kidstaff.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", kidstaff.PhoneNumber);
                    command.Parameters.AddWithValue("@StaffStatus", kidstaff.StaffStatus);
                    command.Parameters.AddWithValue("@StartDate", kidstaff.StartDate);
                    command.Parameters.AddWithValue("@EndDate", kidstaff.EndDate);
                    command.Parameters.AddWithValue("@ModifiedDateTime", kidstaff.ModifiedDateTime);
                    command.Parameters.AddWithValue("@ModifiedUser", kidstaff.ModifiedUser);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //Edit KID Staff member
        public virtual void EditStaff(KIDStaff kidstaff)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Staff_EditStaff";
                    if (kidstaff.StaffID != 0)
                    {
                        command.Parameters.AddWithValue("@StaffID", kidstaff.StaffID);
                    }
                    command.Parameters.AddWithValue("@Position", kidstaff.Position);
                    command.Parameters.AddWithValue("@FirstName", kidstaff.FirstName);
                    command.Parameters.AddWithValue("@LastName", kidstaff.LastName);
                    command.Parameters.AddWithValue("@Password", kidstaff.Password);
                    command.Parameters.AddWithValue("@Email", kidstaff.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", kidstaff.PhoneNumber);
                    command.Parameters.AddWithValue("@StaffStatus", kidstaff.StaffStatus);
                    command.Parameters.AddWithValue("@StartDate", kidstaff.StartDate);
                    command.Parameters.AddWithValue("@EndDate", kidstaff.EndDate);
                    command.Parameters.AddWithValue("@ModifiedDateTime", kidstaff.ModifiedDateTime);
                    command.Parameters.AddWithValue("@ModifiedUser", kidstaff.ModifiedUser);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public virtual void Save(KIDStaff kidstaff)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Staff_InsertUpdate";
                    if (kidstaff.StaffID != 0)
                    {
                        command.Parameters.AddWithValue("@StaffID", kidstaff.StaffID);
                    }
                    command.Parameters.AddWithValue("@Position", kidstaff.Position);
                    command.Parameters.AddWithValue("@FirstName", kidstaff.FirstName);
                    command.Parameters.AddWithValue("@LastName", kidstaff.LastName);
                    command.Parameters.AddWithValue("@Password", kidstaff.Password);
                    command.Parameters.AddWithValue("@Email", kidstaff.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", kidstaff.PhoneNumber);
                    command.Parameters.AddWithValue("@StaffStatus", kidstaff.StaffStatus);
                    command.Parameters.AddWithValue("@StartDate", kidstaff.StartDate);
                    command.Parameters.AddWithValue("@EndDate", kidstaff.EndDate);
                    command.Parameters.AddWithValue("@ModifiedDateTime", kidstaff.ModifiedDateTime);
                    command.Parameters.AddWithValue("@ModifiedUser", kidstaff.ModifiedUser);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}