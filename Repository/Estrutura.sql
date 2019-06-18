﻿DROP TABLE contas_pagar;
CREATE TABLE contas_pagar(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	valor DECIMAL(10,2),
	tipo VARCHAR(100),
	descricao VARCHAR(300),
	status VARCHAR(100)
);

CREATE TABLE contas_receber(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	valor DECIMAL(10,2),
	tipo VARCHAR(100),
	descricao VARCHAR(300),
	status VARCHAR(50)
);