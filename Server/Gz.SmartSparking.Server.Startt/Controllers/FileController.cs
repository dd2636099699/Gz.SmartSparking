using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Gz.SmartSparking.Server.Startt.Controllers
{
    public class FileController
    {
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
        [Route("check")]
        public JsonResult Check()
        {
            // EFCore
            // 从数据库获取相关的文件信息  文件名-文件MD5
            var result = _fileUpgradeService.Query<UpgradeFile>(f => f.FileId > 0);
            return new JsonResult(result);
        }
    }
}
