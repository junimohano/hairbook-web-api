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
using HairbookWebApi.Auth;
using HairbookWebApi.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace HairbookWebApi.Controllers
{
    [Authorize(AuthOption.TokenType)]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostUploadsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _environment;


        public PostUploadsController(IUnitOfWork unitOfWork, IMapper mapper, IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpPost("{postId}")]
        public async Task<IActionResult> Post([FromRoute] int postId, IFormFile uploadedFile, string memo, UploadCategoryType uploadCategoryType, UploadFileType uploadFileType, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _unitOfWork.Posts.AnyAsync(x => x.PostId == postId))
                return BadRequest();

            try
            {
                var uplaodPath = Path.Combine("uploads", "posts", $"{DateTime.Now.Ticks}_{new FileInfo(uploadedFile.FileName).Name}");

                if (uploadedFile.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, uplaodPath), FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    var postUpload = new PostUpload()
                    {
                        PostId = postId,
                        Path = uplaodPath,
                        Memo = memo,
                        UploadCategoryType = uploadCategoryType,
                        UploadFileType = uploadFileType,
                        CreatedDate = DateTime.Now,
                        CreatedUserId = userId
                    };

                    await _unitOfWork.PostUploads.AddAsync(postUpload);
                    await _unitOfWork.Complete();

                    return Ok(postUpload);
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
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _unitOfWork.PostUploads.FindAsync(id);
            if (model == null)
                return NotFound();

            try
            {
                var fileInfo = new FileInfo(Path.Combine(_environment.WebRootPath, model.Path));
                if (fileInfo.Exists)
                    fileInfo.Delete();

                _unitOfWork.PostUploads.Delete(model);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(_mapper.Map<PostUpload, PostUploadDto>(model));
        }

        [HttpPut("{postUploadId}")]
        public async Task<IActionResult> Put([FromRoute] int postUploadId, string memo, UploadCategoryType uploadCategoryType, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var postUpload = await _unitOfWork.PostUploads.FindAsync(postUploadId);
            if (postUpload == null)
                return BadRequest();

            try
            {
                postUpload.Memo = memo;
                postUpload.UploadCategoryType = uploadCategoryType;
                postUpload.UpdatedDate = DateTime.Now;
                postUpload.UpdatedUserId = userId;

                _unitOfWork.PostUploads.Update(postUpload);
                await _unitOfWork.Complete();

                return Ok(postUpload);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}