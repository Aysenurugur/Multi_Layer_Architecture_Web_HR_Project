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
        Task<IEnumerable<File>> GetAllFilesAsync();
        Task<File> GetFileByIdAsync(Guid id);
        Task<File> CreateFileAsync(File newFile);
        Task UpdateFileAsync(File file);
        Task<IEnumerable<File>> GetUserFilesAsync(Guid userId);
    }
}
