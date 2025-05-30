-- Crear la base de datos Supermercado
CREATE DATABASE Supermercado;
GO

-- Usar la base de datos
USE Supermercado;
GO


-- Tabla de Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    ProveedorID INT
);

-- Tabla de Proveedores
CREATE TABLE Proveedores (
    ProveedorID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Contacto VARCHAR(100),
    Direccion TEXT
);

-- Relación entre Productos y Proveedores
ALTER TABLE Productos ADD CONSTRAINT FK_Productos_Proveedores 
FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID);

-- Tabla de Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Direccion TEXT,
    Telefono VARCHAR(20)
);

-- Tabla de Compras
CREATE TABLE Compras (
    CompraID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    ProveedorID INT,
    Total DECIMAL(10,2),
    FOREIGN KEY (ProveedorID) REFERENCES Proveedores(ProveedorID)
);

-- Tabla de Ventas
CREATE TABLE Ventas (
    VentaID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    ClienteID INT,
    Total DECIMAL(10,2),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

-- Tablas intermedias para productos en compras y ventas
CREATE TABLE DetalleCompra (
    CompraID INT,
    ProductoID INT,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (CompraID, ProductoID),
    FOREIGN KEY (CompraID) REFERENCES Compras(CompraID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

CREATE TABLE DetalleVenta (
    VentaID INT,
    ProductoID INT,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (VentaID, ProductoID),
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);
