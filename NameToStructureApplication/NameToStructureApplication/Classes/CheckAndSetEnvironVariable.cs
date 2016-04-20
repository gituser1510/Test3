#region Import Assemblies

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using chemaxon.license;

#endregion

namespace NameToStructureApplication
{
    class CheckAndSetEnvironVariable
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        // The declaration is similar to the SDK function
        public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

        public static bool SetEnvironmentVariableEx(string environmentVariable, string variableValue)
        {
            bool blStatus = false;
            try
            {
                string strEnv = Environment.GetEnvironmentVariable(environmentVariable);
                if (strEnv == null)
                {
                    // Get the write permission to set the environment variable.
                    EnvironmentPermission environmentPermission = new EnvironmentPermission(EnvironmentPermissionAccess.Write, environmentVariable);
                    environmentPermission.Demand();
                    blStatus = SetEnvironmentVariable(environmentVariable, variableValue);
                    return blStatus;
                }
            }
            catch (SecurityException ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        public static bool SetChemaxonLicenseFilePath(string licFilePath)
        {
            bool blStatus = false;
            try
            {
                LicenseManager.setLicenseFile(licFilePath);
                return blStatus = true;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }
    }
}
