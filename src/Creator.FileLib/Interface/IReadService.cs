namespace Creator.FileLib.Interface
{
    internal interface IReadService
    {
        /// <summary>
        /// 讀取檔案
        /// 讀成一行
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="fileName">檔名</param>
        /// <param name="fileType">副檔名</param>
        /// <returns>返回檔案內容</returns>
        Task<string> ReadRow(string path, string fileName, string fileType);
        /// <summary>
        /// 讀取檔案
        /// 分行讀取
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="fileName">檔名</param>
        /// <param name="fileType">副檔名</param>
        /// <returns></returns>
        Task<IEnumerable<string>> ReadToList(string path, string fileName, string fileType);
    }
}
