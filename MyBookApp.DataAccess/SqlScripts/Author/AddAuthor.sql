INSERT INTO public."Authors" ("FullName","DateOfBirth")
VALUES (@FullName,@DateOfBirth)
RETURNING "Id";