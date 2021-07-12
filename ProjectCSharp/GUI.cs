using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp
{
    class GUI
    {
        DepartmentDAO dao;
        public GUI()
        {
            dao = new DepartmentDAO();
        }

        public DataTable getListDepartment()
        {
            return getListDepartment();
        }

        public bool AddDepartment(DepartmentDTO dp)
        {
            return dao.AddDepartment(dp);
        }

        public bool UpdateDepartment(DepartmentDTO dp)
        {
            return dao.UpdateDepartment(dp);
        }

        public bool DeleteDepartment(DepartmentDTO dp)
        {
            return dao.DeleteDepartment(dp);
        }
        public DataTable findDepartment(string dp)
        {
            return dao.findDepartment(dp);
        }
    }
}
