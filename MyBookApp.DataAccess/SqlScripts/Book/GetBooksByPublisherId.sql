SELECT "Id","Name","Description","AuthorId","PublisherId" FROM "Books"
WHERE "PublisherId" = @PublisherId;