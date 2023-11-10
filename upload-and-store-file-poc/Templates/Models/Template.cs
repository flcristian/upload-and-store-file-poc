using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace upload_and_store_file_poc.Templates.Models;

public class Template
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }
    
    [Required]
    [Column("Name")]
    public string Name { get; set; }
}