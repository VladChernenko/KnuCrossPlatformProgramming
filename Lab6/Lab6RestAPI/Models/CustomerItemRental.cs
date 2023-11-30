

using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6RestAPI.Models
{
    public class CustomerItemRental
    {

        public int Id { get; set; }

        [ForeignKey("Id")]
        public Customer Customer { get; set; }


        [ForeignKey("Id")]
        public Inventory Inventory { get; set; }

        public DateTime DateOut { get; set; }

        public DateTime DateReturned { get; set; }


        public uint RentalAmountDue { get; set; } = 0;


    }
}
