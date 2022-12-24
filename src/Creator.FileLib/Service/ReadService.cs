using Creator.FileLib.Helper;
using Creator.FileLib.Interface;

namespace Creator.FileLib.Service
{
    internal class ReadService : IReadService
    {
        /// <summary>
        /// 讀取檔案
        /// 讀成一行
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="fileName">檔名</param>
        /// <param name="fileType">副檔名</param>
        /// <returns>返回檔案內容</returns>
        public async Task<string> ReadRow(string path, string fileName, string fileType)
        {
            path.Check(nameof(path));
            fileName.Check(nameof(fileName));
            fileType.Check(nameof(fileType));

            string req = "";
            //重組檔名
            string fullName = $"{fileName}.{fileType}";
            //重組路徑
            string fullPath = path + fullName;
            try
            {
                //讀出檔案
                using StreamReader sr = new(fullPath);
                //讀出資料                   
                req = await sr.ReadToEndAsync();
                //關閉流
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("ReadRow error = " + ex.ToString());
            }
            return req;
        }

        /// <summary>
        /// 讀取檔案
        /// 分行讀取
        /// </summary>
        /// <param name="path">路徑</param>
        /// <param name="fileName">檔名</param>
        /// <param name="fileType">副檔名</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> ReadToList(string path, string fileName, string fileType)
        {
            path.Check(nameof(path));
            fileName.Check(nameof(fileName));
            fileType.Check(nameof(fileType));

            List<string> req = new();
            //重組檔名
            string fullName = $"{fileName}.{fileType}";
            //重組路徑
            string fullPath = path + fullName;
            try
            {
                //讀出檔案
                using StreamReader sr = new(fullPath);
                //讀出資料                 
                while (sr.EndOfStream == false)
                {
                    req.Add(await sr.ReadLineAsync() ?? "");
                }
                //關閉流
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("ReadToList error = " + ex.ToString());
            }
            return req;
        }
    }
}
