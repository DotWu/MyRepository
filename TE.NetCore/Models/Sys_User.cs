using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.NetCore.Models
{
    public class Sys_User
    {
        public Sys_User()
        {
            
        }
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public int Sex { get; set; }
        public int UserType { get; set; }
        public int IsEnable { get; set; }
        public int LoginTimes { get; set; }
        public DateTime AddOn { get; set; }
        public string AddBy { get; set; }
        public int GlobalPageSize { get; set; }
    }
}
