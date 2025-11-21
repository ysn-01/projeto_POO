# Gestão de Alojamentos Turísticos (POO – C#)

## Autor
- **Nome:** Yuri Nascimento, Tiago Ferreira
- **Número:** 27957, 27980
- **Curso:** Engenharia de Sistemas Informáticos

---

Aplicação em C# desenvolvida no âmbito da unidade curricular **Programação Orientada a Objetos**.

O projeto implementa um sistema de gestão de alojamentos turísticos com foco em boas práticas de POO, princípios SOLID e arquitetura em camadas (N-tier).

## Objetivo

Fornecer um pequeno sistema de consola para gerir alojamentos e reservas, permitindo:

- registar e consultar alojamentos;
- criar, atualizar, cancelar e listar reservas;
- garantir validação consistente dos dados;
- tratar erros de forma estruturada, com mensagens em vários idiomas.

## Funcionalidades principais

### Gestão de alojamentos

- Registo de novas casas (`House`) com:
  - nome, localidade, preço por noite;
  - número de quartos, capacidade máxima;
  - indicação de garagem e piscina.

- Atualização e remoção de alojamentos existentes.
- Verificação de disponibilidade.
- Ordenação de casas por preço (crescente).
- Persistência da lista de alojamentos em ficheiros binários.

### Gestão de reservas

- Criação de reservas (`Reservation`) associadas a uma casa.
- Validação de datas de início/fim.
- Cálculo automático do custo da reserva com base no número de noites e no preço por noite.
- Atualização e remoção de reservas.
- Cancelamento de reservas (com marcação lógica via ID especial).
- Ordenação de reservas por data de início.
- Persistência de reservas em ficheiros binários.

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
    
- Mensagens de erro disponíveis em vários idiomas.

### Arquitetura em camadas (N-tier)

O projeto está organizado em:

- **BusinessObjects**
- **Data**
- **Rules**
- **Validations**
- **TreatProblems**
- **UI**

## Tecnologias e conceitos

- C#
- POO (abstração, encapsulamento, herança, polimorfismo)
- SOLID
- Arquitetura N-tier
- Persistência em ficheiros binários
