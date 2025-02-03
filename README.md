# Web Service - ViaCEP

Este projeto é um Web Service em ASP.NET Core que consome a API pública do [ViaCEP](https://viacep.com.br/) para obter informações de endereços a partir de um CEP informado.

## 🚀 Tecnologias Utilizadas

- .NET 6 ou superior
- ASP.NET Core Web API
- HttpClient
- Swagger UI
- JSON Serialization

## 📌 Funcionalidades

- Consulta de endereços por CEP via API do ViaCEP.
- Documentação interativa com Swagger.
- Retorno estruturado em JSON.

## 📂 Estrutura do Projeto

```
📦 WebService-ViaCEP
├── Controllers
│   ├── CepController.cs
├── Services
│   ├── ViaCepService.cs
├── Program.cs
├── README.md
```

## 🔧 Como Executar o Projeto

1. **Clone o repositório:**
   ```sh
   git clone https://github.com/seu-usuario/WebService-ViaCEP.git
   cd WebService-ViaCEP
   ```

2. **Instale o .NET SDK** (caso não tenha instalado) em: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

3. **Execute o projeto:**
   ```sh
   dotnet run
   ```

4. **Acesse o Swagger para testar a API:**
   Abra no navegador: [http://localhost:5000/swagger](http://localhost:5000/swagger) *(A porta pode variar)*

## 📌 Exemplo de Requisição

### Endpoint:
```
GET /api/cep/{cep}
```

### Exemplo de Uso:
```
GET http://localhost:5000/api/cep/01001000
```

### Resposta JSON:
```json
{
  "cep": "01001-000",
  "logradouro": "Praça da Sé",
  "bairro": "Sé",
  "localidade": "São Paulo",
  "uf": "SP"
}
```

## 🛠 Melhorias Futuras
- Adicionar cache para reduzir chamadas repetidas à API do ViaCEP.
- Implementar autenticação para uso restrito da API.
- Suporte a mais formatos de saída (XML, CSV).

## 📜 Licença

Este projeto é distribuído sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---
💡 *Feito com dedicação para aprendizado e crescimento na área de desenvolvimento!* 🚀

