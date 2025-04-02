using fn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLParser
{
    public class Folders: List<Folders.FolderEntry>
    {
        public class FolderEntry
        {
            public string path { get; set; }
            public string name { get; set; }
        }
        public FolderEntry addNewRow()
        {
            var nrow = new FolderEntry();
            this.Add(nrow);
            return nrow;
        }
        public void ListFolders(System.Text.StringBuilder ret_validation,
            string ur_path)
        {
            ret_validation.AppendLine("Folder List: ");
            if (System.IO.Directory.Exists(ur_path))
            {
                var nrow = this.addNewRow();
                nrow.path = "abc";
                nrow.name = "def";
            }
            ret_validation.AppendLine(fn.rfl<FolderEntry>.FormatObjectList(this));
        }
    }
}
