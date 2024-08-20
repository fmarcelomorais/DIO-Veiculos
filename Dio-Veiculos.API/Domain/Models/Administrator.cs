using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dio_Veiculos.API.Domain.Models
{
    public class Administrator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = default!;
        [Required]
        [StringLength(255)]
        public string Email { get; set; } = default!;
        [Required]
        [StringLength(10)]
        public string Passworld { get; set; } = default!;
        public Perfil Perfil { get; set; }

        public Administrator() { }

        public Administrator(string name, string email, string passworld, Perfil perfil)
        {
            Name = name;
            Email = email;
            Passworld = passworld;
            Perfil = perfil;
        }
    }
    public enum Perfil
    {
        Admin = 1,
        User
    }
}
