using Microsoft.AspNetCore.Mvc;
using upload_and_store_file_poc.System.Constants;
using upload_and_store_file_poc.System.Exceptions;
using upload_and_store_file_poc.Templates.Controllers.Interfaces;
using upload_and_store_file_poc.Templates.Models;
using upload_and_store_file_poc.Templates.Services.Interfaces;

namespace upload_and_store_file_poc.Templates.Controllers;

public class TemplatesController : TemplatesApiController
{
    private IHostEnvironment _environment;
    private ITemplateQueryService _queryService;
    private ITemplateCommandService _commandService;

    public TemplatesController(IHostEnvironment environment, ITemplateQueryService queryService, ITemplateCommandService commandService)
    {
        _environment = environment;
        _queryService = queryService;
        _commandService = commandService;
    }
    
    public override async Task<ActionResult<Template>> UploadTemplate(IFormFile file)
    {
        if (Path.GetExtension(file.FileName).ToLower() != ".docx")
        {
            return new BadRequestObjectResult("Only .docx files are allowed.");
        }
        
        string name = file.FileName;
        try
        {
            await _queryService.GetTemplateByName(name);

            name = await _commandService.RenameUntilUnique(name);
        }
        catch (ItemDoesNotExist) { }
        Template template = await _commandService.CreateTemplate(name);
        
        if (file != null! && file.Length > 0)
        {
            var storage = Path.Combine(_environment.ContentRootPath, "Templates/Storage");
            
            if (!Directory.Exists(storage))
            {
                Directory.CreateDirectory(storage);
            }

            var filePath = Path.Combine(storage, template.Name);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return new OkObjectResult(template);
        }
        
        return new BadRequestObjectResult("Ok");
    }

    public override async Task<ActionResult> RemoveTemplate(string name)
    {
        try
        {
            await _commandService.DeleteTemplateByName(name);

            var storage = Path.Combine(_environment.ContentRootPath, "Templates/Storage");
            var filePath = Path.Combine(storage, name);
            File.Delete(filePath);

            return new OkObjectResult(Constants.TEMPLATE_REMOVED);
        }
        catch (ItemDoesNotExist ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult("An error occured: " + ex.Message);
        }
    }
}