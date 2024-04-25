using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalModel.Models
{
   
    public class PdfColorResponse
    {
        public string message { get; set; }
        public string aecbdfilePath { get; set; }
        public bool status { get; set; }
        public int customerId { get; set; }
        public int transId { get; set; }
        public string? kycfilePath { get; set; }
    }
}
