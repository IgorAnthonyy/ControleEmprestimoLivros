using EmprestimosLivros.Models;
using EmprestimosLivros.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;
using EmprestimosLivros.Dto;
using AutoMapper;

namespace EmprestimosLivros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
        }
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> CadastrarCliente([FromBody] ClienteDTORequest cliente)
        {
            
            ClienteModel clienteModel = _mapper.Map<ClienteModel>(cliente);
            ClienteModel clienteCriado = await _clienteRepositorio.CriarCliente(clienteModel);
            ClienteDTOResponse clienteResponse = _mapper.Map<ClienteDTOResponse>(clienteCriado);
            return CreatedAtAction(nameof(CadastrarCliente), new { id = clienteResponse.Id }, clienteResponse);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> AtualizarCliente(int id, [FromBody] ClienteDTORequest cliente)
        {
            ClienteModel clienteModel = _mapper.Map<ClienteModel>(cliente);
            clienteModel.Id = id;
            ClienteModel clienteAtualizado = await _clienteRepositorio.AtualizarCliente(clienteModel, id);
            ClienteDTOResponse clienteResponse = _mapper.Map<ClienteDTOResponse>(clienteAtualizado);
            return Ok(clienteResponse);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> ObterClientePorId(int id)
        {
            ClienteModel cliente = await _clienteRepositorio.ObterClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ClienteDTOResponse clienteResponse = _mapper.Map<ClienteDTOResponse>(cliente);
            return Ok(clienteResponse);
        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> ObterTodosClientes()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.ObterTodosClientes();
            List<ClienteDTOResponse> clientesResponse = _mapper.Map<List<ClienteDTOResponse>>(clientes);
            return Ok(clientesResponse);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> DeletarCliente(int id)
        {
            await _clienteRepositorio.DeletarCliente(id);
            return NoContent();
        }
    }
}