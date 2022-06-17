using System.Text;

namespace GenshinServerSwitcher
{
    /// <summary>
    /// INI 读写操作
    /// </summary>
    internal class INI
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder lpReturnedString, int nSize, string path);

        /// <summary>
        /// 向 INI 文件中写入信息
        /// </summary>
        /// <param name="section">写入节</param>
        /// <param name="key">写入键</param>
        /// <param name="value">写入值</param>
        /// <param name="path">写入文件路径</param>
        public static void Write(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>
        /// 读取 INI 文件信息
        /// </summary>
        /// <param name="section">读取节</param>
        /// <param name="key">读取键</param>
        /// <param name="def">失败时默认返回值</param>
        /// <param name="path">读取文件路径</param>
        /// <returns>读取值</returns>
        public static string Read(string section, string key, string def, string path)
        {
            StringBuilder str = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, str, 1024, path);
            return str.ToString();
        }
    }
}
