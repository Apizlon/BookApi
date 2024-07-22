INSERT INTO "Publishers" ("Name")
VALUES (@Name)
RETURNING "Id";