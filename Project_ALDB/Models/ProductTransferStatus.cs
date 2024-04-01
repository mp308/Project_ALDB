using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_ALDB.Models
{
    public class ProductTransferStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TransferID { get; set; }
        public int ProductID { get; set; }
        public string Status { get; set; }
        public DateTime DateTransferred { get; set; }
    }
}
