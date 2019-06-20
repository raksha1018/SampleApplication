using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Routing;


namespace SampleApplication.Models
{
    public class StudentData
    {
        public int totalRecords { get; set; }
        //public int previousPage { get; set; }
        public int previousPage { get; set; }

        public int currentPage { get; set; }
        public int pageSize { get; set; }

        public int nextPage { get; set; }
       //public string nextPage { get; set; }

        public IEnumerable<Students> studentCollection { get; set; }

       
    }
}
