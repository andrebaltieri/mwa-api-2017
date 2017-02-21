using FluentValidator;
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

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception)
                {
                    // Logar o erro (Elmah)
                    return BadRequest(new
                    {
                        success = false,
                        erros = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    erros = notifications
                });
            }
        }
    }
}
