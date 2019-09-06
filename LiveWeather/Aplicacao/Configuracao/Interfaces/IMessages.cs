using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configuracao.Interfaces
{
    public interface IMessages
    {
        IList<string> ErrorList { get; set; }
        bool ExistError { get; }
    }
}
