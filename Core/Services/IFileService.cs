using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IFileService
    {
        Task<IEnumerable<File>> GetAllFiles();
        Task<File> GetFileById(Guid id);
        Task<File> CreateFile(File newFile);
        Task UpdateFile(File file, File updateFile);
        Task DeleteFile(File file);
    }
}
