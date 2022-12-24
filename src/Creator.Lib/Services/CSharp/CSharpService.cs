using Creator.Lib.Interface;
using Creator.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator.Lib.Services.CSharp
{
    internal class CSharpService : ICreator
    {
        public string GetCode(string codeName, CodeTitle codeTitle, Dictionary<string, string> functionList)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCodeAsync(string codeName, CodeTitle codeTitle, Dictionary<string, string> functionList)
        {
            throw new NotImplementedException();
        }
    }
}
