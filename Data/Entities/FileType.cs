using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FileType : Title_Content
    {
        public int FileTypeID { get; set; }

        public ICollection<File> Files { get; set; } //nav prop
    }
}
