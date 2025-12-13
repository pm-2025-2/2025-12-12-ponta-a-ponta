-- SQL -> DQL, DML, DDL, DCL, ...
-- DDL
-- Data
-- Definition
-- Language
-- constraint!
DROP DATABASE IF EXISTS tadsflix;

CREATE DATABASE tadsflix;

\c tadsflix;

-- CREATE TYPE GENERO AS ENUM ('DRAMA', 'COMEDIA', 'ACAO');

DROP TABLE IF EXISTS filmes;

CREATE TABLE IF NOT EXISTS filmes (
    titulo    TEXT    DEFAULT 'Sem título',
    genero    TEXT    DEFAULT NULL,
    hype      INTEGER DEFAULT 3,
    assistido BOOLEAN DEFAULT FALSE
);

INSERT INTO filmes (genero, hype, titulo, assistido)
VALUES ('ACAO', 4, 'Velozes e Furiosos 9', FALSE);