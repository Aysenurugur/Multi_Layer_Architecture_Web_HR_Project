using Core.Entities.Base_Entities;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class FileType : Title_Content
    {
        public Guid FileTypeID { get; set; }

        public ICollection<File> Files { get; set; } //nav prop
    }
}
