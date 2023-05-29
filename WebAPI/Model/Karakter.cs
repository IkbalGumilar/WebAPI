namespace WebAPI.Model
{
    public class Karakter
    {
        public int Id { get; set; }
        public string name { get; set; } = "User Name";
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
