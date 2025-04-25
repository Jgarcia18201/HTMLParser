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

            Session.RestoreUserSelections(this.TxtFilePath, logOne);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var validation = new System.Text.StringBuilder();
            var logOne = new ut.Logging();
            logOne.PopulateOne(System.Reflection.Assembly.GetEntryAssembly());

            Session.SaveUserSelections(this.TxtFilePath, logOne);

            TextFileMaintenance.GetNextFileName();
            TextFileMaintenance.ReadTextData();
            TextFileMaintenance.ReplaceKeyWord();
            TextFileMaintenance.WriteTextData();

            System.IO.File.WriteAllText(@"C:\HTMLParser\HTMLParser\CSharp\HTMLParser\Parameters-02.txt", 
                System.IO.File.ReadAllText(@"C:\HTMLParser\HTMLParser\CSharp\HTMLParser\Parameters.txt").Replace("b", "e")
                );

            validation.AppendLine("Done");
            this.txtResult.Text = validation.ToString();
        }
    }
}
