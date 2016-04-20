#region Import Assemblies

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace NameToStructureApplication
{
    public static class ConvertToBase64
    {
        public static string GetConvertedMolString(string MolString)
        {
            string strConv64 = "";
            try
            {
                if (MolString != "")
                {

                    byte[] byteArr = StringToByteArray(MolString);
                    if (byteArr != null)
                    {
                        strConv64 = Convert.ToBase64String(byteArr);
                    }
                }
                return strConv64;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return strConv64;
        }

        public static byte[] StringToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
    }
}
