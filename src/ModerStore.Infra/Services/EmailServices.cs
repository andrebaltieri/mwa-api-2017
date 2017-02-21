using ModernStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerStore.Infra.Services
{
    public class EmailServices : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            //Enviar E-mail :)
        }
    }
}
