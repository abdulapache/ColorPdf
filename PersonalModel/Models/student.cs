using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalModel.Models
{
    public class student : UserBusinessModel
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

    }
}
