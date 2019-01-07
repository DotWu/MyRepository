using System;
using System.Collections.Generic;
using System.Text;

namespace TE.ViewModels.Member
{
    public class VM_InvestInfo
    {
        /// <summary>
        /// 借款主键
        /// </summary>
        public string LoanBillID { get; set; }

        /// <summary>
        /// 投资主键
        /// </summary>
        public int InvestInfoID { get; set; }

        /// <summary>
        /// 投资项目
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 借款项目状态
        /// </summary>
        public int LoanBillState { get; set; }

        /// <summary>
        /// 期限
        /// </summary>
        public int TermLength { get; set; }

        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney { get; set; }

        /// <summary>
        /// 年华利率
        /// </summary>
        public string YearRate { get; set; }

        /// <summary>
        /// 资金筹集进度
        /// </summary>
        public int InvestPercent { get; set; }

        /// <summary>
        /// 预期收益
        /// </summary>
        public decimal ReturnMoney { get; set; }

        /// <summary>
        /// 待收金额
        /// </summary>
        public decimal RepayAmt { get; set; }

        /// <summary>
        /// 已收金额
        /// </summary>
        public decimal RepayedAmt { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime BorrEndDate { get; set; }

        /// <summary>
        /// 合同链接
        /// </summary>
        public string PartOfContractLink { get; set; }

        /// <summary>
        /// 投资时间
        /// </summary>
        public DateTime InvestDate { get; set; }

        /// <summary>
        /// 变现状态
        /// </summary>
        public int RealizeState { get; set; }

        /// <summary>
        /// 状态文字
        /// </summary>
        public string RealizeStateTxt { get; set; }
    }
}
