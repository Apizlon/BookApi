UPDATE "Publishers"
SET "Name" = CASE WHEN @Name IS NULL THEN "Name" ELSE @Name END
WHERE "Id" = @Id;