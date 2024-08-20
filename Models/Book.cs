namespace BookReservesAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int AuthorId { get; set; }
        public string ISBN { get; set; } = "";
        public DateTime PublicationDate { get; set; }
        public bool isAvailable { get; set; }
    }
}
