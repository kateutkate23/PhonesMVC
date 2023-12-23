namespace PhonesMVC.ViewModels
{
    public class UpdatePhoneClientVM
    {
        public Guid Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
    }
}
