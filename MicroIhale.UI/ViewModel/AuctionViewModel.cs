using System.ComponentModel.DataAnnotations;

namespace MicroIhale.UI.ViewModel
{
    public class AuctionViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Fill Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Fill Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Fill Product")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Please Fill Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please Fill Start Date")]
        public DateTime StartedAt { get; set; }
        [Required(ErrorMessage = "Please Fill Finish Date")]
        public DateTime FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public int SellerId { get; set; }
        public List<string>  IncludedSellers { get; set; }
    }
}
