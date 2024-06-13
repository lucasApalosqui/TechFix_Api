

namespace TechFix.Domain.ViewModels.Clients
{
    public class GetMyProfileClientViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UrlImage { get; set; }
        public IList<string> Hires { get; set; }
    }
}
