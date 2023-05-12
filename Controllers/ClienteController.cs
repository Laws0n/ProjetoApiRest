using AutoMapper;
using Clientes.Crud.Data;
using Clientes.Crud.Data.Dtos;
using Clientes.Crud.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;

namespace Clientes.Crud.Controllers;



[ApiController]
[Route("[controller]")]

public class ClienteController : ControllerBase
{
    private static List<Cliente> clientes = new List<Cliente>();
    private static int id = 0;


    private ClienteContext _context;
    private IMapper _mapper;
    public ClienteController(ClienteContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]

    public IActionResult AdicionaCliente([FromBody] CreateClienteDto clienteDto)

    {

        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        cliente.Id = id++;
        clientes.Add(cliente);
        return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id }, cliente);


    }

    [HttpGet]

    public IEnumerable<ReadCLienteDto> RecuperaClientes()
    {
        return _mapper.Map<List<ReadCLienteDto>>(_context.Clientes);

    } 

    [HttpGet("{id}")]
    public IActionResult RecuperaClientePorId(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente == null)
            return NotFound();
        var clienteDto = _mapper.Map<ReadCLienteDto>(cliente);
       
      
        return Ok(clienteDto);

    }
    [HttpPut("{id}")]
    public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)

    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        _mapper.Map(clienteDto, cliente);
        _context.SaveChanges();
        return NoContent();

    }
    [HttpPatch("{id}")]

    public IActionResult AtualizaClienteParcial(int id, JsonPatchDocument<UpdateClienteDto> patch)

    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null)
            return NotFound();


        var clienteParaAtualizar = _mapper.Map<UpdateClienteDto>(cliente);
        patch.ApplyTo(clienteParaAtualizar, ModelState);

        if (!TryValidateModel(clienteParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(clienteParaAtualizar, cliente);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCliente(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        _context.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}
