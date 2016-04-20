#region Import Assemblies

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using NLog.Targets.Wrappers;
using NLog.Targets;

#endregion

namespace NameToStructureApplication
{
    public static class PepsiLiteErrorHandling
    {
        public static void WriteErrorLog(string message)
        {
            FileTarget target = new FileTarget();
            target.Layout = "${longdate} ${logger} ${message}";
            target.FileName = "${basedir}/Trace/NTSLog.txt";
            target.KeepFileOpen = false;
            target.Encoding = "iso-8859-2";

            AsyncTargetWrapper wrapper = new AsyncTargetWrapper();
            wrapper.WrappedTarget = target;
            wrapper.QueueLimit = 5000;
            wrapper.OverflowAction = AsyncTargetWrapperOverflowAction.Discard;

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(wrapper, NLog.LogLevel.Trace);

            Logger logger = LogManager.GetLogger("NameToStructure");
            logger.Trace(message);
        }
    }
}
