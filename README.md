# CSharp_CP4

Sistema web desenvolvido em **ASP.NET Core MVC** para gerenciamento e venda de jogos digitais.

## **Integrantes**

* **Beatriz Silva Pinheiro Rocha - RM553455**
* **Iago Diniz Fontes - RM553776**
* **Larissa Estella Gonçalves dos Santos - RM552695**
* **Rafael Alves do Nascimento - RM553117**

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
│
├── Controllers/
├── Data/
├── Interfaces/
├── Migrations/
├── Models/
├── Repositories/
├── Services/
└── Views/
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

## 🔐 Acesso padrão (Admin)

```

Email: admin@gamestore.com
Senha: 123456

````

---

##  Como Executar o Projeto

### 1. Clonar repositório

```bash
git clone https://github.com/seu-usuario/gamestore.git
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


