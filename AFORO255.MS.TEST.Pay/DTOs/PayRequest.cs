using System.ComponentModel.DataAnnotations;

namespace AFORO255.MS.TEST.Pay.DTOs
{
    public class PayRequest
    {
        public int IdInvoce { get; set; }

        public decimal Amount { get; set; }
    }
}
