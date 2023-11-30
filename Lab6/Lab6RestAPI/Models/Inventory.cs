using System.ComponentModel.DataAnnotations.Schema;


namespace Lab6RestAPI.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [ForeignKey("Id")]
        public InventoryItemType InventoryItemType { get; set; }

        public string Description { get; set; } = string.Empty;

    }
}
