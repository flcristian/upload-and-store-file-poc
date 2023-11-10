using Microsoft.AspNetCore.Mvc;
using upload_and_store_file_poc.Templates.Models;

namespace upload_and_store_file_poc.Templates.Controllers.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class TemplatesApiController
{
    [HttpPost("upload")]
    [ProducesResponseType(statusCode:200,type:typeof(Template))]
    [ProducesResponseType(statusCode:400,type:typeof(String))]
    public abstract Task<ActionResult<Template>> UploadTemplate(IFormFile file);
    
    [HttpDelete("delete")]
    [ProducesResponseType(statusCode:200,type:typeof(String))]
    [ProducesResponseType(statusCode:400,type:typeof(String))]
    public abstract Task<ActionResult> RemoveTemplate(string name);
}