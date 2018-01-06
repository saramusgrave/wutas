using KlamathIrrigationDistrict.DataLayer.DataModels;
using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
                    command.CommandText = "SELECT * FORM KIDStaff";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new KIDStaff();
                            p.StaffID = int.Parse(reader["StaffID"].ToString());
                            p.Position = reader["Position"].ToString();
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
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KIDStaff Staff = new KIDStaff();
                            Staff.StaffID = int.Parse(reader["StaffID"].ToString());
                            Staff.Position = reader["Position"].ToString();
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