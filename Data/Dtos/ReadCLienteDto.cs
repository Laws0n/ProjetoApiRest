using Clientes.Crud.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Crud.Data.Dtos
{
    public class ReadCLienteDto
    {

        public string Nome { get; set; }

        public EGenero Genero { get; set; }

        public int DNI { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }

}
