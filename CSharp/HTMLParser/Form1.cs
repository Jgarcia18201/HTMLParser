using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            var notify = new System.Text.StringBuilder();
            var assembly_version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            var versionNumber = assembly_version.Major;
            //foreach (var property_def in assembly_version.GetType().GetProperties())
            //{
            //    if (string.Equals(property_def.Name, "major", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        //notify.AppendLine($"{property_def.Name}: {property_def.GetValue(assembly_version, null).ToString()}");
            //        versionNumber = property_def.GetValue(assembly_version, null).ToString();
            //    }
            //}
            this.txtResult.Text = $"{nameof(versionNumber)}: {versionNumber}";
        }
    }
}
