using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/cep")]
public class CepController : ControllerBase
{
    private readonly ViaCepService _viaCepService;

    public CepController(ViaCepService viaCepService)
    {
        _viaCepService = viaCepService;
    }

    [HttpGet("{cep}")]
    public async Task<IActionResult> BuscarCep(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep))
        {
            return BadRequest("CEP inválido.");
        }

        if (cep.Length != 8 || !long.TryParse(cep, out _))
        {
            return BadRequest("CEP deve conter 8 dígitos numéricos.");
        }

        var resultado = await _viaCepService.BuscarCepAsync(cep);

        if (resultado == null)
        {
            return NotFound("CEP não encontrado.");
        }

        return Ok(resultado);
    }
}
