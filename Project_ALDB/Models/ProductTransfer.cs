using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_ALDB.Models
{
    public class ProductTransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }

        // Additional fields
        public string Quantity { get; set; }
        public int CustomerID { get; set; }
        public string ContactCusPhoneNum { get; set; }
        public string ShippingName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int SaleRespEmployeeNumber { get; set; }
    }
}
