namespace Creator.FileLib.Interface
{
    internal interface IWriteService
    {
        /// <summary>
        /// 寫檔案(單筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="fileName">檔名</param>
        /// <param name="filePath">路徑</param>
        /// <param name="fileType">檔案類型</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        /// <returns></returns>
        Task WritString(string data, string fileName, string filePath, string fileType, bool append = true);
        /// <summary>
        /// 寫檔案(多筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="fileName">檔名</param>
        /// <param name="filePath">路徑</param>
        /// <param name="fileType">檔案類型</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        /// <returns></returns>
        Task WritList(List<string> data, string fileName, string filePath, string fileType, bool append = true);
    }
}
