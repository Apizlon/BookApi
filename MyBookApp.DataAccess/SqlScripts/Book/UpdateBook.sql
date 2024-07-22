UPDATE "Books"
SET
    "Name" = CASE WHEN @Name IS NULL THEN "Name" ELSE @Name END,
    "Description" = CASE WHEN @Description IS NULL THEN "Description" ELSE @Description END,
    "AuthorId" = CASE WHEN @AuthorId = 0 THEN "AuthorId" ELSE @AuthorId END,
    "PublisherId" = CASE WHEN @PublisherId = 0 THEN "PublisherId" ELSE @PublisherId END
WHERE "Id" = @Id;