package com.api.server.foodb;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "cite_this_textbooks")
public class CiteThisTextbook {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @Column(name = "isbn")
    private String isbn;

    @NotNull
    @Lob
    @Column(name = "title", nullable = false)
    private String title;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

    @Size(max = 255)
    @Column(name = "ref_id")
    private String refId;

    @Size(max = 255)
    @NotNull
    @Column(name = "authors", nullable = false)
    private String authors;

    @Size(max = 255)
    @Column(name = "edition")
    private String edition;

    @Size(max = 255)
    @NotNull
    @Column(name = "publisher", nullable = false)
    private String publisher;

    @Size(max = 255)
    @NotNull
    @Column(name = "year", nullable = false)
    private String year;

    @Size(max = 255)
    @Column(name = "book_format")
    private String bookFormat;

    @Size(max = 255)
    @Column(name = "ean")
    private String ean;

}