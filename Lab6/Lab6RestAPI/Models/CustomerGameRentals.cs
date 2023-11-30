using System.ComponentModel.DataAnnotations.Schema;


namespace Lab6RestAPI.Models
{
    public class CustomerGameRentals
    {

        public int Id { get; set; }

        [ForeignKey("Id")]
        public Customer Customer { get; set; }


        [ForeignKey("Id")]
        public Game Game { get; set; }

        public DateTime DateOut { get; set; }

        public DateTime DateReturned { get; set; }


        public uint RentalAmountDue { get; set; } = 0;


    }
}
