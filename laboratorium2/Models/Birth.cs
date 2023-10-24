namespace laboratorium2.Models
{
    public class Birth
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public bool IsValid() =>
            Name != null && DateOfBirth != null;

        public long Birth_() =>
            (DateTime.Now.Year - DateOfBirth.Value.Year);
    }
}
