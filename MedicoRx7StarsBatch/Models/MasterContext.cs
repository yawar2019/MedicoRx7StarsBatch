using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicoRx7StarsBatch.Models
{
    public class MasterContext
    {
        public static class EmployeeContext
        {
            public static IEnumerable<T> ReturnList<T>(string spName, DynamicParameters param)
            {
                SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
                return con.Query<T>(spName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
            public static P AddOrEdit<P>(string spName, DynamicParameters param)
            {
                SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
                var result = (P)Convert.ChangeType(con.Execute(spName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(P));
                return result;
            }
        }
    }
}