using Creator.FileLib.Interface;
using Creator.FileLib.Service;

namespace Creator.FileLib
{
    public interface IFilerPorovider
    {
        /// <summary>
        /// 寫檔案(單筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        Task Write(string data, bool append = true);
        /// <summary>
        /// 寫檔案(多筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        Task Write(List<string> data, bool append = true);
        /// <summary>
        /// 讀取檔案
        /// 讀成一行
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="fileName">檔名</param>
        /// <param name="fileType">副檔名</param>
        /// <returns>返回檔案內容</returns>
        Task<string> Read();
        /// <summary>
        /// 讀取檔案
        /// 分行讀取
        /// </summary>
        /// <returns>返回檔案內容</returns>
        Task<IEnumerable<string>> ReadToList();
    }



    public class FilerPorovider : IFilerPorovider
    {
        private readonly IReadService readService;
        private readonly IWriteService writeService;

        /// <summary>
        /// 路徑
        /// </summary>
        public string Path { get; private set; }
        /// <summary>
        /// 檔案
        /// </summary>
        public string FileName { get; private set; }
        /// <summary>
        /// 副檔名
        /// </summary>
        public string FileType { get; private set; }


        public FilerPorovider()
        {
            readService = new ReadService();
            writeService = new WriteService();
        }

        /// <summary>
        /// 設定路徑, 檔案, 副檔名
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="fileName">檔案</param>
        /// <param name="fileType">副檔名</param>
        public void Create(string path, string fileName, string fileType)
        {
            Path = path;
            FileName = fileName;
            FileType = fileType;
        }

        /// <summary>
        /// 寫檔案(單筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        public async Task Write(string data, bool append = true)
        {
            await writeService.WritString(data, FileName, Path, FileType, append);
        }
        /// <summary>
        /// 寫檔案(多筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        public async Task Write(List<string> data, bool append = true)
        {
            await writeService.WritList(data, FileName, Path, FileType, append);
        }

        /// <summary>
        /// 讀取檔案
        /// 讀成一行
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="fileName">檔名</param>
        /// <param name="fileType">副檔名</param>
        /// <returns>返回檔案內容</returns>
        public async Task<string> Read()
        {
            return await readService.ReadRow(FileName, Path, FileType);
        }
        /// <summary>
        /// 讀取檔案
        /// 分行讀取
        /// </summary>
        /// <returns>返回檔案內容</returns>
        public async Task<IEnumerable<string>> ReadToList()
        {
            return await readService.ReadToList(FileName, Path, FileType);
        }
    }
}
