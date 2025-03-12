using fn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ut
{
    public class assembly_ver: System.Collections.Generic.List<string> 
    {
        public assembly_ver Major { get; set; }
        public assembly_ver Minor { get; set; }
        public assembly_ver Build { get; set; }
        public assembly_ver Revision { get; set; }
        public void populate_one(System.Version ur_version)
        {
            //this.major = ur_version.Major.ToString();
            rfl.AssignStrings(this, ur_version);
        }

        public string format_table()
        {
            return rfl.format_table(this);
        }
    }
}
