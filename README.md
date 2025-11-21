# Gestão de Alojamentos Turísticos (POO – C#)

Aplicação em C# desenvolvida no âmbito da unidade curricular **Programação Orientada a Objetos** do curso de **Engenharia de Sistemas Informáticos (LESI) – IPCA**.  
O projeto implementa um sistema de gestão de alojamentos turísticos com foco em boas práticas de POO, princípios SOLID e arquitetura em camadas (N-tier).

## 🎯 Objetivo

Fornecer um pequeno sistema de consola para gerir alojamentos e reservas, permitindo:

- registar e consultar alojamentos;
- criar, atualizar, cancelar e listar reservas;
- garantir validação consistente dos dados;
- tratar erros de forma estruturada, com mensagens em vários idiomas.

## ✨ Funcionalidades principais

### Gestão de alojamentos

- Registo de novas casas (`House`) com:
  - nome, localidade, preço por noite;
  - número de quartos, capacidade máxima;
  - indicação de garagem e piscina.
- Atualização e remoção de alojamentos existentes.
- Verificação de disponibilidade.
- Ordenação de casas por preço (crescente).
- Persistência da lista de alojamentos em ficheiros binários
  (guardar e ler de ficheiro).

### Gestão de reservas

- Criação de reservas (`Reservation`) associadas a uma casa.
- Validação de datas de início/fim.
- Cálculo automático do custo da reserva com base no número de noites e no preço por noite.
- Atualização e remoção de reservas.
- Cancelamento de reservas (com marcação lógica via ID especial).
- Ordenação de reservas por data de início.
- Persistência da lista de reservas em ficheiros binários.

### Validação e tratamento de erros

- Classes de validação dedicadas para:
  - `House`
  - `HouseLight`
  - `Reservation`
- Lançamento de exceções específicas:
  - `HouseExceptions`
  - `ReservationExceptions`
  - `ValidateHouseExceptions`
  - `ValidateReservationExceptions`
- Mensagens de erro disponíveis em vários idiomas (português, inglês, espanhol, mandarim, hindi, árabe, francês, alemão, japonês, coreano, russo).

### Arquitetura em camadas (N-tier)

O projeto está organizado em várias camadas lógicas:

- **BusinessObjects**
  - `Accommodation` (classe abstrata)
  - `House`
  - `HouseLight`
  - `Reservation`
  - `Enums` (permissões de utilizador)
- **Data**
  - `Houses` (lista estática de casas e operações sobre a lista)
  - `Reservations` (lista estática de reservas e operações sobre a lista)
- **Rules**
  - `HouseRules`
  - `ReservationRules`  
  Camada que expõe operações da camada de dados à camada de apresentação, respeitando níveis de permissões.
- **Validations**
  - `ValidateHouse`
  - `ValidateHouseLight`
  - `ValidateReservation`
- **TreatProblems**
  - Todas as classes de exceções e mensagens de erro.
- **UI / Apresentação**
  - Projeto `trabalhoPOO_27957_fase2` com a classe `Program`, usada para testar e demonstrar as funcionalidades via consola.

## 🧱 Tecnologias e conceitos

- Linguagem: **C#**
- Paradigma: **Programação Orientada a Objetos**
  - Abstração, encapsulamento, herança, polimorfismo.
- Princípios **SOLID**:
  - Single Responsibility Principle (SRP)
  - Open/Closed Principle (OCP)
  - Dependency Inversion Principle (DIP)
- Arquitetura **N-tier** com separação clara entre:
  - objetos de negócio,
  - acesso/manipulação de dados,
  - regras de negócio,
  - validações,
  - tratamento de erros,
  - apresentação.
- Persistência em ficheiros binários.
