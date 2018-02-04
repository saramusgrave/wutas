using KlamathIrrigationDistrict.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KlamathIrrigationDistrict.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace KlamathIrrigationDistrict.DataLayer.Repositories
{
    public class RoleRepository : IRolesRepository
    {
        public Roles GetRoles(int id)
        {
            Roles r = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Roles WHERE StaffID= @StaffID";
                    command.Parameters.AddWithValue("@StaffID", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            r = new Roles();
                            r.StaffID = int.Parse(reader["StaffID"].ToString());
                            r.Position = reader["Position"].ToString();
                            r.FirstName = reader["FirstName"].ToString();
                            r.LastName = reader["LastName"].ToString();
                            r.FullName = reader["FullName"].ToString();
                            r.Password = reader["Password"].ToString();
                        }
                    }
                }
            }
            return (r);
        }

        public List<Roles> GetRoles()
        {
            List<Roles> rolesList = new List<Roles>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Roles";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Roles r = new Roles();
                            r.StaffID = int.Parse(reader["StaffID"].ToString());
                            r.Position = reader["Position"].ToString();
                            r.FirstName = reader["FirstName"].ToString();
                            r.LastName = reader["LastName"].ToString();
                            r.FullName = reader["FullName"].ToString();
                            r.Password = reader["Password"].ToString();
                            rolesList.Add(r);
                        }
                    }
                }
            }
            return (rolesList);
        }
        public List<Roles> GetUserRole(string FullName)
        {
            List<Roles> rolesList = new List<Roles>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Roles WHERE FullName = @FullName";
                    command.Parameters.AddWithValue("@FullName", FullName);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Roles r = new Roles();
                            r.StaffID = int.Parse(reader["StaffID"].ToString());
                            r.Position = reader["Position"].ToString();
                            r.FirstName = reader["FirstName"].ToString();
                            r.LastName = reader["LastName"].ToString();
                            r.FullName = reader["FullName"].ToString();
                            r.Password = reader["Password"].ToString();
                            rolesList.Add(r);
                        }
                    }
                }
            }
            return (rolesList);
        }

        public void SaveRoles(Roles roles)
        {
            //Roles r = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"KlamathIrrigation_Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    if (roles.StaffID !=0)
                    {
                        command.Parameters.AddWithValue("@StaffID", roles.StaffID);
                        command.CommandText = "UPDATE Roles SET Position=@Position, FirstName = @FirstName, LastName = @LastName, FullName = @FullName, Password = @Password";
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO Roles (Position, FirstName, LastName, FullName, Password) VALUES (@Position, @FirstName, @LastName, @FullName, @Password)";
                    }
                    command.Parameters.AddWithValue("@Position", roles.Position);
                    command.Parameters.AddWithValue("@FirstName", roles.FirstName);
                    command.Parameters.AddWithValue("@LastName", roles.LastName);
                    command.Parameters.AddWithValue("@FullName", roles.FullName);
                    command.Parameters.AddWithValue("@Password", roles.Password);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
} 