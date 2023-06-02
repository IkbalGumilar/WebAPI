namespace WebAPI.Model
{
    public class Respon<T>
    {
        public T? Data  { get; set; }
        public bool Berhasil { get; set; } = true;
        public string Pesan { get; set; } = string.Empty;

    }
}
