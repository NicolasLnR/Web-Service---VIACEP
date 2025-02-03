using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ViaCepService
{
    private readonly HttpClient _httpClient;

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ViaCepResponse> BuscarCepAsync(string cep)
    {
        Console.WriteLine($"Buscando CEP: {cep}");

        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");

        Console.WriteLine($"Resposta da API: {response.StatusCode}");

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Erro ao acessar API do ViaCEP");
            return null; // Retorna null se o CEP não for encontrado
        }

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Conteúdo da resposta: {content}");

        var resultado = JsonSerializer.Deserialize<ViaCepResponse>(content);

        if (resultado == null || string.IsNullOrEmpty(resultado.Cep))
        {
            Console.WriteLine("CEP retornado é inválido.");
            return null;
        }

        Console.WriteLine("CEP encontrado com sucesso!");
        return resultado;
    }
}


public class ViaCepResponse
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string Uf { get; set; }
}
