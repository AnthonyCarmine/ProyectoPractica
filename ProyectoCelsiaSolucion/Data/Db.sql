-- Tabla para Administrators
CREATE TABLE Administrators (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(100) NOT NULL
);

INSERT INTO Administrators (Email, Password) VALUES ('robinson.cortes@riwi.io', 'password');

-- Tabla para Customers
CREATE TABLE Customers (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(100) NOT NULL,
    Document INT NOT NULL,
    Address VARCHAR(200) NOT NULL,
    Phone VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL
);

-- Tabla para Invoices
CREATE TABLE Invoices (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Number VARCHAR(100) UNIQUE NOT NULL,
    Date DATE NOT NULL,
    AmountInvoice INT NOT NULL,
    AmountPaid INT NOT NULL,
    CustomerId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);

-- Tabla para Platforms
CREATE TABLE Platforms (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL
);

-- Tabla para Transactions
CREATE TABLE Transactions (
    Id VARCHAR(50) PRIMARY KEY,
    DateHour DATETIME NOT NULL,
    Amount INT NOT NULL,
    Status ENUM('Pendiente', 'Fallida', 'Completada') NOT NULL,
    Type VARCHAR(50) NOT NULL,
    InvoiceId INT NOT NULL,
    PlatformId INT NOT NULL,
    FOREIGN KEY (InvoiceId) REFERENCES Invoices(Id),
    FOREIGN KEY (PlatformId) REFERENCES Platforms(Id)
);

-- Tablas necesarias para ASP.NET Core Identity

-- Tabla para almacenar usuarios
CREATE TABLE AspNetUsers (
    Id VARCHAR(255) NOT NULL PRIMARY KEY,
    UserName VARCHAR(256) NULL,
    NormalizedUserName VARCHAR(256) NULL,
    Email VARCHAR(256) NULL,
    NormalizedEmail VARCHAR(256) NULL,
    EmailConfirmed BIT NOT NULL,
    PasswordHash VARCHAR(256) NULL,
    SecurityStamp VARCHAR(256) NULL,
    ConcurrencyStamp VARCHAR(256) NULL,
    PhoneNumber VARCHAR(256) NULL,
    PhoneNumberConfirmed BIT NOT NULL,
    TwoFactorEnabled BIT NOT NULL,
    LockoutEnd DATETIME NULL,
    LockoutEnabled BIT NOT NULL,
    AccessFailedCount INT NOT NULL
);

-- Tabla para almacenar roles
CREATE TABLE AspNetRoles (
    Id VARCHAR(255) NOT NULL PRIMARY KEY,
    Name VARCHAR(256) NULL,
    NormalizedName VARCHAR(256) NULL,
    ConcurrencyStamp VARCHAR(256) NULL
);

-- Tabla para almacenar las relaciones entre usuarios y roles
CREATE TABLE AspNetUserRoles (
    UserId VARCHAR(255) NOT NULL,
    RoleId VARCHAR(255) NOT NULL,
    PRIMARY KEY (UserId, RoleId),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE,
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE
);

-- Tabla para almacenar los claims de los usuarios
CREATE TABLE AspNetUserClaims (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId VARCHAR(255) NOT NULL,
    ClaimType VARCHAR(256) NULL,
    ClaimValue VARCHAR(256) NULL,
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

-- Tabla para almacenar los claims de los roles
CREATE TABLE AspNetRoleClaims (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    RoleId VARCHAR(255) NOT NULL,
    ClaimType VARCHAR(256) NULL,
    ClaimValue VARCHAR(256) NULL,
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE
);

-- Tabla para almacenar los logins externos de los usuarios
CREATE TABLE AspNetUserLogins (
    LoginProvider VARCHAR(256) NOT NULL,
    ProviderKey VARCHAR(256) NOT NULL,
    ProviderDisplayName VARCHAR(256) NULL,
    UserId VARCHAR(255) NOT NULL,
    PRIMARY KEY (LoginProvider, ProviderKey),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

-- Tabla para almacenar los tokens de los usuarios
CREATE TABLE AspNetUserTokens (
    UserId VARCHAR(255) NOT NULL,
    LoginProvider VARCHAR(256) NOT NULL,
    Name VARCHAR(256) NOT NULL,
    Value VARCHAR(256) NULL,
    PRIMARY KEY (UserId, LoginProvider, Name),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);


DROP TABLE AspNetUserTokens;
DROP TABLE AspNetUserLogins;
DROP TABLE AspNetRoleClaims;
DROP TABLE AspNetUserClaims;
DROP TABLE AspNetUserRoles;
DROP TABLE AspNetRoles;
DROP TABLE AspNetUsers;
DROP TABLE Customers;
DROP TABLE Invoices;
DROP TABLE Platforms;
DROP TABLE Transactions;