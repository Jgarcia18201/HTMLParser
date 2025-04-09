using fn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HTMLParser
{
    public class tvParameters : List<tvParameters.Row>
    {
        public class Row
        {
            public string TxtFilePath { get; set; }
        }

        public Row addNewRow()
        {
            var nrow = new Row();
            this.Add(nrow);
            return nrow;
        }

        public string format_table()
        {
            return rfl<Row>.FormatObjectList(this);
        }

        public void PopulateOne(TextBox ur_text_box, ut.Logging logOne)
        {
            var nrow = this.addNewRow();
            nrow.TxtFilePath = ur_text_box.Text;
            logOne.LogText(this.format_table());
        }

        public void PopulateFromFile(ut.Logging logOne)
        {
            foreach (var row in logOne)
            {
                var nrow = this.addNewRow();
                nrow.TxtFilePath = System.IO.File.ReadAllText(Path.Combine(row.parameters_folder, "Parameters.txt"));
            }
            logOne.LogText(this.format_table());
        }

        public void AssignFilePath(TextBox ur_text_box)
        {
            foreach (var row in this)
            {
                ur_text_box.Text = row.TxtFilePath;
            }
        }

        public void WriteParameterFile(ut.Logging logOne)
        {
            foreach (var row in logOne)
            {
                foreach (var parm_row in this)
                {
                    File.WriteAllText(Path.Combine(row.parameters_folder, "Parameters.txt"), parm_row.TxtFilePath);
                }
            }

        }
    }
}

