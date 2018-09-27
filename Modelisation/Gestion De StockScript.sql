--drop database gestion_stock
create database gestion_stock
go

use gestion_stock
go
--------------------------------------------
--------creation de la Table personne-----
--------------------------------------------
create table personne
(
	id int,
	nom varchar(30),
	postnom varchar(40),
	prenom varchar(30),
	sexe varchar(1),
	etatcivil varchar(15),
	dateNaissance smalldatetime,
	numeroTel varchar(15),
	adresse varchar(200)
	constraint pk_personne primary key(id)
)
go

--------------------------------------------
--------creation de la Table photo-----
--------------------------------------------
create table photo
(
	id int,
	id_personne int,
	photo varbinary,
	constraint pk_photo primary key(id),
	constraint fk_photo_id_personne foreign key(id_personne) references personne(id)
	on delete cascade
)
go

--------------------------------------------
--------creation de la Table service-----
--------------------------------------------
create table service 
(
	id int primary key,
	designation varchar(50)
	--on delete cascade
)
go
--------------------------------------------
--------creation de la Table agent---------
--------------------------------------------
create table agent
(
	id integer primary key ,
	id_personne int,
	id_service int,--id_service,matricule,fonction,
	matricule varchar(20),
	fonction varchar(50),
	deleted bit default 0,
	constraint fk_agent_id_personne foreign key(id_personne) references personne(id),
	constraint fk_agent_id_service foreign key(id_service) references service(id)
	--on delete cascade
)
go

--------------------------------------------
--------creation de la Table categorieUtilisateur-----
--------------------------------------------
create table categorieUtilisateur
(
	id integer,
	designation varchar(50) not null,
	groupe varchar(20) not null,
	constraint pk_categorieUtilisateur primary key(id),
	constraint uk_designation unique(designation)
)
go

--------------------------------------------
--------creation de la Table utilisateur-----
--------------------------------------------
create table utilisateur
(
	id integer,
	id_agent integer not null,
	id_categorieUtilisateur integer not null,
	activation bit default 0,
	nomuser varchar(50) not null,
	motpass varchar(50) not null,
	constraint pk_utilisateur primary key(id),
	constraint fk_utilisateur_agent foreign key(id_agent) references agent(id),
	constraint fk_utilisateur_categorieUtilisateur foreign key(id_categorieUtilisateur) references categorieUtilisateur(id),
	constraint uk_utilisateur_user unique(nomuser)
)
go

--------------------------------------------
--------creation de la Table fournisseur-----
--------------------------------------------
create table fournisseur 
(
	id int primary key,
	id_personne int,
	nrc varchar(100),
	deleted bit default 0,
	constraint fk_Fournisseur_id_personne foreign key(id_personne) references personne(id)
	--on delete cascade
)
go

--------------------------------------------
--------creation de la Table categorie_Article--------
--------------------------------------------
create table categorie_Article
(
	id integer   primary key,
	designation varchar(100)
)
go

--------------------------------------------
--------creation de la Table article--------
--------------------------------------------
create table article
(
	id int primary key,
	pu float,
	designation varchar(100),
	id_categorie int,
	constraint fk_Article_id_categorie foreign key(id_categorie) references categorie_Article(id)
)
go

--------------------------------------------
--------creation de la Table livraison------
--------------------------------------------
create table livraison
(
	id integer,
	id_article integer not null,
	id_fournisseur integer not null,
	qte_e integer not null,
	date_livraison smalldatetime not null,
	constraint pk_livraison primary key(id),
	constraint fk_livraison_article foreign key(id_article) references Article(id),
	constraint fk_livraison_fournisseur foreign key(id_fournisseur) references fournisseur(id)
)
go

--------------------------------------------
--------creation de la Table paiementFournisseur-----
--------------------------------------------
create table paiementFournisseur
(
	id integer primary key,
	id_agent integer not null,
	id_fournisseur integer not null,
	date_paiement date,
	montant float,
	constraint fk_id_fournisseur_Paiement foreign key(id_fournisseur) references fournisseur(id),
	constraint fk_id_agent_paiement foreign key(id_agent) references agent(id)
)
go
--------------------------------------------
--------creation de la Table client---------
--------------------------------------------
create table client
(
	id integer primary key ,
	id_personne int,
	deleted bit default 0,
	constraint fk_Client_id_personne foreign key(id_personne) references personne(id)
	--on delete cascade
)
go

--------------------------------------------
--------creation de la Table paiement-------
--------------------------------------------
create table paiement
(
	id integer,
	id_client integer not null,
	id_article integer not null,
	date_paiement datetime not null,
	montant float,
	qte_vendue integer not null,
	constraint pk_paiement primary key(id),
	constraint fk_paiement_client foreign key(id_client) references client(id),
	constraint fk_Paiement_article foreign key(id_article) references Article(id)
)
go

--------------------------------------------
--------creation de la Table commande-------
--------------------------------------------
create table commande
(
	id integer primary key,
	id_agent integer not null,
	id_fournisseur integer not null,
	date_commande smalldatetime,
	constraint fk_founisseur_commande foreign key(id_fournisseur) references fournisseur(id),
	constraint fk_agent_commande foreign key(id_agent) references agent(id)
)
go

--------------------------------------------
--------creation de la Table stock-------
--------------------------------------------
create table stock
(
	id integer primary key,
	id_article integer not null,
	valeur integer not null,
	constraint fk_stock_article foreign key(id_article) references article(id)
)
go
