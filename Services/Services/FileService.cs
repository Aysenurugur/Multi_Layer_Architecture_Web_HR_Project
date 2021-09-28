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

        public async Task<File> CreateFile(File newFile)
        {
            newFile.FileID = new Guid();
            await unitOfWork.File.AddAsync(newFile);
            return newFile;
        }

        public async Task<File> GetFileById(Guid id)
        {
            return await unitOfWork.File.GetByIDAsync(id);
        }

        public async Task<IEnumerable<File>> GetAllFiles()
        {
            return await unitOfWork.File.GetAllAsync();
        }

        public async Task UpdateFile(File file)
        {
            unitOfWork.File.Update(file);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<File>> GetUserFiles(Guid userId)
        {
            List<File> files = (List<File>)unitOfWork.File.List(x => x.UserID == userId);

            return await Task.FromResult(files);
        }
    }
}
