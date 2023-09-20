using EntregaFinalAcademia.DTOs;
using EntregaFinalAcademia.Helpers;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntregaFinalAcademia.Entities
{
    public class User
    {

        [Key]
        [Column("user_id", TypeName = "int")]
        public int CodUsuario { get; set; }

        [Required]
        [Column("user_dni", TypeName = "float")]
        public int Dni { get; set; }

        [Required]
        [Column("user_nombre", TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column("user_email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column("user_clave", TypeName = "VARCHAR(250)")]
        public string Clave { get; set; }

        [Required]
        [Column("user_estado", TypeName = "bit")]
        [DefaultValue(true)]
        public Boolean Estado { get; set; }

        [Required]
        [Column("role_id")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }


        public User(RegisterDto dto)
        {
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email);
            Estado = true;
            Email = dto.Email;
            RoleId = 2;
        }

        public User(RegisterDto dto, int id)
        {
            CodUsuario = id;
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email);
            Estado = dto.Estado;
            Email = dto.Email;
            RoleId = dto.RoleId;
        }

        public User()
        {

        }

    }
}
