using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configuracao
{
    public class ResultApi<T>
    {
        public T Return  { get; set; }
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public IList<string> ErrorList { get; set; }

        public ResultApi(string message, T returnObject, bool isOk, IList<string> errorList = null)
        {
            Return = returnObject;
            IsOk = isOk;
            Message = message;
            ErrorList = errorList;
        }
    }
}
