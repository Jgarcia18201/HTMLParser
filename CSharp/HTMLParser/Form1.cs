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
            var logOne = new ut.Logging();
            logOne.PopulateOne(System.Reflection.Assembly.GetEntryAssembly());

            var parm_one = new tvParameters();
            parm_one.PopulateFromFile(logOne);

            parm_one.AssignFilePath(this.TxtFilePath);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var validation = new System.Text.StringBuilder();
            var logOne = new ut.Logging();
            logOne.PopulateOne(System.Reflection.Assembly.GetEntryAssembly());

            var parm_one = new tvParameters();
            parm_one.PopulateOne(this.TxtFilePath, logOne);

            parm_one.WriteParameterFile(logOne);

            validation.AppendLine("Done");
            this.txtResult.Text = validation.ToString();
        }
    }
}
