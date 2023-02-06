using System.Collections.Generic;
using BusinessObjects.Models;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace DataAccessLayer.DataAccess
{

    public class GenderDataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["hmDbConnection"].ConnectionString;

        public List<Gender> GetGenders()
        {

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from tblGender", con);

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();


            List<Gender> lstGender = new List<Gender>();

            while (rdr.Read())
            {
                Gender gender = new Gender();
                gender.Id = Convert.ToInt32(rdr["Id"].ToString());
                gender.Code = rdr["Code"].ToString();
                gender.Name = rdr["Name"].ToString();
                lstGender.Add(gender);
            }

            con.Close();


            return lstGender;
        }

        public int CreateGender(Gender gender)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("insert into tblGender(Code, Name) values('"+gender.Code+"','"+gender.Name+"')", con);

            con.Open();

            int rowsEffected = cmd.ExecuteNonQuery();

            con.Close();

            return rowsEffected;
        }

        public bool IsDuplicate(Gender gender)
        {
            bool IsDuplicate = false;

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = 
            new SqlCommand("select 1 from tblGender where code = '"+ gender.Code + "' and name = '"+ gender.Name + "' ", con);

            con.Open();

            var result = cmd.ExecuteScalar();

            if(Convert.ToInt32(result) == 1)
            {
                IsDuplicate = true;
            }

            return IsDuplicate;
        }

    }
}
