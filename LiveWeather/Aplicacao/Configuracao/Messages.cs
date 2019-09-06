
using Application.Configuracao.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Configuracao
{
    public class Messages : IMessages
    {
        public IList<string> ErrorList { get; set; }

        public Messages()
        {
            ErrorList = new List<string>();
        }

        public bool ExistError => ErrorList.Any();
    }
}
