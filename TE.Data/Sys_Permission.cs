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
    
    public partial class Sys_Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sys_Permission()
        {
            this.Sys_Role_Permission = new HashSet<Sys_Role_Permission>();
            this.Sys_User_Permission = new HashSet<Sys_User_Permission>();
        }
    
        public int PermissionID { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string RequestType { get; set; }
        public string ButtonName { get; set; }
        public string ModuleType { get; set; }
        public string ModuleName { get; set; }
        public string ModuleUrl { get; set; }
        public int FatherPermissionID { get; set; }
        public int PermissionType { get; set; }
        public int IsShow { get; set; }
        public int ShowOrder { get; set; }
        public string Remark { get; set; }
        public byte[] RowVersion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Role_Permission> Sys_Role_Permission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_User_Permission> Sys_User_Permission { get; set; }
    }
}
