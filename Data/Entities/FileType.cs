using Data.Entities.Base_Entities;
using System.Collections.Generic;

namespace Data.Entities
{
    public class FileType : Title_Content
    {
        public int FileTypeID { get; set; }

        public ICollection<File> Files { get; set; } //nav prop
    }
}
