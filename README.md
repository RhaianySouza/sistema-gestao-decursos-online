# Sistema de Gestão de Cursos Online

## Descrição

Este projeto é um sistema web para gestão de cursos online, desenvolvido em ASP.NET Core MVC. Ele permite o gerenciamento de usuários, cursos, matrículas e avaliações, facilitando o controle e a administração de uma plataforma de ensino à distância.

---

## Principais Funcionalidades

* **Cadastro e gerenciamento de usuários:** Permite criar, editar, listar e excluir usuários da plataforma.
* **Gestão de cursos:** Criação, edição, listagem e exclusão de cursos disponíveis.
* **Matrículas:** Controle das matrículas dos usuários nos cursos, permitindo inscrição e cancelamento.
* **Avaliações:** Sistema para os usuários realizarem avaliações dos cursos.
* **Autenticação e autorização:** Controle de acesso baseado em perfis de usuários (exemplo: administrador, aluno).
* **Interface amigável:** Uso de Razor Pages e Views para navegação intuitiva.
* **Configuração via appsettings:** Configurações separadas para ambientes de desenvolvimento e produção.
* **Inicialização de banco de dados:** Classe para popular o banco de dados com dados iniciais.

---

## Estrutura do Projeto

* **Controllers/** — Controladores MVC que gerenciam as requisições e lógica de negócio.
* **Models/** — Classes que representam as entidades do sistema (Usuário, Curso, Matrícula, Avaliação).
* **Views/** — Páginas Razor e Views para renderização da interface do usuário.
* **Database/** — Contexto do banco de dados (`ApplicationDbContext.cs`) e inicializador (`GestaoCursoOnlineDbInitializer.cs`).
* **wwwroot/** — Arquivos estáticos como CSS, JS e imagens.
* **appsettings.json** e **appsettings.Development.json** — Arquivos de configuração para diferentes ambientes.

---

## Tecnologias Utilizadas

* ASP.NET Core MVC
* Entity Framework Core (ORM para acesso a banco de dados)
* Razor Pages e Views
* SQL Server (ou outro banco configurado no contexto)
* C#
* HTML, CSS, JavaScript para a interface

---
## Estrutura de Tabelas
O banco de dados é composto por 5 tabelas principais:

- Usuarios
- Cursos
- CursoUsuario
- Matriculas
- Avaliacoes

1. Usuarios
Representa os usuários do sistema (alunos).<br/>
| Campo     | Tipo   | Restrições                            |<br/>
| --------- | ------ | ------------------------------------- |<br/>
| UsuarioId | int    | Chave primária                        |<br/>
| Nome      | string | Obrigatório, máx. 100 caracteres      |<br/>
| Email     | string | Obrigatório, máx. 150 caracteres      |<br/>
| Senha     | string | Obrigatório, entre 6 e 100 caracteres |<br/>
| Telefone  | string | Opcional, máx. 20 caracteres          |<br/>

Relacionamentos:
- Muitos para muitos com Cursos via CursoUsuarioModel
- Um para muitos com Matriculas

2. Cursos
Representa os cursos disponíveis no sistema.<br/>
| Campo        | Tipo   | Restrições                       |<br/>
| ------------ | ------ | -------------------------------- |<br/>
| CursoId      | int    | Chave primária                   |<br/>
| Titulo       | string | Obrigatório, máx. 100 caracteres |<br/>
| Descricao    | string | Opcional, máx. 500 caracteres    |<br/>
| CargaHoraria | int    | Obrigatório                      |<br/>
Relacionamentos:
- Muitos-para-muitos com Usuarios via CursoUsuarioModel
- Um-para-muitos com Matriculas

3. CursoUsuarioModel
Tabela associativa para representar um relacionamento muitos-para-muitos entre Usuarios e Cursos.<br/>
| Campo     | Tipo | Descrição          |<br/>
| --------- | ---- | ------------------ |<br/>
| Id        | int  | Chave primária     |<br/>
| UsuarioId | int  | FK para `Usuarios` |<br/>
| CursoId   | int  | FK para `Cursos`   |<br/>


4. Matriculas
Representa a inscrição de um usuário em um curso.<br/>
| Campo         | Tipo     | Descrição                                                     |<br/>
| ------------- | -------- | ------------------------------------------------------------- |<br/>
| MatriculaId   | int      | Chave primária                                                |<br/>
| UsuarioId     | int      | FK para `Usuarios`                                            |<br/>
| CursoId       | int      | FK para `Cursos`                                              |<br/>
| DataMatricula | DateTime | Data da matrícula                                             |<br/>
| Status        | string   | Status atual da matrícula ("Ativo", "Concluído", "Cancelado") |<br/>

5. Avaliacoes
Representa as avaliações feitas pelos usuários em relação aos cursos.<br/>
| Campo       | Tipo     | Descrição                     |<br/>
| ----------- | -------- | ----------------------------- |<br/>
| AvaliacaoId | int      | Chave primária                |<br/>
| MatriculaId | int      | FK para `Matriculas`          |<br/>
| Nota        | int      | Obrigatório, entre 1 e 10     |<br/>
| Comentario  | string   | Opcional, máx. 500 caracteres |<br/>
| Data        | DateTime | Data da avaliação             |<br/>

6. 🔗 Relacionamentos
- Uma avaliação pertence a uma matrícula.
- Cada matrícula pode ter zero ou uma avaliação associada.

---

## Como Rodar o Projeto

1. Clone o repositório:

   ```
   git clone https://github.com/RhaianySouza/sistema-gestao-decursos-online.git
   ```
2. Abra o projeto na sua IDE (Visual Studio, VS Code).
3. Configure a string de conexão no arquivo `appsettings.json`.
4. Execute a aplicação.
5. Acesse `https://localhost:<porta>` no navegador.

---
## Autores

Andriele, Ciro, Eric, Leonardo, Rhaiany

