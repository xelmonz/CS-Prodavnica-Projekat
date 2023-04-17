CREATE DATABASE Prodavnica;
GO

USE Prodavnica;
GO

CREATE TABLE kategorija (
  id INT PRIMARY KEY IDENTITY(1,1),
  kategorija NVARCHAR(50) NOT NULL
);

CREATE TABLE korisnici (
  id INT PRIMARY KEY IDENTITY(1,1),
  ime NVARCHAR(50) NOT NULL,
  prezime NVARCHAR(50) NOT NULL,
  email NVARCHAR(100) NOT NULL,
  lozinka NVARCHAR(100) NOT NULL,
  vrsta_korisnika VARCHAR(50) NOT NULL
);

CREATE TABLE proizvod (
  id INT PRIMARY KEY IDENTITY(1,1),
  naziv NVARCHAR(100) NOT NULL,
  kategorija NVARCHAR(50) NOT NULL,
  cena DECIMAL(10,2) NOT NULL,
  kolicina INT NOT NULL
);

CREATE TABLE racun (
  id INT PRIMARY KEY,
  id_korisnika INT NOT NULL,
  uk_cena DECIMAL(10,2) NOT NULL,
  vreme TIME NOT NULL,
  datum DATE NOT NULL,
  FOREIGN KEY (id_korisnika) REFERENCES korisnici(id)
);

CREATE TABLE statistika (
  id INT PRIMARY KEY IDENTITY(1,1),
  naziv NVARCHAR(100) NOT NULL,
  kolicina INT NOT NULL,
  datum DATE NOT NULL
);

CREATE TABLE stavka_racuna (
  id_racun INT NOT NULL,
  naziv NVARCHAR(100) NOT NULL,
  kolicina INT NOT NULL,
  cena DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (id_racun, naziv),
  FOREIGN KEY (id_racun) REFERENCES racun(id)
);

--Data___________________________________________________________________________
INSERT INTO kategorija values(N'Piće');
INSERT INTO kategorija values('Desert');
INSERT INTO kategorija values('Meso');

INSERT INTO proizvod values('Sladoled','Desert','50','100');
INSERT INTO proizvod values('Oreo','Desert','200','100');
INSERT INTO proizvod values('Jaffa','Desert','120','100');

INSERT INTO proizvod values('Piletina','Meso','800','20');

INSERT INTO proizvod values('Limunada',N'Piće','120','200');
INSERT INTO proizvod values('Pepsi',N'Piće','170','200');
INSERT INTO proizvod values('Sprite',N'Piće','160','200');

INSERT INTO korisnici values('Nemanja','Brankovic','admin','admin','admin');
INSERT INTO korisnici values('Nikola','Nikolic','kupac','kupac','kupac');

INSERT INTO statistika values('Oreo',10,'2023-03-10');
INSERT INTO statistika values('Oreo',5,'2023-04-02');
INSERT INTO statistika values('Oreo',6,'2023-01-10');
INSERT INTO statistika values('Sprite',8,'2023-01-01');
INSERT INTO statistika values('Sprite',8,'2023-02-01');
INSERT INTO statistika values('Limunada',10,'2023-03-11');
INSERT INTO statistika values('Limunada',10,'2023-02-11');
INSERT INTO statistika values('Limunada',10,'2023-04-11');