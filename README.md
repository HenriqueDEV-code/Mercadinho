# 🛒 Gestão Mercadinho

Projeto acadêmico em **C# WinForms** para gerenciar produtos de um mercadinho.  
Permite cadastrar, listar, pesquisar, atualizar estoque e realizar operações básicas em banco de dados SQL Server.

---

## 📌 Funcionalidades

- ✅ Cadastro de produtos (nome, preço, quantidade)  
- ✅ Pesquisa de produtos por nome ou descrição  
- ✅ Incremento e decremento da quantidade direto na tabela (`+1` / `-1`)  
- ✅ Atualização de estoque com verificação para não permitir valores negativos  
- ✅ Conexão com banco SQL Server usando `Microsoft.Data.SqlClient`  
- ✅ Estrutura em camadas: **Forms**, **Model**, **Config**, **Resources**  
- ✅ Interface simples e intuitiva  

---

## 🗂 Estrutura do Projeto
Gestao_Mercadinho/
│
├── Config/ # Configurações (ex.: Config.json)
│
├── Forms/ # Telas (WinForms)
│ ├── FormsCadastrar.cs # Tela de cadastro de produtos
│ ├── FormsPDV.cs # Tela de ponto de venda
│ └── FormsProdutos.cs # Tela de listagem e gerenciamento de produtos
│
├── Model/ # Camada de acesso a dados e entidades
│ ├── DBConfig.cs # Classe de conexão com o banco
│ ├── ItemVenda.cs # Entidade de item de venda
│ ├── Select.cs # Classe para SELECT
│ └── Update.cs # Classe para UPDATE
│
├── Resources/ # Ícones e imagens usados na UI
│
├── ViewModel/ # Classes auxiliares para telas (ex.: Home)
│
├── Program.cs # Ponto de entrada da aplicação
└── README.md # Este arquivo


---

## ⚙️ Configuração do Banco de Dados

- Banco: **SQL Server**  
- Exemplo de string de conexão (`DBConfig.cs`):

```csharp
private const string ConnString = 
    "Data Source=.\\SQLEXPRESS;Initial Catalog=Banco_Unip;Persist Security Info=True;User ID=sa;Password=SuaSenha;Encrypt=False";

