using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.Models;
using TE.Data;
using System.Data;
using System.Data.SqlClient;

namespace TE.Services
{
    public class SysUserService
    {
        public Sys_User CheckUserLogin(Sys_User sysUser)
        {
            string sql = $"select * from Sys_User Where UserID={sysUser.UserID} and PassWord={sysUser.PassWord} ";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            if (objReader.Read())
            {
                sysUser.UserName = objReader["UserName"].ToString();
                sysUser.Sex =Convert.ToInt32(objReader["Sex"]);
                sysUser.UserType = Convert.ToInt32(objReader["UserType"]);
                sysUser.MobilePhone = objReader["MobilePhone"].ToString();
                sysUser.Email= objReader["Email"].ToString();
            }
            else
            {
                sysUser = null;
            }

            return sysUser;
        }
    }
}
