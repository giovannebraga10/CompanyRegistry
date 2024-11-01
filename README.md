# CompanyRegistry

CompanyRegistry é uma API RESTful construída em .NET para o gerenciamento de empresas e usuários. Este projeto foi desenvolvido para atender a requisitos de cadastro, edição, consulta, inativação e exclusão de registros no banco de dados de uma aplicação corporativa.

## 📋 Índice
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Funcionalidades](#funcionalidades)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints](#endpoints)
- [Instalação e Configuração](#instalação-e-configuração)

## 💻 Tecnologias Utilizadas
- **Linguagem:** C# (.NET 6)
- **Banco de Dados:** PostgreSQL
- **ORM:** Entity Framework Core
- **Arquitetura:** Layered Architecture

## ⚙️ Funcionalidades
### Empresas
- Adicionar, Editar, Inativar, Excluir e Consultar empresas.
- Consulta por tipo de empresa.
- Verificação de unicidade do CNPJ.

### Usuários
- Adicionar, Editar, Inativar, Excluir e Consultar usuários.
- Consulta por perfil de usuário.
- Verificação de unicidade do CPF.

## 📂 Estrutura do Projeto
- **Controllers:** Contém os controladores para gerenciar as requisições HTTP.
- **Services:** Camada de lógica de negócio.
- **Repositories:** Camada de acesso a dados com operações de CRUD.
- **Models:** Classes de modelo que representam as entidades no banco de dados.
- **Data:** Configuração do AppDbContext com o Entity Framework.

## 📖 Endpoints

### Empresas
| Método    | Endpoint                       | Descrição                        |
|-----------|--------------------------------|----------------------------------|
| `GET`     | `/api/companies`               | Lista todas as empresas          |
| `GET`     | `/api/companies/{id}`          | Retorna uma empresa específica   |
| `POST`    | `/api/companies`               | Adiciona uma nova empresa        |
| `PUT`     | `/api/companies/{id}`          | Atualiza uma empresa existente   |
| `DELETE`  | `/api/companies/{id}`          | Exclui uma empresa               |
| `PUT`     | `/api/companies/disable/{id}`  | Inativa uma empresa              |

### Tipos de Empresa
| Método    | Endpoint                       | Descrição                           |
|-----------|--------------------------------|-------------------------------------|
| `GET`     | `/api/companytypes`            | Lista todos os tipos de empresas    |
| `GET`     | `/api/companytypes/{id}`       | Retorna um tipo de empresa específico |
| `POST`    | `/api/companytypes`            | Adiciona um novo tipo de empresa    |
| `DELETE`  | `/api/companytypes/{id}`       | Exclui um tipo de empresa           |

### Usuários
| Método    | Endpoint                       | Descrição                        |
|-----------|--------------------------------|----------------------------------|
| `GET`     | `/api/users`                   | Lista todos os usuários          |
| `GET`     | `/api/users/{id}`              | Retorna um usuário específico    |
| `GET`     | `/api/users/types/{typeId}`    | Lista usuários por tipo          |
| `POST`    | `/api/users`                   | Adiciona um novo usuário         |
| `PUT`     | `/api/users/{id}`              | Atualiza um usuário existente    |
| `DELETE`  | `/api/users/{id}`              | Exclui um usuário                |
| `PUT`     | `/api/users/disable/{id}`      | Inativa um usuário               |

### Tipos de Usuário
| Método    | Endpoint                       | Descrição                           |
|-----------|--------------------------------|-------------------------------------|
| `GET`     | `/api/usertypes`               | Lista todos os tipos de usuários    |
| `GET`     | `/api/usertypes/{id}`          | Retorna um tipo de usuário específico |
| `POST`    | `/api/usertypes`               | Adiciona um novo tipo de usuário    |
| `PUT`     | `/api/usertypes/{id}`          | Atualiza um tipo de usuário         |
| `DELETE`  | `/api/usertypes/{id}`          | Exclui um tipo de usuário           |

## 🚀 Instalação e Configuração
1. **Clone o repositório:**
   ```bash
   git clone https://github.com/giovannebraga10/CompanyRegistry.git
