using CallExternalApi.Clients.FileStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CallExternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly IFileStore _fileStore;

        public UploadsController(IFileStore fileStore)
        {
            _fileStore = fileStore;
        }

        [HttpPost("")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var streamPart = new StreamPart(file.OpenReadStream(), file.FileName, file.ContentType);
            await _fileStore.Upload(streamPart);
            return Ok();
        }

        [HttpPost("upload-many")]
        public async Task<IActionResult> UploadFiles([FromForm] IEnumerable<IFormFile> files)
        {
            var streamParts = files.Select(f => new StreamPart(f.OpenReadStream(), f.FileName, f.ContentType));
            await _fileStore.UploadManyAsync(streamParts);
            return Ok();
        }

    }
}
