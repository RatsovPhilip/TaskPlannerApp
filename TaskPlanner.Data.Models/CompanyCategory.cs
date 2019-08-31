namespace TaskPlanner.Data.Models
{
    public class CompanyCategory
    {
        public string CompanyId { get; set; }
        public Company Company { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
