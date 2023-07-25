using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.GoogleClendar
{
   public class ClendarEvent
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string EmailTo { get; set; }
      
    }
}
