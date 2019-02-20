using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE.Models
{
    public class Sys_User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public int Sex { get; set; }
        public int UserType { get; set; }
        public string Department { get; set; }
        public string Duties { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public int IsEnable { get; set; }
        public DateTime LastLoginData { get; set; }
        public int LoginTimes { get; set; }
        public DateTime AddOn { get; set; }
        public string AddBy { get; set; }
        public int GlobalPageSize { get; set; }
    }
}
