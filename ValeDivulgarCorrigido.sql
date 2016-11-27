#DROP DATABASE vale_divulgar;

CREATE DATABASE vale_divulgar;

USE vale_divulgar;

CREATE TABLE tpu_tipo_usuario(
tpu_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
tpu_descricao VARCHAR(50) NOT NULL);

                                                                                   
CREATE TABLE cid_cidade(
cid_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
cid_nome VARCHAR(100) NOT NULL UNIQUE);   -- Unique --


CREATE TABLE pla_plano(
pla_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
pla_nome VARCHAR(50) NOT NULL,
pla_qtd_dias INT);

CREATE TABLE usu_usuario(
usu_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
usu_login VARCHAR(15) NOT NULL UNIQUE,  -- UNIQUE !!!! --
usu_senha VARCHAR(15) NOT NULL,  
tpu_id INT NOT NULL,
cid_id INT NOT NULL,
CONSTRAINT usu_tpu FOREIGN KEY (tpu_id) REFERENCES tpu_tipo_usuario(tpu_id) ON UPDATE CASCADE,
CONSTRAINT usu_cid FOREIGN KEY (cid_id) REFERENCES cid_cidade(cid_id) ON UPDATE CASCADE);

/*insert into usu_usuario (usu_login,usu_senha)values('jose','AquiePalmeiras'),
('Maria','AquiePalmeiras'),
('Ricardo','AquiePalmeiras'),
('joao','AquiePalmeiras');*/


CREATE TABLE cli_cliente(
cli_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
cli_nome VARCHAR(100) NOT NULL UNIQUE,
cli_idade INT NOT NULL,
cli_email VARCHAR(45) NOT NULL UNIQUE,
cli_cpf VARCHAR(45) NOT NULL UNIQUE,
usu_id INT NOT NULL,
CONSTRAINT cli_usu FOREIGN KEY (usu_id) REFERENCES usu_usuario (usu_id));


/*insert into cli_cliente(cli_nome,cli_idade,cli_email,cli_cpf)values('Madara',23,'madarinha@hotmail.com','105616546'),
('Itachi',150,'Itachi@hotmail.com','105614446'),
('Hidan',2500,'Imortal@hotmail.com','1056167546'),
('Kakuzu',3000,'Dinheiro@hotmail.com','1055616546');*/


CREATE TABLE ctr_controle(
ctr_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
ctr_data_inicio VARCHAR(45) NOT NULL,
ctr_data_termino VARCHAR(45) NOT NULL,
pla_id INT NOT NULL,
usu_id INT NOT NULL,
CONSTRAINT pla_usu FOREIGN KEY (pla_id) REFERENCES pla_plano(pla_id),
CONSTRAINT ctr_usu FOREIGN KEY (usu_id) REFERENCES usu_usuario(usu_id));


/*insert into ctr_controle(ctr_data_inicio,ctr_data_termino)values(sysdate(),sysdate()+1),
(sysdate(),sysdate()+1),
(sysdate(),sysdate()+1),
(sysdate(),sysdate()+1);*/


-- select 
-- 		cli.cli_nome,
-- 		cli.cli_email,
--         cli.cli_cpf,
--         cli.cli_idade,
--         usu.usu_login,
--         usu.usu_senha,
--         ctr.ctr_data_inicio,
--         ctr.ctr_data_termino,
--         pla.pla_nome,
--         cid.cid_nome
--         from usu_usuario usu
-- inner join cli_cliente cli on (cli.usu_id = usu.usu_id)
-- inner join ctr_controle ctr on (usu.usu_id = ctr.ctr_id)
-- inner join pla_plano pla on (pla.pla_id = ctr.pla_id)
-- inner join tpu_tipo_usuario tpu on (tpu.tpu_id = usu.tpu_id)
-- inner join cid_cidade cid on (cid.cid_id = usu.cid_id)
-- 
-- 
-- where usu.usu_id;
-- 
-- 
-- SELECT cli_cliente.cli_nome,
-- cli_cliente.cli_cpf,
-- usu_usuario.usu_login,
-- usu_usuario.usu_senha
-- FROM cli_cliente
-- INNER JOIN usu_usuario
-- ON cli_cliente.cli_id=usu_usuario.usu_id;
-- 
 
       
/*SELECT cli_cliente.cli_nome,
cli_cliente.cli_cpf,
usu_usuario.usu_login,
usu_usuario.usu_senha
FROM cli_cliente
INNER JOIN usu_usuario
ON cli_cliente.cli_id=usu_usuario.usu_id;
*/

#Select * from Emp_Empresa inner join Tipo_Empresa using (Tip_Id) inner Join Produto using (Id_P)

/*
select 	cliente.cli_nome, cliente.cli_email, cliente.cli_cpf, cliente.cli_idade, 
		cidade.cid_nome, tipoU.tpu_descricao, usuario.usu_login
		from cli_cliente cliente, tpu_tipo_usuario tipoU, cid_cidade cidade, usu_usuario usuario
        where cliente.cli_id = cliente.usu_id = usuario.tpu_id = usuario.usu_id;
*/

INSERT INTO tpu_tipo_usuario(tpu_descricao)VALUES
('Publico'),
('Administrador');

insert into pla_plano(pla_nome,pla_qtd_dias)values
('Premium','90'),
('Comum','60'),
('Master','120');

#select * from tpu_tipo_usuario;
#select * from pla_plano;

INSERT INTO cid_cidade(cid_nome) VALUES
('Guaratinguetá'),
('Lorena'),
('Pinda'),
('Cruzeiro');

ALTER TABLE ctr_controle MODIFY ctr_data_termino DATETIME, MODIFY ctr_data_inicio DATETIME;

Select usu_id from usu_usuario where usu_login = 1;

select cli_nome, cli_email, cli_cpf, cli_idade, cid_nome, tpu_descricao, usu_login, 
		from cli_cliente inner join usu_usuario using (usu_id) 
						 inner join tpu_tipo_usuario using (tpu_id)
                         inner join cid_cidade using (cid_id);
			
select pla_nome, pla_qtd_dias from pla_plano;            

select cli_id, cli_nome, cli_email, cli_cpf, cli_idade, cid_nome, tpu_descricao, usu_login 
from cli_cliente 
inner join usu_usuario using (usu_id) 
inner join tpu_tipo_usuario using (tpu_id) 
inner join cid_cidade using (cid_id) order by cli_id;

/*
select cli_id, cli_nome, cli_email,  cli_cpf,  cli_idade, cid_nome, tpu_descricao, pla_nome,  pla_qtd_dias, usu_login, usu_senha 
from cli_cliente 
inner join usu_usuario using (usu_id) 
inner join tpu_tipo_usuario using (tpu_id) 
inner join cid_cidade using (cid_id)
inner join ctr_controle using (ctr_id)
inner join pla_plano using (pla_id) order by cli_id;
*/

select cli.cli_id, cli.cli_nome, cli.cli_email,  cli.cli_cpf,  cli.cli_idade, cid.cid_nome, tpu.tpu_descricao, pla.pla_nome,  pla.pla_qtd_dias, usu.usu_login, usu.usu_senha 
from usu_usuario usu 
inner join cli_cliente cli on(cli.usu_id = usu.usu_id) 
inner join ctr_controle ctr on(usu.usu_id = ctr.ctr_id)
inner join pla_plano pla on(pla.pla_id = ctr.pla_id) 
inner join tpu_tipo_usuario tpu on(tpu.tpu_id = usu.tpu_id) 
inner join cid_cidade cid on(cid.cid_id = usu.cid_id);










