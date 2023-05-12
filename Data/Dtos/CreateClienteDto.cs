using Clientes.Crud.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Crud.Data.Dtos;

public class CreateClienteDto
{
    
    [Required(ErrorMessage = "O Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O número máximo de caracter é e 100.")]
    [MinLength(5, ErrorMessage = "O número mínimo de caracter é 5.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O gênero é obrigatório.")]

    [Range(0, 2 ,ErrorMessage ="Genêro incorreto!")]
    public EGenero Genero { get; set; }
    [Required(ErrorMessage = "O DNI É Obrigatório.")]
    [Range(10000, 99999999, ErrorMessage = "O DNI deve conter entre 5 a 10 dígitos.")]
    public int DNI { get; set; }
}
