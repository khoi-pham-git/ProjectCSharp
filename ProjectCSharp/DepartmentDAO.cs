using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp
{
    class DepartmentDAO
    {
        DBUtil cn;
        SqlDataAdapter da;
        SqlCommand cm;


        public DepartmentDAO()
        {
            cn = new DBUtil();
        }

        public DataTable getListDepartment()
        {
            string sql = "SELECT Id, Name, FoundedYear FROM Department";
            SqlConnection con = cn.getConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            //Mở kết nối
            DataTable data = new DataTable();
            da.Fill(data);
            con.Close();
            return data;
        }

        public bool AddDepartment(DepartmentDTO dp)
        {
            string sql = "INSERT INTO Department(Id, Name, Foundedyear) VALUES(@Id, @Name, @Foundedyear)";
            SqlConnection con = cn.getConnection();          
            try
            {
                cm = new SqlCommand(sql, con);
                con.Open();
                cm.Parameters.Add("@Id", SqlDbType.Char).Value = dp.Id1;
                cm.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dp.Name1;
                cm.Parameters.Add("@Foundedyear", SqlDbType.Int).Value = dp.Founded1;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateDepartment(DepartmentDTO dp)
        {
            string sql = "UPDATE Department SET Id = @Id, Name = @Name, Foundedyear = @Foundedyear WHERE ID = @Id";
            SqlConnection con = cn.getConnection();
            try
            {
                cm = new SqlCommand(sql, con);
                con.Open();
                cm.Parameters.Add("@Id", SqlDbType.Char).Value = dp.Id1;
                cm.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dp.Name1;
                cm.Parameters.Add("@Foundedyear", SqlDbType.Int).Value = dp.Founded1;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool DeleteDepartment(DepartmentDTO dp)
        {
            string sql = "DELETE Department WHERE Id = @Id";
            SqlConnection con = cn.getConnection();
            try
            {
                cm = new SqlCommand(sql, con);
                con.Open();
                cm.Parameters.Add("@Id", SqlDbType.Char).Value = dp.Id1;
                cm.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        
        public DataTable findDepartment(string dp)
        {
            string sql = "SELECT Id, Name, FoundedYear FROM Department WHERE Name like '%" + dp + "%'";
            SqlConnection con = cn.getConnection();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            //Mở kết nối
            DataTable data = new DataTable();
            da.Fill(data);
            con.Close();
            return data;

        }
        
    }
}
