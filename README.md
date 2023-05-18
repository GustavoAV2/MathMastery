# Resumo

Uma plataforma com desafios interativos que visa desenvolver
o raciocínio rápido, lógico e matemático. Esse site oferece diferentes níveis de dificuldade
para os desafios matemáticos, permitindo que você escolha aqueles que se adequam ao
seu nível de habilidade. Isso significa que iniciantes e especialistas em matemática (em desenvolvimento)
podem encontrar desafios adequados às suas necessidades e continuar progredindo em suas habilidades.

O objetivo deste projeto é meu próprio desenvolvimento pessoal e
criar um ambiente de aprendizado interativo e estimulante para todos os usuários.
Onde você pode aprimorar suas habilidades e se conectar com
outros colegas para competir e evoluir juntos.

# API Math Mastery

API desenvolvida em C# ASP .NET Core 6, alimenta e consome o banco de dados SQL e gerencia os desafios do site.

## Requisitos

Certifique-se de ter as seguintes ferramentas instaladas em seu sistema local:

- AspNetCore 6 SDK: [Link para download](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (ou qualquer outro banco de dados de sua preferência)
- Git: [Link para download](https://git-scm.com/downloads)

## Configuração

1. Clone o repositório:

```bash
git clone https://github.com/GustavoAV2/MathMastery.git
```

2. Acesse o diretório do projeto:

```bash
cd MathMastery
```

3. Restaure as dependências do projeto:

```bash
dotnet restore
```

4. Criar banco de dados local

```PM
Add-Migration MigrationName

Update-Database
```

5. Compile e execute o projeto `MathMastery`.

O servidor estará disponível em `https://localhost:7224/` por padrão.

## Endpoints da API

- `GET /api/exemplo`: Retorna todos os exemplos.
- `GET /api/exemplo/{id}`: Retorna o exemplo com o ID fornecido.
- `POST /api/exemplo`: Cria um novo exemplo.
- `PUT /api/exemplo/{id}`: Atualiza o exemplo com o ID fornecido.
- `DELETE /api/exemplo/{id}`: Remove o exemplo com o ID fornecido.

## Estrutura do Projeto

Explicação breve sobre a estrutura de diretórios da aplicação:

MathMastery:

- `Controllers/`: Contém os controladores da API.
- `appsettings.json`: Arquivo de configuração da aplicação.

MathMastery.Domain:

- `Models/`: Contém os modelos de dados do projeto.
- `Entities/`: Contém as entidades que representam os objetos do banco de dados.
- `Dtos/`: Obejtos de transferencia de dados (Futuramente serão removidos).

MathMastery.Service

- `Services/`: Contém as classes de serviço para manipulação de dados.

MathMastery.Database

- `Data/`: Contém as configurações e o contexto do banco de dados.

# Frontend Math Mastery

Desenvolvido em Vue.Js, com foco em ser intuitivo e pratico aos usuários.

## Pré-requisitos

Antes de começar, verifique se você possui os seguintes requisitos instalados em seu ambiente de desenvolvimento:

- Node.js (versão 18.16.0)
- npm (versão 6.4.1)
- Vue CLI (versão 3.2.45)

## Instalação

Siga as etapas abaixo para configurar e executar o projeto localmente:

1. Clone este repositório em sua máquina local:

   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   ```

2. Acesse o diretório do projeto:

   ```bash
   cd nome-do-repositorio
   ```

3. Instale as dependências do projeto usando o npm:

   ```bash
   npm install
   ```

## Uso

Para iniciar o servidor de desenvolvimento e visualizar o projeto em seu navegador, execute o seguinte comando:

```bash
npm run serve
```

Após a compilação bem-sucedida, o projeto estará disponível em `http://localhost:8080`.

## Compilação e Empacotamento

Para compilar e empacotar o projeto para produção, utilize o seguinte comando:

```bash
npm run build
```

Os arquivos resultantes serão gerados no diretório `dist/`. Você pode implantar esses arquivos em um servidor web para disponibilizar o projeto online.

## Configuração de Docker

1. Criar imagem:

```bash
docker build -t user/api_mathmastery .
```

2. Criar e iniciar Container:

```bash
docker run -p 3000:5173 -d user/api_mathmastery
```

ou

Com Docker Compose: [Link para download](https://docs.docker.com/compose/install/)

1. Criar imagem e iniciar container:

```bash
docker-compose up
```

Lembrando que as portas seguem a seguinte ordem `suaPorta:portaDoContainer`

---

## Licença

### MIT License

Copyright (c) 2023 Gustavo Voltolini

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## Contribuindo

Se você deseja contribuir para este projeto, siga as etapas abaixo:

1. Fork este repositório.
2. Crie uma nova branch com sua nova funcionalidade: `git checkout -b minha-nova-funcionalidade`.
3. Faça suas alterações e adicione os devidos testes.
4. Verifique se os testes estão passando: `dotnet test`.
5. Envie suas alterações: `git commit -m 'Adicionando minha nova funcionalidade'`.
6. Envie para o repositório original: `git push origin minha-nova-funcionalidade`.
7. Envie uma pull request explicando suas alterações.

## Contato

Para dúvidas ou sugestões, sinta-se à vontade para entrar em contato:

- Nome: Gustavo Antunes Voltolini
- Email: gustavoant.voltolini@gmail.com
