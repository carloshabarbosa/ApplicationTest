using ApplicationTest.Data.Repositories;
using System;

namespace ApplicationTeste.Service.Services
{
    /// <summary>
    /// Class responsible to work with log 
    /// </summary>
    public class LogService
    {
        #region Singleton
        /// <summary>
        /// Singleton implementation
        /// </summary>
        private static LogService instance;
        public static LogService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogService();
                }
                return instance;
            }
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Method responsible to save a log
        /// </summary>
        /// <param name="classType">Class type that request a log</param>
        /// <param name="message">Message telling what happened</param>
        public void SaveLog(Type classType, string message)
        {
            LogRepository.Instance.SaveLog(BuildMessage(classType, message));
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// Helper to build a log message
        /// </summary>
        /// <param name="classType">Class type that request a log</param>
        /// <param name="message">Message telling what happened</param>
        /// <returns></returns>
        private string BuildMessage(Type classType, string message)
        {
            return $"{classType.ToString()}: {message}";
        }
        #endregion
    }
}
