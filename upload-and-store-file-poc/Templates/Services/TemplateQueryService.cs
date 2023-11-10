using upload_and_store_file_poc.System.Constants;
using upload_and_store_file_poc.System.Exceptions;
using upload_and_store_file_poc.Templates.Models;
using upload_and_store_file_poc.Templates.Repository.Interfaces;
using upload_and_store_file_poc.Templates.Services.Interfaces;

namespace upload_and_store_file_poc.Templates.Services;

public class TemplateQueryService : ITemplateQueryService
{
    private ITemplateRepository _repository;

    public TemplateQueryService(ITemplateRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Template>> GetAllTemplates()
    {
        IEnumerable<Template> templates = await _repository.GetAllAsync();

        if (templates.Count() == 0)
        {
            throw new ItemsDoNotExist(Constants.TEMPLATES_DO_NOT_EXIST);
        }

        return templates;
    }

    public async Task<Template> GetTemplateByName(string name)
    {
        Template template = await _repository.GetByNameAsync(name);

        if (template == null)
        {
            throw new ItemDoesNotExist(Constants.TEMPLATE_DOES_NOT_EXIST);
        }

        return template;
    }
    
    public async Task<Template> GetTemplateById(int id)
    {
        Template template = await _repository.GetByIdAsync(id);

        if (template == null)
        {
            throw new ItemDoesNotExist(Constants.TEMPLATE_DOES_NOT_EXIST);
        }

        return template;
    }
}