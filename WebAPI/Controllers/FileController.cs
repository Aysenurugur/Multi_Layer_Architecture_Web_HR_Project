using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileTypeService fileTypeService;
        public FileController(IFileTypeService _fileTypeService)
        {
            this.fileTypeService = _fileTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFileTypes() // test edildi
        {
            return Ok(await fileTypeService.GetFileTypes());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFileType(FileType fileType) // test edildi
        {
            fileType.FileTypeID = Guid.NewGuid();
            fileType.CreatedDate = DateTime.Now;
            var newFileType = await fileTypeService.CreateFileType(fileType);
            return Ok(newFileType);
        }
    }
}
