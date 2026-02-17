namespace Application.DTO
{
    public class CreateCampaignDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
    }

    public class UpdateCampaignDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
    }
}