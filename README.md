# CSharp_CP5

Sistema web desenvolvido em **ASP.NET Core MVC** para gerenciamento e venda de jogos digitais.

## **Integrantes**

* **Beatriz Silva Pinheiro Rocha - RM553455 - Dev**
* **Iago Diniz Fontes - RM553776 - Dev**
* **Larissa Estella Gonçalves dos Santos - RM552695 - Tech Lead**
* **Rafael Alves do Nascimento - RM553117 - Dev**

---

##  Funcionalidades

### Usuário
- Registro de conta
- Login e logout
- Visualização de jogos

### Admin
- Cadastro de novos jogos
- Edição de jogos existentes
- Exclusão de jogos
- Acesso ao painel de gerenciamento

---

## Arquitetura do Projeto

O projeto segue o padrão **MVC (Model-View-Controller)** com separação de responsabilidades:

```
GameStore/
├── Program.cs   
│
├── Controllers/
│   ├── AuthController.cs
│   ├── GameController.cs
│   └── AdminController.cs
├── Data/
│   ├── AppDbContext.cs
├── Interfaces/
│   ├── IGameRepository.cs
│   ├── IUserRepository.cs
├── Migrations/
├── Models/
│   ├── Game.cs
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   ├── User.cs
│   ├── ErrorViewModel.cs
├── Repositories/
│   ├── GameRepository.cs
│   ├── UserRepository.cs
├── Services/
│   ├── DatabaseInitializer.cs
└── Views/
	├── Auth/
	│   ├── Login.cshtml
	│   └── Register.cshtml
	├── Game/
	│   ├── Create.cshtml
	│   ├── Index.cshtml
	│   └── Edit.cshtml
	├── Home/
	│   └── Index.cshtml
	└── Shared/
		└── _Layout.cshtml
```

---

##  Banco de Dados

O projeto utiliza **MySQL** com **Entity Framework Core**.

###  Inicialização automática
Ao rodar o projeto:

- O banco é criado automaticamente
- As tabelas são geradas via migrations
- Dados iniciais são inseridos (seed)

---

##  Acesso padrão (Admin)

```

Email: admin@gamestore.com
Senha: 123456

````

---

##  Como Executar o Projeto

### 1. Clonar repositório e abrir projeto

```bash
git clone https://github.com/seu-usuario/CSharp_CP5.git
cd gamestore
start GameStore.csproj
````

---

### 2. Configurar conexão com MySQL

No arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=gamestore;user=root;password=SUASENHA"
}
```

---

### 3. Instalar dependências

```bash
dotnet restore
```

---

### 4. Rodar projeto

```bash
dotnet run
```


