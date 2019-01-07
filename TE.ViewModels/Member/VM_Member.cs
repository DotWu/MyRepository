using System;
using System.Collections.Generic;
using System.Text;

namespace TE.ViewModels.Member
{
    public class VM_Member
    {
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public string IDCard { get; set; }
        public string FudMagAccID { get; set; }

        public int userId { get; set; }

        /// <summary>
        /// 可用
        /// </summary>
        public decimal UsableMoney { get; set; }
        /// <summary>
        /// 在投
        /// </summary>
        public decimal RetrieveMoney { get; set;}
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime AddOn { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 1是借款人，0出借人
        /// </summary>
        public int CanBorrow { get; set; }
        /// <summary>
        /// 10已激活，，，0未激活
        /// </summary>
        public int CPnRActiveState { get; set; }

    }

}
