# AutonomusParking

# 🚗 Sistema de Estacionamento Automático (C#)

Projeto desenvolvido em **C# (.NET)** simulando o funcionamento de um **estacionamento automático** com múltiplos andares, controle de vagas, cálculo de permanência e geração de relatórios administrativos.

O sistema foi estruturado utilizando uma **arquitetura em camadas (Model / Service / Data / Program)** e persistência de dados em **JSON**, permitindo manter o estado do estacionamento mesmo após reiniciar a aplicação.

---

# 📌 Funcionalidades

## 👤 Usuário

* Estacionar veículo
* Escolher o **tipo de veículo**
* Visualizar **vagas disponíveis por andar**
* Escolher o **andar para estacionar**
* Registrar **hora de entrada**
* Registrar **hora de saída**
* Cálculo automático do **valor total a pagar**

### Valores por tipo de veículo

| Tipo de Veículo | Valor por Hora |
| --------------- | -------------- |
| Carro Popular   | R$5            |
| Caminhonete     | R$7            |

---

## 🔑 Administrador

Acesso protegido por **senha**.

Funcionalidades disponíveis:

* Visualizar **relatório do estacionamento**
* Ver **total de vagas**
* Ver **vagas ocupadas e disponíveis**
* Listar **veículos atualmente estacionados**
* Visualizar **faturamento total**

---

# 🏢 Estrutura do Estacionamento

O estacionamento possui:

* **3 andares**
* **10 vagas por andar**
* Total de **30 vagas**

Cada vaga possui:

* Número da vaga
* Andar
* Status (ocupada ou livre)

---

# 💾 Persistência de Dados

O sistema utiliza **JSON** para salvar os dados dos veículos estacionados.

Arquivo utilizado:

```
DataFiles/veiculos.json
```

Quando a aplicação inicia:

1. As vagas são criadas.
2. Os veículos são carregados do arquivo JSON.
3. O sistema **reconstrói o estado das vagas ocupadas** com base nos veículos armazenados.

Isso garante que **as vagas continuem ocupadas mesmo após reiniciar o sistema**.

---

# 🧠 Conceitos Aplicados

Este projeto demonstra diversos conceitos importantes de desenvolvimento em C#:

* Programação Orientada a Objetos (POO)
* Separação de responsabilidades
* Arquitetura em camadas
* Serialização e desserialização JSON
* Manipulação de arquivos
* Uso de Enum
* LINQ (`FirstOrDefault`, `GroupBy`)
* Controle de estado da aplicação

---

# 🏗 Arquitetura do Projeto

```
Estacionamento
│
├── Models
│   ├── Veiculo.cs
│   ├── Vaga.cs
│   └── TipoVeiculo.cs
│
├── Services
│   └── EstacionamentoService.cs
│
├── Data
│   └── JsonRepository.cs
│
├── DataFiles
│   └── veiculos.json
│
└── Program.cs
```

### Responsabilidades

| Camada   | Responsabilidade                       |
| -------- | -------------------------------------- |
| Models   | Estrutura das entidades do sistema     |
| Services | Regras de negócio                      |
| Data     | Persistência de dados                  |
| Program  | Interface do usuário (menu do console) |

---

# 👨‍💻 Autor

Projeto desenvolvido por **Arielson Silva**
Formação em **Análise e Desenvolvimento de Sistemas**

Este projeto foi desenvolvido como prática de **lógica de programação, arquitetura de software e desenvolvimento em C#**.
