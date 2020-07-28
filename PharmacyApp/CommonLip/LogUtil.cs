using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.CommonLip
{
    public static class LogUtil
    {
        public static ILog log = LogManager.GetLogger("CommonLog");

        /// <summary>
        /// Create the file name and sets the path. default path is bin/debug
        /// </summary>
        /// <param name="appenderName"></param>
        /// <param name="newFilename"></param>
        public static void CreateLogFile(string appenderName, string newFilename)
        {
            log4net.Repository.ILoggerRepository repository = LogManager.GetLoggerRepository();
            foreach (log4net.Appender.IAppender appender in repository.GetAppenders())
            {
                if (appender.Name.CompareTo(appenderName) == 0 && appender is log4net.Appender.FileAppender)
                {
                    log4net.Appender.FileAppender fileAppender = (log4net.Appender.FileAppender)appender;
                    fileAppender.File = System.IO.Path.Combine(fileAppender.File, newFilename);
                    fileAppender.ActivateOptions();
                }
            }
        }

        public static void WriteDebug(string customMessage)
        {
            log.Debug(customMessage);
        }
    }
}
