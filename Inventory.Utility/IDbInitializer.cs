using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Inventory.Utility
{
    public interface IDbInitializer
    {
        Task CreateSuperAdmin();
        Task SendEmail(string FromEmail,
            string Name,
            string Message, string toEmail, string toName, string smtpUser,
            string smtpPassword, string smtpHost, string smtpPort, bool smtpSSL);
        Task<string> UploadFile(List<IFormFile> files,
            IHostEnvironment env, string Directory);

    }
}
