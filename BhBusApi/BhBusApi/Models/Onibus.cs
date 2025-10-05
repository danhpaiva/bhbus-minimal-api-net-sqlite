using System.ComponentModel.DataAnnotations;

namespace BhBusApi.Models;

public class Onibus
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo número é obrigatório!")]
    public int Numero { get; set; }
    public string Cor { get; set; }
    public string Tipo { get; set; }
    public string Peso { get; set; }
}
