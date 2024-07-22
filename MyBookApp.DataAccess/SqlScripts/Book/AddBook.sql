INSERT INTO "Books" ("Name","Description","AuthorId","PublisherId")
VALUES (@Name,@Description,@AuthorId,@PublisherId)
RETURNING "Id";