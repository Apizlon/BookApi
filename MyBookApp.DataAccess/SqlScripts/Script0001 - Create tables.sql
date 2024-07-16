CREATE TABLE IF NOT EXISTS public."Authors"
(
    "Id"          integer               NOT NULL GENERATED ALWAYS AS IDENTITY,
    "FullName"    character varying(50) NOT NULL,
    "DateOfBirth" character varying(50) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS public."Publishers"
(
    "Id"   integer               NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name" character varying(50) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS public."Books"
(
    "Id"          integer                NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Name"        character varying(50)  NOT NULL,
    "Description" character varying(200) NOT NULL,
    "AuthorId"    integer                NOT NULL references "Authors" ("Id") ON DELETE CASCADE ON UPDATE CASCADE,
    "PublisherId" integer                NOT NULL references "Publishers" ("Id") ON DELETE CASCADE ON UPDATE CASCADE,
    PRIMARY KEY ("Id")
);