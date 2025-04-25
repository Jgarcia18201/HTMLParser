using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HTMLParser
{
    public class Session
    {
        public static void RestoreUserSelections(TextBox urFilePath, ut.Logging urLog)
        {
            var parm_one = new tvParameters();
            parm_one.PopulateFromFile(urLog);

            parm_one.AssignFilePath(urFilePath);
        }

        public static void SaveUserSelections(TextBox urFilePath, ut.Logging urLog)
        {
            var parm_one = new tvParameters();
            parm_one.PopulateOne(urFilePath, urLog);

            parm_one.WriteParameterFile(urLog);
        }
    }
}
