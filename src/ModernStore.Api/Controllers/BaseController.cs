using Microsoft.AspNetCore.Mvc;
using ModerStore.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;
        public BaseController(IUow uow)
        {
            _uow = uow;
        }
    }
}
