using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp
{
    class DepartmentDTO
    {
        private String Id;
        private String Name;
        private int Founded;

        public DepartmentDTO(string id, string name, int founded)
        {
            Id = id;
            Name = name;
            Founded = founded;
        }
        
        public DepartmentDTO()
        {

        }

        public string Id1 { get => Id; set => Id = value; }
        public string Name1 { get => Name; set => Name = value; }
        public int Founded1 { get => Founded; set => Founded = value; }
    }
}
