using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    public class StaffRepository : IOfficeStaffRepository 
    {
        //Find Staff member by StaffID
        public virtual KIDStaff Get(int id)
        {
            KIDStaff s = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_Staff_Get";
                    command.Parameters.AddWithValue("@StaffID", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            s = new KIDStaff();
                            s.StaffID = int.Parse(reader["StaffID"].ToString());
                            s.Position = reader["Position"].ToString();
                            s.FirstName = reader["FirstName"].ToString();
                            s.LastName = reader["LastName"].ToString();
                            s.Password = reader["Password"].ToString();
                            s.Email = reader["Email"].ToString();
                            s.PhoneNumber = reader["PhoneNumber"].ToString();
                            s.StaffStatus = Boolean.Parse(reader["StaffStatus"].ToString());
                            s.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                            s.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                            s.ModifiedDateTime = DateTime.Parse(reader["ModifiedDateTime"].ToString());
                            s.ModifiedUser = reader["ModifiedUser"].ToString();
                        }
                    }
                }
            }
            return (s);
        }
        //ViewStaff: View all staff members
        public virtual List<KIDStaff> ViewStaff()
        {
            List<KIDStaff> StaffList = new List<KIDStaff>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM KIDStaff ORDER BY StaffID ASC";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KIDStaff r = new KIDStaff();
                            r.StaffID = int.Parse(reader["StaffID"].ToString());
                            r.Position = reader["Position"].ToString();
                            r.FirstName = reader["FirstName"].ToString();
                            r.LastName = reader["LastName"].ToString();
                            r.Password = reader["Password"].ToString();
                            r.Email = reader["Email"].ToString();
                            r.PhoneNumber = reader["PhoneNumber"].ToString();
                            r.StaffStatus = Boolean.Parse(reader["StaffStatus"].ToString());
                            r.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                            r.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                            r.ModifiedDateTime = DateTime.Parse(reader["ModifiedDateTime"].ToString());
                            r.ModifiedUser = reader["ModifiedUser"].ToString();
                            StaffList.Add(r);
                        }
                    }
                }
            }
            return (StaffList);
        }
        //Save KIDStaff Members, Insert & Update KIDStaff
        public virtual void Save(KIDStaff kidstaff)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
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