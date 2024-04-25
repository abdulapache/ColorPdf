using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalModel.Models
{
    public class ApiResponseModel
    {
        public string message { get; set; }
        public bool status { get; set; }
        public object data { get; set; }
    }
}
