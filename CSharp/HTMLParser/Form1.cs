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

        private void Form1_Load(object sender, EventArgs e) 
        {
            this.TxtFilePath.Text = @"C:\HTMLParser\HTMLParser\Sample\new 1.txt";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var validation = new System.Text.StringBuilder();
            var file_list = new Folders();
            file_list.ListFolders(validation);
            this.txtResult.Text = validation.ToString();

            /*var notify = new System.Text.StringBuilder();
            var assembly_version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            var versionNumber = assembly_version.Major;
            var ver_one = new ut.assembly_ver();
            ver_one.populate_one(assembly_version);
            this.txtResult.Text = ver_one.format_table();
            var path = this.TxtFilePath.Text;
            this.txtResult.Text = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8).Replace(((char)13).ToString(),
                string.Empty).Split((char)10).Length.ToString();
            //this.txtResult.Text = rfl.format_object(assembly_version);*/
        }
    }
}
