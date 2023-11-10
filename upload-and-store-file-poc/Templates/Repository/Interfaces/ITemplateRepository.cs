using upload_and_store_file_poc.Templates.Models;

namespace upload_and_store_file_poc.Templates.Repository.Interfaces;

public interface ITemplateRepository
{
    Task<IEnumerable<Template>> GetAllAsync();
    Task<Template> GetByNameAsync(string name);
    Task<Template> GetByIdAsync(int id);
    Task<Template> CreateAsync(string name);
    Task DeleteByIdAsync(int id);
    Task DeleteByNameAsync(string name);
}