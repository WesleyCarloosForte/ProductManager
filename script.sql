CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE categories (
    "Id" uuid NOT NULL,
    name character varying(100) NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "DeletedAt" timestamp with time zone,
    "Status" integer NOT NULL,
    CONSTRAINT "PK_categories" PRIMARY KEY ("Id")
);

CREATE TABLE products (
    "Id" uuid NOT NULL,
    name character varying(100) NOT NULL,
    price numeric NOT NULL,
    "InStock" boolean NOT NULL,
    "CategoryId" uuid NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "DeletedAt" timestamp with time zone,
    "Status" integer NOT NULL,
    CONSTRAINT "PK_products" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_products_categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES categories ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_products_CategoryId" ON products ("CategoryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250616220719_InitialCreate', '9.0.6');

CREATE TABLE users (
    "Id" uuid NOT NULL,
    login character varying(100) NOT NULL,
    password_hash character varying(100) NOT NULL,
    permissions text NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "DeletedAt" timestamp with time zone,
    "Status" integer NOT NULL,
    CONSTRAINT "PK_users" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250620000437_CreateUsersTable', '9.0.6');

COMMIT;

