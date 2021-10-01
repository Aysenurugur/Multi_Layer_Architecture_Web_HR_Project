using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IFileTypeService
    {
        Task<IEnumerable<FileType>> GetFileTypes();
        Task<FileType> CreateFileType(FileType newFileType);
    }
}
