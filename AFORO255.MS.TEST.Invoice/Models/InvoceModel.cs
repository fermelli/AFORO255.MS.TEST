using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoce.Models;

[Table("invoce")]
public class InvoceModel
{
    public InvoceModel() { }

    public InvoceModel(decimal? amount, int? state)
    {
        Amount = amount;
        State = state;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_invoice")]
    public int IdInvoce { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("state")]
    public int? State { get; set; }

}

