UPDATE "Authors"
SET
    "FullName" = CASE WHEN @FullName IS NULL THEN "FullName" ELSE @FullName END,
    "DateOfBirth" = CASE WHEN @DateOfBirth IS NULL THEN "DateOfBirth" ELSE @DateOfBirth END
WHERE "Id" = @Id;