using System.ComponentModel.DataAnnotations;
namespace Core.Dto;

public class CreateUserDTO
{
  [Required]
  public string Name { get; set;}
  
  [Required]
  public DateOnly BirthDate { get; set; }
  
  [Required]
  public string CPF { get; set; }
}