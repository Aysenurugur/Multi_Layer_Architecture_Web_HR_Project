using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileTypeService fileTypeService;
        IMapper mapper;
        IFileService fileService;
        public FileController(IFileTypeService fileTypeService, IMapper mapper, IFileService fileService)
        {
            this.fileTypeService = fileTypeService;
            this.mapper = mapper;
            this.fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFile(FileDTO fileDTO) //test edildi
        {
            File file = mapper.Map<FileDTO, File>(fileDTO);
            await fileService.CreateFileAsync(file);
            return Ok(mapper.Map<File, FileDTO>(file));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilesByUserId(Guid id) //test edildi
        {
            try
            {
                IEnumerable<File> files = await fileService.GetUserFilesAsync(id);
                IEnumerable<FileDTO> fileDTOs = mapper.Map<IEnumerable<File>, IEnumerable<FileDTO>>(files);
                return Ok(fileDTOs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileById(Guid id) //test edild
        {
            try
            {
                File file = await fileService.GetFileByIdAsync(id);
                FileDTO fileDTO = mapper.Map<File, FileDTO>(file);
                return Ok(fileDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFile(FileDTO fileDTO) //test edildi
        {
            File fileToBeUpdated = await fileService.GetFileByIdAsync(fileDTO.FileID);
            fileDTO.CreatedDate = fileToBeUpdated.CreatedDate;
            File file = mapper.Map(fileDTO, fileToBeUpdated);
            await fileService.UpdateFileAsync(file);
            return Ok(mapper.Map<File, FileDTO>(file));
        }

        [HttpGet]
        public async Task<IActionResult> GetFileTypes() // test edildi
        {
            try
            {
                IEnumerable<FileTypeDTO> fileTypeDTOs = mapper.Map<IEnumerable<FileType>, IEnumerable<FileTypeDTO>>(await fileTypeService.GetFileTypesAsync());
                return Ok(fileTypeDTOs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFileType(FileTypeDTO fileTypeDTO) // test edildi
        {
            try
            {
                FileType fileType = mapper.Map<FileTypeDTO, FileType>(fileTypeDTO);
                fileType.CreatedDate = DateTime.Now;
                FileType newFileType = await fileTypeService.CreateFileTypeAsync(fileType);
                return Ok(mapper.Map<FileType, FileTypeDTO>(newFileType));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
