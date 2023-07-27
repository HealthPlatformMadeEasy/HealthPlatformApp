CREATE TABLE Users
(
    id         CHAR(36)     NOT NULL,
    name       VARCHAR(255) NOT NULL,
    password   VARCHAR(255) NOT NULL,
    email      VARCHAR(255) NOT NULL,
    created_at DATETIME     NOT NULL,
    PRIMARY KEY (Id),
    constraint email_pk
        unique (password),
    constraint name_pk
        unique (name),
    constraint email_pk
        unique (email)
);

CREATE TABLE UserContents
(
    id               CHAR(36) NOT NULL,
    source_type      VARCHAR(255),
    orig_unit        VARCHAR(255),
    orig_source_name VARCHAR(255),
    orig_content     DECIMAL(15, 9),
    standard_content DECIMAL(15, 9),
    created_at       DATETIME NOT NULL,
    user_id          CHAR(36) NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (user_id) REFERENCES Users (id),
    create           index usercontents_orig_source_name_index
        on usercontents (orig_source_name desc)
);
