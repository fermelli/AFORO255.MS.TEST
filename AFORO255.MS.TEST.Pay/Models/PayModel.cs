using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.Models;

[Table("pay")]
public class PayModel
{
    public PayModel(int idInvoce, decimal amount)
    {
        IdInvoce = idInvoce;
        Amount = amount;
        Date = DateTime.Now;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_operation")]
    public int IdOperation { get; set; }

    [Column("id_invoce")]
    public int IdInvoce { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }
}