using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Data
{
    interface IDBContext
    {
        string GetConnectionString();

        void SetConnectionString(string connection);
    }
}
