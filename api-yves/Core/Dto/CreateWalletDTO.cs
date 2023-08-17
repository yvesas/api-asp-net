using System.ComponentModel.DataAnnotations;
namespace Core.Dto;

public class CreateWalletDTO
{
  [Required]
  public int UserID { get; set; }
  
  [Required]
  public decimal Amout { get; set; }
  
  [Required]
  public string Bank { get; set; }

}