using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListBaseResult<T>
    {
        public bool IsError { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<T> Data { get; set; }
    
     }
}
