DROP TABLE contas_pagar;
CREATE TABLE contas_pagar(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	valor DECIMAL(10,2),
	tipo VARCHAR(100),
	descricao VARCHAR(300),
	status VARCHAR(100)
);
DROP TABLE contas_receber;
CREATE TABLE contas_receber(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	valor DECIMAL(10,2),
	tipo VARCHAR(100),
	descricao VARCHAR(300),
	status VARCHAR(50)
);
DROP TABLE clientes_pessoa_fisica;
CREATE TABLE clientes_pessoa_fisica(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	cpf VARCHAR(15),
	data_nascimento DATETIME2,
	rg VARCHAR(15),
	sexo VARCHAR(30)
);
DROP TABLE clientes_pessoa_juridica;
CREATE TABLE clientes_pessoa_juridica(
	id INT PRIMARY KEY IDENTITY(1,1),
	cnpj VARCHAR(50),
	razao_social VARCHAR(100),
	inscricao_estadual VARCHAR(100)
);

CREATE TABLE enderecos(
	id INT PRIMARY KEY IDENTITY(1,1),
	unidade_federativa VARCHAR(10),
	cidade VARCHAR(100),
	logradouro VARCHAR(100),
	cep VARCHAR(9),
	numero INT,
	complemento VARCHAR(100)
);