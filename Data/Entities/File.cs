using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class File 
    {
        public int FileID { get; set; }
        public Guid UserID { get; set; }
        public int FileTypeID { get; set; }
        public byte[] PDFFile { get; set; }

        public FileType FileType { get; set; }
        //user nav prop gelecek
    }
}
