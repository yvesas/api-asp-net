using System.ComponentModel.DataAnnotations.Schema;
namespace Core.Domain.Entities;

[Table("wallets")]
public class Wallet
{   
    [Column("id")]
    public int Id { get; set; }

    [Column("id_user")]
    public int UserID { get; set; }

    [Column("amount")]
    public decimal Amout { get; set; }

    [Column("bank")]
    public string Bank { get; set; }

    [Column("last_update")]
    public DateTime LastUpdate { get; set; } = DateTime.Now;
}

