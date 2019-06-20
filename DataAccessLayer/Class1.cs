using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Class1
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["Authorization_ConnectionString"].ConnectionString;
    }
}
