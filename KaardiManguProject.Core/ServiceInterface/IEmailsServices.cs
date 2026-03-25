using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaardiManguProject.Core.Dto;

namespace KaardiManguProject.Core.ServiceInterface
{
    public interface IEmailsServices
    {
        void SendEmail(EmailDTO dto);
    }
}
