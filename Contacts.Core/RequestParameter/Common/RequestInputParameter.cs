using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Shared.RequestParameter.Common
{
    public abstract class RequestInputParameter
    {
        private int MaxPageSize = 20;

        private int pageSize = 5;

        public int PageSize
        {
            get 
            { 
                return pageSize; 
            }
            set
            {
                pageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }
        public int PageNumber { get; set; } = 1;
        public string? SearchTerm { get; set; } = string.Empty;
    }
}
