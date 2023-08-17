using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities;

 [Table("users")]
  public class User
 {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("birth_date")]
        public DateOnly BirthDate { get; set; }
        
        [Column("cpf")]
        public string CPF { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
 }
