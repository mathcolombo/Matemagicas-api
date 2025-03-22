# Matemágicas: Uma Jornada Divertida no Mundo da Matemática

Matemágicas é um jogo educativo online, projetado para tornar o aprendizado da matemática uma experiência divertida e envolvente para estudantes do ensino fundamental 1 (e além!). Através de desafios interativos e um formato de perguntas e respostas, o jogo estimula o raciocínio lógico e aprimora as habilidades matemáticas dos jogadores.

## Principais Características:

  - Aprendizagem Divertida: O jogo transforma conceitos matemáticos em desafios divertidos, incentivando o aprendizado através da prática e da exploração.
  - Conteúdo Abrangente: Inicialmente focado no ensino fundamental 1, o jogo possui um plano de expansão para abordar uma variedade de tópicos matemáticos, adaptando-se às necessidades de diferentes faixas etárias.
  - Feedback Personalizado: Ao final de cada partida, os jogadores recebem um relatório detalhado de seu desempenho, destacando seus pontos fortes e áreas que precisam de aprimoramento.
  - Acessibilidade: Desenvolvido como um aplicativo web, o jogo é acessível em diversos dispositivos, como computadores, tablets e smartphones, garantindo flexibilidade e praticidade para os usuários.
  - Banco de Dados na Nuvem: A utilização do MongoDB Atlas como banco de dados na nuvem simplifica o gerenciamento de dados e garante escalabilidade para o projeto.

## Tecnologias usadas:
  - .Net
  - React
  - MongoDB

## Modelagem do banco de dados

### Users

Armazena informações sobre os jogadores.

   - _id: ObjectId (identificador único do usuário)
   - name: String (nome do jogador)
   - age: Number (idade do jogador)
   - email: String (endereço de e-mail do jogador)
   - password: String (senha criptografada do jogador)
   - total_score: Number (pontuação acumulada pelo jogador)
   - game_history: Array de ObjectIds (referências aos jogos realizados pelo jogador)

### Games

Armazena informações sobre cada partida realizada.

  - _id: ObjectId (identificador único do jogo)
  - user_id: ObjectId (referência ao usuário que realizou o jogo)
  - date: Date (data e hora da realização do jogo)
  - score: Number (pontuação obtida no jogo)
  - correct_answers: Number (número de questões respondidas corretamente)
  - incorrect_answers: Number (número de questões respondidas incorretamente)
  - questions: Array de ObjectIds (referências às questões do jogo)

### Questions

Armazena as perguntas e respostas do jogo.

  - _id: ObjectId (identificador único da questão)
  - question_text: String (texto da pergunta)
  - answer_options: Array de Strings (opções de resposta)
  - correct_answer_index: Number (índice da alternativa correta)
  - difficulty: String ("fácil", "médio", "difícil")
  - topic: String (tema da questão, ex: adição, subtração, etc)