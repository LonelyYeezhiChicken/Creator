using Creator.Lib.Interface;
using Creator.Model.Enum;
using Creator.Model.Interface;
using Creator.Model.Template.CSharp;

namespace Creator.Lib.Services.CSharp
{
    internal class CSharpService : ICreator
    {

        private string SetService(string nameSpace, string codeName, Dictionary<string, string> functionList)
        {
            ICodeGetter codeGetter = new CsService(nameSpace, codeName);
            return codeGetter.Get();
        }

        public string GetCode(CodeTitle codeTitle, string nameSpace, string codeName, Dictionary<string, string> functionList)
        {
            switch (codeTitle)
            {
                case CodeTitle.Service:
                    return SetService(nameSpace, codeName, functionList);
                //case CodeTitle.Repostiory:
                //    break;
                //case CodeTitle.Controller:
                //    break;
                //case CodeTitle.ApiController:
                //    break;
                //case CodeTitle.Dto:
                //    break;
                //case CodeTitle.Dao:
                //    break;
                //case CodeTitle.Model:
                //    break;
                //case CodeTitle.ViewModel:
                //    break;
                //case CodeTitle.IService:
                //    break;
                //case CodeTitle.IRepostiory:
                //    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
