using System;
using System.IO;

namespace Template.WPF.Models
{
    public class Log
    {
        private string sLogPath = Environment.CurrentDirectory;

        /// <summary>
        /// 로그 기록
        /// </summary>
        /// <param name="Content">로그 내용</param>
        public void WirteLog(string Content)
        {
            string sWritePath = Path.Combine(sLogPath, $"ERR_{DateTime.Now.Date:yyyy-MM-dd}.txt");

            if (File.Exists(sWritePath))
            {
                File.AppendAllText(sWritePath, $"[{DateTime.Now}] {Content} \n");
            }
            else
            {
                File.Create(sWritePath).Close();
                WirteLog(Content);
            }
        }
    }
}
