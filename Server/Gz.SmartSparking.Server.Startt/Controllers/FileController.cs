
using Gz.SmartParking.Server.IService;
using Microsoft.AspNetCore.Mvc;
using Gz.SmartParking.Server.Models;
using Gz.SmartParking.Server.ICommon;
namespace Gz.SmartParking.Server.Startt.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class FileController
    {
        IAppConfiguration _configuration ;
        IFileUpgradeService _fileUpgradeService;
        public FileController(IAppConfiguration configuration, IFileUpgradeService fileUpgradeService)
        {
            _configuration = configuration;
            _fileUpgradeService = fileUpgradeService;
        }
        //[HttpPost]
        //[Route("download")]
        //public IActionResult Download([FromForm] IFormCollection formCollection)
        //{
        //    var fileName = formCollection["filename"];
        //    var filePath = Path.Combine(Configuration.Read("FileFolder"), fileName);
        //    ResFileStream fs = new ResFileStream(filePath, FileMode.Open, FileAccess.Read);
        //    var type = new MediaTypeHeaderValue("application/oct-stream").MediaType;
        //    return File(fs, contentType: type, fileName, enableRangeProcessing: true);
        //}
        [HttpGet]
        public JsonResult Check()
        {
            // EFCore
            // 从数据库获取相关的文件信息  文件名-文件MD5
            var result = _fileUpgradeService.Query<UpgradeFile>(f => f.FileId > 0);
            return new JsonResult(result);
        }
    }
}
