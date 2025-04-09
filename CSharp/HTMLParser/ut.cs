using fn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ut
{    
    public class Logging
        : List<Logging.Row>
    {
        public class Row
        {
            public string exe_location { get; set; }
            public string logging_folder { get; set; }
            public string log_file { get; set; }
            public string log_path { get; set; }
            public string parameters_folder { get; set; }
        }

        public void LogText(string ur_txt)
        {
            foreach (var row in this)
            {
                System.IO.File.AppendAllText(row.log_path, $"{ur_txt}{System.Environment.NewLine}{System.Environment.NewLine}");
            }
        }
        public Row addNewRow()
        {
            var nrow = new Row();
            this.Add(nrow);
            return nrow;
        }
        public void PopulateOne(System.Reflection.Assembly ur_assembly)        
        {
            var nrow = this.addNewRow();
            nrow.exe_location = ur_assembly.Location;
            nrow.parameters_folder = System.IO.Path.GetDirectoryName(nrow.exe_location).Replace(@"\bin\Debug", string.Empty);
            nrow.logging_folder = System.IO.Path.Combine(
                nrow.parameters_folder,
                "logs");
            if (System.IO.Directory.Exists(nrow.logging_folder) == false)
            {
                System.IO.Directory.CreateDirectory(nrow.logging_folder);
            }
            nrow.log_file = $"logfile_{System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt";
            nrow.log_path = System.IO.Path.Combine(nrow.logging_folder, nrow.log_file);
        }        

        public string format_table()
        {
            return rfl<Row>.FormatObjectList(this);
        }
    }

}
