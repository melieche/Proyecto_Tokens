namespace Proyecto_Tokens.Models
{
    public class LoginRegistro
    {
        public int Id { get; set; }
        public DateTime FechaHoraLogin { get; set; }
        public  UserModels Usuario { get; set; }
    }
}
