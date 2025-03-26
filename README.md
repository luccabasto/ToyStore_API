# ToyStoreAPI 🧸
 
 
 Membros:
 Projeto desenvolvido por alunos do segundo ano de Análise e Desenvolvimento de Sistemas, atendendo às solicitações feitas para o Checkpoint 04 da disciplina de Advanced Business Development With .NET.
 * Kevin Nobre - 552590
 * Lucas Basto - 553771
 * Sabrina Couto - 552728
 
 O **ToyStoreAPI** é uma API RESTful desenvolvida para gerenciar brinquedos em uma loja virtual. A API oferece operações CRUD (Create, Read, Update e Delete) para gerenciar dados de brinquedos no banco de dados. Abaixo estão as informações sobre a estrutura da API, as rotas, os parâmetros esperados e exemplos de uso.
 
 ## Funcionalidade
 
 A API permite realizar as seguintes operações com brinquedos:
 
 1. **Create**: Adicionar um novo brinquedo à base de dados.
 2. **Read**: Consultar informações de um brinquedo pelo ID.
 3. **Update**: Atualizar as informações de um brinquedo existente.
 4. **Delete**: Remover um brinquedo do banco de dados.
 
 ## Estrutura do Banco de Dados
 
 A tabela que armazena as informações sobre os brinquedos é chamada `TB_TOYS` e possui as seguintes colunas:
 
 - **Id_toy** (int): Identificador único do brinquedo. Auto-incrementável.
 - **Name_toy** (string): Nome do brinquedo.
 - **Type_toy** (string): Tipo do brinquedo (ex: Eletrônico, Jogo, etc.).
 - **Classification_toy** (int): Faixa etária recomendada para o brinquedo (0 a 12 anos).
 - **Brand_toy** (string): Marca do brinquedo.
 - **Price_toy** (decimal): Preço do brinquedo.
 
 ### Exemplo de consulta a tabela `TB_TOYS`:
 | Id_toy | Name_toy           | Type_toy   | Classification_toy | Brand_toy | Price_toy |
 |--------|---------------------|------------|--------------------|-----------|-----------|
 | 1      | Carrinho de Controle | Eletrônico | 6                  | Marca X   | 150.00    |
 | 2      | Jogo da Memória     | Jogo       | 6                  | Grow      | 39.90     |
 
 ---
 ## Como Rodar o Projeto:
 
 Certifique-se de que o SQL Developer esteja instalado e configurado.
 Atualize a string de conexão no arquivo appsettings.json para o seu banco de dados.
 
 Depois de atualizada utilize os comandos abaixo no terminal para criar as tabelas no seu banco:
 
 dotnet ef migrations add InitialCreate
 
 dotnet ef database update
 
 ## Tecnologias Utilizadas
 - .NET 8.0
 - Entity Framework Core
 - Oracle SQL Developer Server
 - C#
 - ASP.NET Core
 - Swagger/OpenAPI para documentação da API
 
 ### Pré-requisitos
 Antes de iniciar, certifique-se de ter os seguintes requisitos instalados:
 
 - [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
 - [SQL Developer Server (Oracle)](https://www.oracle.com/database/sqldeveloper/)
 - [Visual Studio 2022](https://visualstudio.microsoft.com/) (ou outro IDE compatível)
 - [Git](https://git-scm.com/)
 
 
 ## Endpoints da API
 Rode o programa e acesse http://localhost:5285/swagger/index.html para visualizar a Documentação.
 
 ### 1. `POST /Toys`
 
 Este endpoint é utilizado para adicionar um novo brinquedo à base de dados.
 
 ![POST](https://github.com/user-attachments/assets/6a0b1c79-e93a-4e3e-979b-24a8f33027a8)
 
 #### Exemplo de body JSON para criar um brinquedo:
 {
   "name_toy": "Telma",
   "type_toy": "Jogo",
   "classification_toy": 8,
   "brand_toy": "Kids",
   "price_toy": 39.90
 }
 
 
 -------------------------
 
 ### 2. `GET /Toys`
 
 Este Endpoint é utilizado para trazer as informações de um brinquedo ja cadastrado quando digitamos o ID conforme tabela.
 
 ![GET](https://github.com/user-attachments/assets/0c6062b1-aca2-4ca6-8915-a606587d9165)
 
 -------------------
 
 ### 3. `PUT /Toys`
 
 Este endpoint é utilizado para atualizar os dados de um brinquedo existente.
 
 ![PUT](https://github.com/user-attachments/assets/07c7282c-5cf0-49fc-8d30-c8d0526039de)
 
 -------------------
 
 ### 4. `DELETE /Toys`
 
 Este endpoint é utilizado para excluir um brinquedo específico pelo seu ID.
 
 ![DELETE](https://github.com/user-attachments/assets/bda3c7f0-1258-45dd-a204-15b2d3718e25)
 
 
 ### Clone o repositório
    ```sh
    git clone https://github.com/luccabasto/ToyStore_API.git
