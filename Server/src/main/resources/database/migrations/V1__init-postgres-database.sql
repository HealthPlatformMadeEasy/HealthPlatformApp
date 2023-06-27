DROP TABLE IF EXISTS appuser;


CREATE TABLE IF NOT EXISTS appuser
(
    id       INT         NOT NULL,
    username VARCHAR(50) NOT NULL,
    email    VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    primary key (id)
);