namespace Creator.FileLib.Helper
{
    internal static class DataCheckHelper
    {
        /// <summary>
        /// 驗證資料是否為空
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal static void Check(this string data, string dataName)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(dataName);
        }

        /// <summary>
        /// 驗證資料是否為空
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="ArgumentException"></exception>
        internal static void Check(this List<string> data)
        {
            if (data == null || data.Count < 1)
                throw new ArgumentException("資料不可為空");
        }
    }
}
