using Creator.FileLib.Helper;
using Creator.FileLib.Interface;

namespace Creator.FileLib.Service
{
    internal class WriteService : IWriteService
    {
        /// <summary>
        /// 檢查並建立目錄
        /// </summary>
        /// <param name="directory">目錄路徑</param>
        private static void CheckDirectory(string directory)
        {
            // 檢查目錄是否存在
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);// 不存在就建立
        }

        /// <summary>
        /// 檢查並建立檔案
        /// </summary>
        /// <param name="filePath"></param>
        private static void CheckFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                using FileStream fileCreate = new(filePath, FileMode.Create);
                fileCreate.Close();
            }
        }


        /// <summary>
        /// 寫檔案(單筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="fileName">檔名</param>
        /// <param name="filePath">路徑</param>
        /// <param name="fileType">檔案類型</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        /// <returns></returns>
        public async Task WritString(string data, string fileName, string filePath, string fileType, bool append = true)
        {
            data.Check(nameof(data));
            filePath.Check(nameof(filePath));
            fileName.Check(nameof(fileName));
            fileType.Check(nameof(fileType));

            // 檢查目錄
            CheckDirectory(filePath);

            //重組檔名
            string fullName = $"{fileName}.{fileType}";          

            //重組路徑
            string fullPath = filePath + fullName;
            
            // 檢查檔案
            CheckFile(fullPath);

            try
            {
                //讀出檔案
                using StreamWriter sw = new(fullPath, append);
                //讀出資料                   
                await sw.WriteLineAsync(data);
                //關閉流
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("WritString error = " + ex.ToString());
            }
        }
        /// <summary>
        /// 寫檔案(多筆)
        /// </summary>
        /// <param name="data">資料</param>
        /// <param name="fileName">檔名</param>
        /// <param name="filePath">路徑</param>
        /// <param name="fileType">檔案類型</param>
        /// <param name="Append">是否覆蓋(true:覆寫 / false:重寫 )</param>
        /// <returns></returns>
        public Task WritList(List<string> data, string fileName, string filePath, string fileType, bool append = true)
        {
            data.Check();
            filePath.Check(nameof(filePath));
            fileName.Check(nameof(fileName));
            fileType.Check(nameof(fileType));

            // 檢查目錄
            CheckDirectory(filePath);

            //重組檔名
            string fullName = $"{fileName}.{fileType}";

            //重組路徑
            string fullPath = filePath + fullName;

            // 檢查檔案
            CheckFile(fullPath);

            try
            {
                //讀出檔案
                using StreamWriter sw = new(fullPath, append);
                //寫入資料                   
                data.ForEach(async x => await sw.WriteLineAsync(x));
                //關閉流
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("WritString error = " + ex.ToString());
            }

            return Task.CompletedTask;
        }
    }
}
