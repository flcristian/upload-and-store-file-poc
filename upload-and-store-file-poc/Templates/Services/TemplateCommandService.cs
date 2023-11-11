using upload_and_store_file_poc.System.Constants;
using upload_and_store_file_poc.System.Exceptions;
using upload_and_store_file_poc.Templates.Models;
using upload_and_store_file_poc.Templates.Repository.Interfaces;
using upload_and_store_file_poc.Templates.Services.Interfaces;

namespace upload_and_store_file_poc.Templates.Services;

public class TemplateCommandService : ITemplateCommandService
{
    private ITemplateRepository _repository;

    public TemplateCommandService(ITemplateRepository repository)
    {
        _repository = repository;
    }

    public async Task<String> RenameUntilUnique(string name)
    {
        while (await _repository.GetByNameAsync(name) != null)
        {
            string[] parts = name.Split('.');
            int last = parts.Length - 2;
            int index = (int)char.GetNumericValue(parts[last][parts[last].Length - 1]);

            if (index == -1 || index == 9)
            {
                parts[last] += '0';
            }
            else
            {
                parts[last] = parts[last].Substring(0, parts[last].Length - 1) + Convert.ToChar('0' + index + 1);
            }

            name = string.Join(".", parts);
        }

        return name;
    }

    public async Task<Template> CreateTemplate(string name)
    {
        Template template = await _repository.CreateAsync(name);

        return template;
    }

    public async Task DeleteTemplateById(int id)
    {
        Template check = await _repository.GetByIdAsync(id);

        if (check == null)
        {
            throw new ItemDoesNotExist(Constants.TEMPLATE_DOES_NOT_EXIST);
        }

        await _repository.DeleteByIdAsync(id);
    }
    
    public async Task DeleteTemplateByName(string name)
    {
        Template check = await _repository.GetByNameAsync(name);

        if (check == null)
        {
            throw new ItemDoesNotExist(Constants.TEMPLATE_DOES_NOT_EXIST);
        }

        await _repository.DeleteByNameAsync(name);
    }
}