using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InvitationDTO
    {

        public int IdInvitation { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? FinalPrice { get; set; }
        public string Location { get; set; }
        public int? StatusId { get; set; }
      
        public int? IdSuplier { get; set; }
        public int? IdCustomer { get; set; }

        public string Summery { get; set; }

    }
}
