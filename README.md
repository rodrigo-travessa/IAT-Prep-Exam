# IatPrepExam
IAT Prep Exam is a quiz app that lets you create and take quizzes with any number of questions. Simply register your questions, then request a quiz. Quizmaster will randomly select questions from the database and give you a multiple-choice quiz. After you've finished answering, you can check the results screen to see how well you did, how long it took you to complete the quiz, and the average time for each question.

IAT Prep Exam differentiates between users and administrators. Only administrators can delete questions, but anyone can add questions to the database. Additionally, only the user or an administrator can delete quiz history.

Since IAT Prep Exam was created to help a small group of friends, instead of large-scale usage, the details and results of quizzes are not hidden from other users. However, this would be trivial to change.

#IAT Exame Preparatório

Este aplicativo permite que os usuários se cadastrem usando o .NET EFCore Identity, isso garante acesso rápido e seguro a autenticação de 2 fatores, troca de senha, confirmação de criação de conta e guarda segura das senhas tudo fornecido pelo EFCore.

O aplicativo foi criado pra resolver um problema específico, permitir que nós que estávamos pra realizar a prova de IAT pudéssemos cadastrar nossas próprias questões e gerar simulados para praticar, dada a especificidade da prova e a falta de conteúdo online, o site foi criado de maneira que qualquer usuário (como eu confio nos usuários não precisei limitar acesso) possa criar questões de múltipla escolha usando um sistema simples e intuitivo, essas questões são então guardadas num banco de Dados SQL no provedor Cloud Azure, que permitiu que todos tivessem acesso de qualquer lugar.

Cada usuário poderia então gerar simulados, respondê-los e consultar seu histórico, podendo assim ter uma expectativa realista de como se sairia na prova que estava por vir.

![Homepage](https://github.com/rodrigo-travessa/IAT-Prep-Exam/assets/90840099/15fa84fa-cd2b-4780-93be-f43c0cd390a8)
![questionIndex](https://github.com/rodrigo-travessa/IAT-Prep-Exam/assets/90840099/a8c367cd-8f42-4d62-bc86-02b635b82ec8)
![creatingQuestions](https://github.com/rodrigo-travessa/IAT-Prep-Exam/assets/90840099/04e5b436-eea5-4999-bff4-df668fac11e1)
![quizzIndex (2)](https://github.com/rodrigo-travessa/IAT-Prep-Exam/assets/90840099/9e76775f-493d-47f4-8001-34a8eb46b3fb)
![creatingQuizz](https://github.com/rodrigo-travessa/IAT-Prep-Exam/assets/90840099/c544096f-b0ad-4d64-8a72-5c4f3f58a0e5)
![takingthequizz](https://github.com/rodrigo-travessa/IAT-Prep-Exam/assets/90840099/a8f713ad-6382-45ef-94cc-4a00c836b9c9)
![results](https://github.com/rodrigo-travessa/IAT-Prep-Exam/assets/90840099/ba25de9f-b040-40b2-9004-1755fe465e27)


To be able to run your own instance you will need .net 7, SQL server and Visual Studio.

You can download the solution, run EFCore migrations with update-database in the package manager console.

After the Database is created select the Development branch and run it.
