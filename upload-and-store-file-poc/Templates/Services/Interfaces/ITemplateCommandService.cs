﻿using upload_and_store_file_poc.Templates.Models;

namespace upload_and_store_file_poc.Templates.Services.Interfaces;

public interface ITemplateCommandService
{
    Task<String> RenameUntilUnique(String name);
    Task<Template> CreateTemplate(string name);
    Task DeleteTemplateById(int id);
    Task DeleteTemplateByName(string name);
}