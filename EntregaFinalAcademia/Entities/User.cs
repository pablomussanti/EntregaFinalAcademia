namespace EntregaFinalAcademia.Entities
{
    public class User
    {
        public int CodUsuario { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }

        public int Tipo { get; set; }

        public string Clave { get; set; }
        public Role? Role { get; set; }

        public Boolean Estado { get; set; }

    }
}
