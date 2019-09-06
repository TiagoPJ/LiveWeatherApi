using Application.Configuracao;
using Application.Configuracao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public IMessages _msgs { get; }

        public BaseController(IMessages msgs) => _msgs = msgs;

        protected ResultApi<T> FormatResult<T>(T obj)
        {
            if (_msgs.ExistError)
            {
                return new ResultApi<T>("An error occurred, operation canceled.", obj, false, _msgs.ErrorList);
            }
            else
            {
                return new ResultApi<T>("Method successfully executed.", obj, true);
            }
        }
    }
}
