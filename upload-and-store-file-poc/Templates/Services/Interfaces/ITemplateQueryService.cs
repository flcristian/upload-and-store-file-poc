using upload_and_store_file_poc.Templates.Models;

namespace upload_and_store_file_poc.Templates.Services.Interfaces;

public interface ITemplateQueryService
{
    Task<IEnumerable<Template>> GetAllTemplates();
    Task<Template> GetTemplateByName(string name);
    Task<Template> GetTemplateById(int id);
}