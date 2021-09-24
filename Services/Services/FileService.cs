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
            await unitOfWork.File.AddAsync(newFile);
            return newFile;
        }

        public async Task DeleteFile(File file)
        {
            unitOfWork.File.RemoveAsync(file);
            await unitOfWork.CommitAsync();
        }

        public async Task<File> GetFileById(string id)
        {
            return await unitOfWork.File.GetByIDAsync(id);
        }

        public async Task<IEnumerable<File>> GetAllFiles()
        {
            return await unitOfWork.File.GetAllAsync();
        }

        public async Task UpdateFile(File file, File updateFile)
        {
            updateFile.PDFFile = file.PDFFile;
            updateFile.FileID = file.FileID;
            await unitOfWork.CommitAsync();
        }
    }
}
