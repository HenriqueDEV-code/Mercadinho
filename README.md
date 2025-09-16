# 🛒 Gestão Mercadinho

Projeto acadêmico em **C# WinForms** para gerenciar produtos de um mercadinho.  
Permite cadastrar, listar, pesquisar, atualizar estoque e realizar operações básicas em banco de dados SQL Server.

---

## 📌 Funcionalidades

- ✅ Cadastro de produtos (nome, preço, quantidade)  
- ✅ Pesquisa de produtos por nome ou descrição  
- ✅ Incremento e decremento da quantidade direto na tabela (`+1` / `-1`)
- ✅ Conexão com banco SQL Server usando `Microsoft.Data.SqlClient`  
- ✅ Estrutura em camadas: **Forms**, **Model**, **Config**, **Resources**  
- ✅ Interface simples e intuitiva  

---

## 🗂 Estrutura do Projeto
<img width="512" height="562" alt="image" src="https://github.com/user-attachments/assets/6b532500-6005-46da-a0e5-03f39aa971b7" />



---

## ⚙️ Configuração do Banco de Dados

- Banco: **SQL Server**  
- Exemplo de string de conexão (`DBConfig.cs`):

```csharp
private const string ConnString = 
    "Data Source=.\\SQLEXPRESS;Initial Catalog=Banco_Unip;Persist Security Info=True;User ID=sa;Password=SuaSenha;Encrypt=False";

▶️ Como Executar

Clone o repositório:

[git clone https://github.com/seuusuario/gestao-mercadinho.git](https://github.com/HenriqueDEV-code/Mercadinho.git)


Abra a solução no Visual Studio 2022 (ou superior).

Restaure pacotes NuGet (já usa Microsoft.Data.SqlClient).

Configure o banco de dados no DBConfig.cs ou Config.json.

Execute o projeto (F5).

🎨 Interface

Tela de Produtos: mostra lista de produtos, botões para incrementar/decrementar e busca.

Tela de Cadastro: adiciona novos produtos.

Tela PDV: (exemplo de ponto de venda simples).

📦 Dependências

.NET 6 ou superior

SQL Server (Express ou Developer)

Pacote NuGet: Microsoft.Data.SqlClient

👨‍💻 Autor

Projeto desenvolvido por Luis Henrique
📧 Email: henriquebelotti09@gmail.com

🔗 GitHub: HenriqueDEV-code


