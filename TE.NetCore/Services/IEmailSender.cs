using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TE.NetCore.Services
{
    public interface IEmailSender
    {
        Task SenEmailAsync(string email, string subject, string message);
    }
}
