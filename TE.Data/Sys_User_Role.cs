//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TE.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sys_User_Role
    {
        public int URID { get; set; }
        public string UserID { get; set; }
        public int RoleID { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual Sys_Role Sys_Role { get; set; }
        public virtual Sys_User Sys_User { get; set; }
    }
}