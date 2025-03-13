GABRIEL TORRES FERNANDES - RM553635
 
 # Odontoprev

O projeto do challenge **Odontoprev** é uma aplicação ASP.NET Core Web API desenvolvida para redução de sinistros com análise preditiva de atendimento. A API foi construída seguindo boas práticas de arquitetura de software e design patterns, utilizando uma abordagem monolítica que centraliza a lógica de negócio, acesso a dados e configuração em uma única aplicação.

## Índice

- [Arquitetura](#arquitetura)
- [Design Patterns Utilizados](#design-patterns-utilizados)
- [Tecnologias e Ferramentas](#tecnologias-e-ferramentas)
- [Como Rodar a Aplicação](#como-rodar-a-aplicação)
- [Exemplos de Testes](#exemplos-de-testes)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Licença](#licença)

## Arquitetura

Este projeto utiliza uma **arquitetura monolítica** para consolidar todas as funcionalidades em um único deploy. Essa abordagem foi escolhida devido à simplicidade de gerenciamento e menor complexidade na comunicação entre os módulos, ideal para o escopo do projeto que integra um único banco Oracle.

A aplicação segue a separação de responsabilidades com as seguintes camadas:

- **Controllers:** Exposição dos endpoints REST para interação com os recursos.
- **Services:** Camada de lógica de negócio que orquestra a comunicação entre os controllers e os repositórios.
- **Repositories:** Acesso aos dados utilizando Dapper e Oracle.ManagedDataAccess.Core, implementando o padrão Repository para operações CRUD.
- **Models:** Representações das entidades do banco de dados.
- **Singleton:** Implementação do padrão Singleton para gerenciar configurações globais da aplicação.

## Design Patterns Utilizados

- **Repository Pattern:** Para abstrair o acesso aos dados e permitir uma separação clara entre a lógica de negócios e o mecanismo de persistência.
- **Singleton Pattern:** Utilizado no `ConfigManager` para garantir uma única instância para o gerenciamento de configurações globais.
- **Options Pattern:** Para configuração da conexão com o banco Oracle a partir do arquivo `appsettings.json`.

## Tecnologias e Ferramentas

- **ASP.NET Core Web API:** Framework para desenvolvimento de APIs RESTful.
- **C# / .NET 8.0:** Linguagem e plataforma utilizada.
- **Dapper:** Micro ORM para mapeamento objeto-relacional simples e eficiente.
- **Oracle.ManagedDataAccess.Core:** Driver para acesso ao banco de dados Oracle.
- **Swagger / OpenAPI:** Ferramenta para documentação interativa da API.
- **Git & GitHub:** Controle de versão e repositório público.

## Como Rodar a Aplicação

### Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Acesso a um banco de dados Oracle com a estrutura definida (ou ambiente de testes adequado)
- Editor de código (Visual Studio, VS Code, etc.)

### Passos para Execução

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/gabrieltf1901/.NET-ODONTOPREV.git
   cd odontoprev
   
2. **Configure o Arquivo appsettings.json**

- Atualize a string de conexão na seção OracleSettings com os dados do seu ambiente:

    ```json
  {
  "OracleSettings": {
    "ConnectionString": "User Id=rm553635;Password=190101;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)))"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

3. **Restaure as dependências**

- No terminal execute:

    ```bash
    dotnet restore
  
4. **Complie e rode a aplicação**

    ```bash 
    dotnet run
   
5. **Acesse a documentação Swagger**

- Ao iniciar, a aplicação disponibiliza a documentação interativa em https://localhost:{PORT}/swagger (substitua {PORT} pelo número da porta configurada).


## Exemplos de testes com Swagger

- A documentação do Swagger permite testar os endpoints da API de forma interativa. Após acessar a URL do Swagger, você poderá:

1. Listar Registros:
Clique no endpoint desejado, como GET /api/paciente, e pressione o botão Try it out para visualizar todos os pacientes cadastrados.

2. Buscar Registro por ID:
Selecione o endpoint GET /api/paciente/{id}, clique em Try it out, informe um ID válido e execute a requisição para obter os detalhes de um paciente específico.

3. Criar um Novo Registro:
No endpoint POST /api/paciente, clique em Try it out. No campo de entrada, preencha os dados do novo paciente em formato JSON, por exemplo:

    ```json
   {
    "id": 11,
    "nomeCompleto": "Paciente Exemplo",
    "dataNascimento": "1990-01-01T00:00:00",
    "contato": "99999-9999",
    "planoDeSaude": "Plano Exemplo",
    "historicoMedico": "Sem histórico relevante"
    }
Em seguida, clique em Execute para enviar a requisição.

4. Atualizar um Registro:
Utilize o endpoint PUT /api/paciente/{id}. Clique em Try it out, informe o ID do paciente e preencha o corpo da requisição com os dados atualizados. Por exemplo:

    ```json
    {
    "id": 11,
    "nomeCompleto": "Paciente Atualizado",
    "dataNascimento": "1990-01-01T00:00:00",
    "contato": "88888-8888",
    "planoDeSaude": "Plano Atualizado",
    "historicoMedico": "Histórico atualizado"
    }
Clique em Execute para enviar a atualização.

5. Deletar um Registro:
Para remover um registro, acesse o endpoint DELETE /api/paciente/{id}, clique em Try it out, informe o ID desejado e execute a requisição.

   
## Licença
Distribuído sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.
