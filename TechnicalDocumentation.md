# 🚀 Documentação Técnica do Projeto Matemágicas 2.0

## 🎯 1. Visão Geral do Projeto

Matemágicas é mais que um jogo. É uma plataforma educacional gamificada que usa a matemática para impulsionar o aprendizado. 📚

Nosso objetivo é transformar o desafio da matemática em uma aventura divertida, dando a alunos, professores e administradores as ferramentas certas para conquistar cada etapa.
| Perfil de Usuário	| Funções Principais |
|---|---|
| 👩‍🎓 Aluno	| Joga partidas personalizadas, acompanha seu progresso e se diverte. |
| 👨‍🏫 Professor	| Gerencia turmas, personaliza o conteúdo do jogo e monitora o desempenho dos alunos. |
| 👩‍💼 Administrador	| Supervisiona escolas, gerencia professores e tem uma visão panorâmica do sistema. |

## 🛠️ 2. Tecnologias e Ferramentas

| Categoria |	Ferramenta | Descrição
|---|---|---|
| Backend	| .NET (C#) | API RESTful com arquitetura limpa e orientada a objetos. |
| Backend	| JetBrains Rider | IDE de desenvolvimento backend. |
| Backend	| MongoDB.EntityFrameworkCore | ORM para a integração perfeita com o nosso banco de dados. |
| Frontend | React | Interface de usuário moderna e responsiva. |
| Frontend | Visual Studio Code | IDE de desenvolvimento frontend. |
| Banco de Dados | MongoDB Atlas | ☁️ Banco de dados NoSQL flexível e escalável, hospedado na nuvem. |
| Hospedagem | Render | Servidor para a nossa API. |
| Hospedagem | Vercel | Hospedagem para o nosso frontend. |
| Controle de Versão | Git & GitHub | 🌳 Árvore de commits para manter o projeto organizado. |

## 🏗️ 3. Modelo de Dados (MongoDB)

Nosso modelo de dados é o coração do sistema, refletindo a hierarquia de uma instituição de ensino. Utiliza documentos e referências para manter a flexibilidade do NoSQL.

### 🏫 schools (Coleção)

A raiz de tudo. Organiza turmas e usuários.

- Exemplo de Documento:
  
      {
        "_id": ObjectId("..."),
        "name": "Escola Municipal ABC",
        "address": "Rua das Flores, 123",
        "phone": "(11) 99999-9999"
      }

### 👥 users (Coleção)

Guarda as informações de todos os membros da nossa comunidade.

1. Vínculo: Todo usuário pertence a uma School 🏫.
2. Regra de Ouro: Um Aluno 🎓 só pode estar em uma Turma 👨‍🏫 por vez.

- Exemplo de Documento (Aluno):

      {
        "_id": ObjectId("..."),
        "name": "Maria Aluna",
        "email": "maria.aluna@email.com",
        "passwordHash": "senha_criptografada_aqui",
        "profile": "Aluno",
        "schoolId": ObjectId("..."),
        "classId": ObjectId("...")
      }

- Exemplo de Documento (Professor):

      {
        "_id": ObjectId("..."),
        "name": "João Professor",
        "email": "joao.prof@email.com",
        "passwordHash": "outra_senha_criptografada",
        "profile": "Professor",
        "schoolId": ObjectId("...")
      }

### 👨‍🏫 classes (Coleção)

Agrupa alunos e define as regras do jogo.

1. Vínculo: Cada turma pertence a uma School 🏫 e é gerenciada por um Professor 👨‍🏫.
2. Regra de Conteúdo: O professor pode configurar a turma para usar questões de Séries inferiores ou iguais à série da turma.

- Exemplo de Documento:
  
      {
        "_id": ObjectId("..."),
        "name": "Turma 5A",
        "series": 5, // A série escolar da turma
        "schoolId": ObjectId("..."),
        "professorId": ObjectId("..."),
        "studentIds": [ ObjectId("..."), ObjectId("...") ], // Alunos desta turma
        "allowedTopics": [ 0, 1, 2 ] // Tópicos liberados pelo professor
      }

### ❓ questions (Coleção)

O nosso acervo de desafios matemáticos.

1. Vínculo: A questão é um recurso independente, mas está associada a um Tópico e Série.
2. Relacionamento: Referência ao user que a criou (createdByUserId).

- Exemplo de Documento:

      {
        "_id": ObjectId("..."),
        "questionText": "Quanto é 2 + 2?",
        "answersOptions": [ "3", "4", "5", "6" ],
        "correctAnswerIndex": 1,
        "difficulty": 0, // 0: Fácil, 1: Médio, 2: Difícil
        "topic": 0, // Ex: 0 para 'Adição'
        "series": 3,
        "createdByUserId": ObjectId("...")
      }

### 🎮 games (Coleção)

Onde o histórico de aprendizado do aluno é registrado.

1. Vínculo: O jogo está diretamente ligado ao User 🎓, garantindo que o histórico permaneça com o aluno mesmo se ele mudar de turma.
2. Análise: Armazena o schoolId e o classId no momento do jogo para análises históricas e relatórios.

- Exemplo de Documento:

      {
        "_id": ObjectId("..."),
        "userId": ObjectId("..."),
        "schoolId": ObjectId("..."),
        "classId": ObjectId("..."),
        "date": ISODate("2025-08-08T15:00:00.000Z"),
        "score": 85,
        "difficulty": 1.2, // A média da dificuldade das questões do jogo
        "answers": [ { ... } ] // Histórico detalhado das respostas
      }

## 🧩 4. Requisitos Funcionais e Fluxos

- Geração de Jogo Inteligente: O sistema usa o histórico de games para identificar os pontos fracos do Aluno 🧠 e as dificuldades da Turma 📈 para criar jogos que reforçam o aprendizado.
- Relatórios e Dashboards: Professores 👨‍🏫 e Administradores 👩‍💼 podem visualizar o progresso dos alunos e da escola em tempo real, baseando-se nos dados das coleções games e classes.

## 🔒 5. Segurança e Acesso

O sistema adota um robusto controle de acesso baseado em papel (Role-Based Access Control - RBAC), garantindo que:
- Apenas Alunos podem jogar.
- Apenas Professores podem gerenciar suas turmas e criar questões.
- Apenas Administradores podem gerenciar escolas e perfis de usuários.
- Dados sensíveis (como passwordHash) são sempre criptografados.

---

Esta documentação serve como um guia completo para o desenvolvimento do Matemágicas 2.0, garantindo que todos os membros da equipe estejam na mesma página. Vamos construir algo incrível! ✨
