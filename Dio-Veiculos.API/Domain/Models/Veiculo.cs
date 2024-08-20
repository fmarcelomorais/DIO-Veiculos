using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dio_Veiculos.API.Domain.Models
{
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(150)]
        public string Marca { get; set; }

        [Required]
        [StringLength(150)]
        public string Modelo { get; set; }

        [StringLength(4)]
        public string Ano { get; set; }

        [Required]
        [StringLength(7)]
        public string Placa { get; set; }


    }
}
