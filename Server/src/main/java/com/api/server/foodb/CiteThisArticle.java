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
@Table(name = "cite_this_articles")
public class CiteThisArticle {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @NotNull
    @Column(name = "pubmed_id", nullable = false)
    private Integer pubmedId;

    @Lob
    @Column(name = "citation")
    private String citation;

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
    @Column(name = "doi")
    private String doi;

    @Size(max = 1000)
    @NotNull
    @Column(name = "title", nullable = false, length = 1000)
    private String title;

    @NotNull
    @Lob
    @Column(name = "authors", nullable = false)
    private String authors;

    @Size(max = 255)
    @Column(name = "source")
    private String source;

    @Size(max = 255)
    @Column(name = "journal")
    private String journal;

    @Size(max = 255)
    @Column(name = "volume")
    private String volume;

    @NotNull
    @Column(name = "year", nullable = false)
    private Integer year;

    @Size(max = 255)
    @NotNull
    @Column(name = "date", nullable = false)
    private String date;

    @Size(max = 255)
    @Column(name = "pages")
    private String pages;

    @Size(max = 255)
    @Column(name = "issue")
    private String issue;

    @Lob
    @Column(name = "abstract")
    private String abstractField;

}