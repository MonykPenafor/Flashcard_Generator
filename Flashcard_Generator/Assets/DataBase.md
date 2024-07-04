### Criação das Tabelas

```sql
CREATE TABLE USERS (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(20) NOT NULL UNIQUE,
    email NVARCHAR(80) NOT NULL UNIQUE,
    password_hash NVARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE FLASHCARDS (
    id_flashcard INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    source_language NVARCHAR(30) NOT NULL,
    target_language NVARCHAR(30) NOT NULL,
    category NVARCHAR(30),
    word_source NVARCHAR(50) NOT NULL,
    word_target NVARCHAR(50) NOT NULL,
    example_sentence_source NVARCHAR(350) NOT NULL,
    example_sentence_target NVARCHAR(350) NOT NULL,
    pronunciation NVARCHAR(350),
    tips NVARCHAR(300),
    proficiency NVARCHAR(3),
    is_public BIT DEFAULT 1,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_user) REFERENCES USERS(id_user) ON DELETE CASCADE
);
```

### Criação dos `TRIGGERs`

#### `TRIGGER` para a Tabela `USERS`

```sql
CREATE TRIGGER trg_UpdateUserUpdatedAt
ON USERS
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON; --evitar contagem de resultados
    UPDATE USERS
    SET updated_at = CURRENT_TIMESTAMP
    FROM inserted
    WHERE USERS.id_user = inserted.id_user;
END;
GO
```

#### `TRIGGER` para a Tabela `FLASHCARDS`

```sql
CREATE TRIGGER trg_UpdateFlashcardUpdatedAt
ON FLASHCARDS
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE FLASHCARDS
    SET updated_at = CURRENT_TIMESTAMP
    FROM inserted
    WHERE FLASHCARDS.id_flashcard = inserted.id_flashcard;
END;
GO
```
