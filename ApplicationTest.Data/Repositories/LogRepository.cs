using ApplicationTest.Data.Common;
using System;
using System.IO;

namespace ApplicationTest.Data.Repositories
{
    /// <summary>
    /// Class responsible for persist the logs
    /// </summary>
    public class LogRepository
    {
        #region Singleton
        /// <summary>
        /// Singleton implementation
        /// </summary>
        private static LogRepository instance;
        public static LogRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogRepository();
                }
                return instance;
            }
        }

        #endregion

        #region PublicMethods
        /// <summary>
        /// Method responsible to save a log
        /// </summary>
        /// <param name="message">message to save </param>
        public void SaveLog(string message)
        {
            var path = GetLogFileName();
            if (!FileUtils.ValidateFile(path))
            {
                FileUtils.CreateFile(path);
            }

            using (var file = new StreamWriter(path, true))
            {
                file.WriteLine(message);

                file.Flush();
                file.Close();
            }
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Method responsible to get a log file name
        /// </summary>
        /// <returns>The log filename</returns>
        private string GetLogFileName()
        {
            var path = FileUtils.GetLogPath();
            return $"{path}/log_{DateTime.Now.Date.ToString("yyyy_MM_dd")}.txt";
        }
        #endregion

    }
}
