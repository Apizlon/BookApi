SELECT "Id","Name","Description","AuthorId","PublisherId" FROM "Books"
WHERE "AuthorId" = @AuthorId;