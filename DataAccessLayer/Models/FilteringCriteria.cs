using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SampleApplication.Models
{
    public class FilteringCriteria
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string name { get; set; }

    }
    public class PageLinkBuilder
    {
        public Uri FirstPage { get; private set; }
        public Uri LastPage { get; private set; }
        public Uri NextPage { get; private set; }
        public Uri PreviousPage { get; private set; }

      
    }
}
