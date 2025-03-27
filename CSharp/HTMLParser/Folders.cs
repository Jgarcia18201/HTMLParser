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
        public void ListFolders(System.Text.StringBuilder ret_validation)
        {
            ret_validation.AppendLine("Folder List: ");
            {
                var nrow = this.addNewRow();
                nrow.path = "abc";
                nrow.name = "def";
            }
            {
                var nrow = this.addNewRow();
                nrow.path = "123";
                nrow.name = "456";
            }
            ret_validation.AppendLine(fn.rfl<FolderEntry>.FormatObjectList(this));
        }
    }
}
