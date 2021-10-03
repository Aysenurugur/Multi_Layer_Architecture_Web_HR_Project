using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork unitOfWork;
        public FileService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<File> CreateFileAsync(File newFile)
        {
            newFile.CreatedDate = DateTime.Now;
            await unitOfWork.File.AddAsync(newFile);
            await unitOfWork.CommitAsync();
            return newFile;
        }

        public async Task<File> GetFileByIdAsync(Guid id)
        {
            return await unitOfWork.File.GetByIDAsync(id);
        }

        public async Task<IEnumerable<File>> GetAllFilesAsync()
        {
            return await unitOfWork.File.GetAllAsync();
        }

        public async Task UpdateFileAsync(File file)
        {
            unitOfWork.File.Update(file);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<File>> GetUserFilesAsync(Guid userId)
        {
            List<File> files = unitOfWork.File.List(x => x.UserID == userId).ToList();

            return await Task.FromResult(files);
        }
    }
}
