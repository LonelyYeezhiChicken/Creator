using Creator.Model.Enum;

namespace Creator.Lib.Interface
{
    internal interface ICreator
    {
        /// <summary>
        /// 生成某區塊程式碼
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="codeName">檔案名稱</param>
        /// <param name="functionList"></param>
        /// <returns></returns>
        string GetCode(CodeTitle codeTitle, string nameSpace, string codeName, Dictionary<string, string> functionList);
    }
}
