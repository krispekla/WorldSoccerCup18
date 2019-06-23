using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINForms.Utils
{
    public class Helper
    {
        internal static string GetCountryNameWithoutCode(string fullTeamName)
        {
            string[] temp = fullTeamName.Split();
            string teamName = "";
            for (int i = 0; i < temp.Length - 1; i++)
            {
                teamName += temp[i];
                if (i != temp.Length - 2) teamName += " ";
            }
            return teamName;
        }

        internal static string GetCountryCode(string selectedItem)
        {
            return selectedItem.Split().Last();
        }
    }
}
