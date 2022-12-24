using Creator.Model.Enum;

namespace Creator.Lib.Interface
{
    internal interface ICreator
    {
        /// <summary>
        /// 生成某區塊程式碼
        /// </summary>
        /// <param name="codeName">檔案名稱</param>
        /// <param name="codeTitle"></param>
        /// <param name="functionList"></param>
        /// <returns></returns>
        string GetCode(string codeName, CodeTitle codeTitle, Dictionary<string, string> functionList);

        /// <summary>
        /// 非同步生成某區塊程式碼
        /// </summary>
        /// <param name="codeName">檔案名稱</param>
        /// <param name="codeTitle"></param>
        /// <param name="functionList"></param>
        /// <returns></returns>
        Task<string> GetCodeAsync(string codeName, CodeTitle codeTitle, Dictionary<string, string> functionList);
    }
}
