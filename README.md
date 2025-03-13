# ServiceManager

📁 Estrutura da Solução (Solution)
A solução será organizada em múltiplos projetos dentro de uma Solution (ServiceManager.sln), seguindo a arquitetura DDD e Hexagonal.

mathematica
Copy
📂 ServiceManager.sln
│
├── 📂 ServiceManager.API            → Camada de Apresentação (Controllers)
│   ├── Controllers/                 → Endpoints REST
│   ├── Program.cs                    → Configuração inicial
│   ├── appsettings.json               → Configurações da API
│   ├── Startup.cs (se for .NET 5)     → Configuração de dependências
│   ├── Dockerfile                      → Arquivo para Docker
│
├── 📂 ServiceManager.Application     → Casos de uso / Application Layer
│   ├── DTOs/                          → Objetos de transferência de dados
│   ├── Interfaces/                     → Interfaces de serviços
│   ├── Services/                       → Implementação dos casos de uso
│   ├── Validators/                     → Regras de validação (FluentValidation)
│
├── 📂 ServiceManager.Domain          → Regras de negócio e entidades
│   ├── Entities/                       → Classes de domínio (OrdemServico, Cliente, etc.)
│   ├── Enums/                          → Enumerações
│   ├── ValueObjects/                   → Objetos de valor
│   ├── Interfaces/                     → Contratos (ex: IOrdemServicoRepository)
│   ├── Events/                         → Eventos de domínio
│
├── 📂 ServiceManager.Infrastructure  → Implementações técnicas (banco, mensageria)
│   ├── Persistence/                    → Repositórios com Entity Framework
│   ├── Messaging/                       → Implementação do RabbitMQ
│   ├── Logging/                         → Logs com Serilog
│   ├── Migrations/                      → Mapeamento EF Core
│   ├── Configurations/                  → Mapeamento das entidades no EF
│
├── 📂 ServiceManager.Workers         → Background Workers (RabbitMQ Consumers)
│   ├── Consumers/                      → Classes que escutam mensagens do RabbitMQ
│   ├── Services/                        → Processamento de mensagens
│
├── 📂 ServiceManager.Tests           → Testes automatizados
│   ├── UnitTests/                      → Testes unitários (xUnit, NUnit ou MSTest)
│   ├── IntegrationTests/               → Testes de integração com banco em memória
│
└── 📂 ServiceManager.Shared          → Biblioteca compartilhada
    ├── Utils/                         → Classes utilitárias (ex: formatação de datas)
    ├── Constants/                     → Constantes globais
    ├── Exceptions/                     → Exceções customizadas
📌 Referências entre os Projetos
Para manter a separação de responsabilidades e permitir a comunicação correta entre os projetos:

✅ API (ServiceManager.API)

Depende de Application (para chamar os casos de uso)
Depende de Domain (para utilizar entidades)
✅ Application (ServiceManager.Application)

Depende de Domain (para usar entidades e interfaces)
Depende de Infrastructure (para acessar repositórios)
✅ Infrastructure (ServiceManager.Infrastructure)

Depende de Domain (implementa repositórios baseados nas interfaces do domínio)
✅ Workers (ServiceManager.Workers)

Depende de Infrastructure (para acessar RabbitMQ e banco de dados)
Depende de Application (para chamar regras de negócio)
🚀 Como Rodar no Docker?
Vamos criar um docker-compose.yml para subir todos os serviços:

yaml
Copy
version: '3.8'
services:
  api:
    build: .
    container_name: servicemanager_api
    depends_on:
      - db
      - rabbitmq
    ports:
      - "5000:5000"
    environment:
      - ConnectionStrings__DefaultConnection=Server=db;Database=ServiceManagerDB;User Id=sa;Password=YourPassword123;
  
  db:
    image: postgres:latest
    container_name: servicemanager_db
    environment:
      POSTGRES_DB: ServiceManagerDB
      POSTGRES_USER: admin
      POSTGRES_PASSWORD: admin
    ports:
      - "5432:5432"

  rabbitmq:
    image: "rabbitmq:3-management"
    container_name: servicemanager_rabbitmq
    ports:
      - "5672:5672"
      - "15672:15672"
📌 Fluxo de Dados
O cliente chama um endpoint na API (ServiceManager.API)
A API chama um caso de uso na camada Application
O Application usa um repositório da Infrastructure para salvar os dados no banco
A API publica um evento no RabbitMQ para notificar que a OS foi criada
O Worker (ServiceManager.Workers) escuta essa mensagem e envia um e-mail para o cliente
🔥 Benefícios dessa Arquitetura
✅ Alta separação de responsabilidades
✅ Facilidade para testes unitários
✅ Facilidade para escalar o sistema
✅ Facilidade para manutenção e evolução




