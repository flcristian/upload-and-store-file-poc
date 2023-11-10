using AutoMapper;
using upload_and_store_file_poc.Data;
using Microsoft.EntityFrameworkCore;
using upload_and_store_file_poc.Templates.Models;
using upload_and_store_file_poc.Templates.Repository.Interfaces;

namespace upload_and_store_file_poc.Templates.Repository;

public class TemplateRepository : ITemplateRepository
{
    private AppDbContext _context;
    private IMapper _mapper;

    public TemplateRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Template>> GetAllAsync()
    {
        return await _context.Templates.ToListAsync();
    }

    public async Task<Template> GetByNameAsync(string name)
    {
        return await _context.Templates.FirstOrDefaultAsync(template => template.Name.Equals(name));
    }

    public async Task<Template> GetByIdAsync(int id)
    {
        return await _context.Templates.FindAsync(id);
    }
    
    public async Task<Template> CreateAsync(string name)
    {
        Template template = new Template();
        template.Name = name;
        
        _context.Templates.Add(template);
        await _context.SaveChangesAsync();
        
        return template;
    }

    public async Task DeleteByIdAsync(int id)
    {
        Template template = await _context.Templates.FindAsync(id);
        _context.Templates.Remove(template);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByNameAsync(string name)
    {
        Template template = await _context.Templates.FirstOrDefaultAsync(template => template.Name.Equals(name));
        _context.Templates.Remove(template);
        await _context.SaveChangesAsync();
    }
}