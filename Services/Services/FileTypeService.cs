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
    public class FileTypeService : IFileTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        public FileTypeService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<FileType> CreateFileTypeAsync(FileType newFileType)
        {
            await unitOfWork.File.CreateFileTypeAsync(newFileType);
            await unitOfWork.CommitAsync();
            return newFileType;
        }

        public async Task<IEnumerable<FileType>> GetFileTypesAsync()
        {
            return await unitOfWork.File.GetFileTypesAsync();
        }
    }
}
