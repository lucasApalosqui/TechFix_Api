
namespace TechFix.Domain.ViewModels.Clients
{
    public class CreateClientViewModel
    {
        public string pass {  get; set; }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
