using fn;
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
            var ver_one = new ut.assembly_ver();
            ver_one.populate_one(assembly_version);
            this.txtResult.Text = ver_one.format_table();
            //this.txtResult.Text = rfl.format_object(assembly_version);
        }
    }
}
