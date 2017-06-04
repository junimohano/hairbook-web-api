using AutoMapper;
using HairbookWebApi.Dtos;
using HairbookWebApi.Models;
using HairbookWebApi.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HairbookWebApi.Controllers
{
    //[Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MemoUploadsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _environment;


        public MemoUploadsController(IUnitOfWork unitOfWork, IMapper mapper, IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile uploadedFile, [FromQuery] int memoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _unitOfWork.Memos.AnyAsync(x => x.MemoId == memoId))
                return BadRequest();

            try
            {
                var uplaodPath = Path.Combine("uploads", "memos", $"{DateTime.Now.Ticks}_{new FileInfo(uploadedFile.FileName).Name}");

                if (uploadedFile.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, uplaodPath), FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    var memoUpload = new MemoUpload()
                    {
                        MemoId = memoId,
                        Path = uplaodPath,
                        CreatedDate = new DateTime()
                    };

                    _unitOfWork.MemoUploads.Add(memoUpload);
                    await _unitOfWork.Complete();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.MemoUploads.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                var fileInfo = new FileInfo(Path.Combine(_environment.WebRootPath, model.Path));
                if (fileInfo.Exists)
                    fileInfo.Delete();

                _unitOfWork.MemoUploads.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<MemoUpload, MemoUploadDto>(model));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}