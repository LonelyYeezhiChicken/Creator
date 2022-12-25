using Creator.FileLib;
using Creator.Lib.Interface;
using Creator.Lib.Services.CSharp;
using Creator.Model.Enum;

namespace Creator.Lib
{
    public interface ICreatorPorovider
    {
        /// <summary>
        /// 取得C# code
        /// </summary>
        /// <param name="codeTitle"></param>
        /// <param name="nameSpace"></param>
        /// <param name="codeName"></param>
        /// <param name="functionList"></param>
        /// <returns></returns>
        Task GetCsharpCode(string codeTitle, string nameSpace, string codeName, Dictionary<string, string> functionList);
    }

    public class CreatorPorovider: ICreatorPorovider
    {
        private readonly IFilerPorovider filerPorovider;

        private string Path { get; set; }

        public CreatorPorovider(string path)
        {
            filerPorovider = new FilerPorovider();
            Path = string.IsNullOrEmpty(path) ? throw new AggregateException(nameof(path)) : path;
        }

        /// <summary>
        /// 取得C# code
        /// </summary>
        /// <param name="codeTitle"></param>
        /// <param name="nameSpace"></param>
        /// <param name="codeName"></param>
        /// <param name="functionList"></param>
        /// <returns></returns>
        public async Task GetCsharpCode(string codeTitle, string nameSpace, string codeName, Dictionary<string, string> functionList)
        {
            _ = Enum.TryParse(codeTitle, out CodeTitle ct);
            ICreator creator = new CSharpService();
            string code = creator.GetCode(ct, nameSpace, codeName, functionList);

            filerPorovider.Create(Path, codeName, "cs");
            await filerPorovider.Write(code, false);
        }

    }
}
