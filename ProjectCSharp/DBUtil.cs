using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectCSharp
{
    class DBUtil
    {
        string dbConnection;
        
        public DBUtil()
        {
            dbConnection = @"Data Source=DESKTOP-UML28IP;Initial Catalog=DepartmentManagement;Persist Security Info=True;User ID=sa;Password=123123";
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(dbConnection);
        }
    }
}
