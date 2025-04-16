# 🚗 Vehicle Rental Management System

An ASP.NET Core MVC application that allows car rental companies to manage their fleet of vehicles, reservations, customers, billing, and reporting. This project is designed for educational or internal business use and supports a clean admin interface with session-based authentication.

---

## 📋 Features

- ✅ **Login and Registration**
- ✅ **Vehicle Management** (Add/Edit/Delete Vehicles)
- ✅ **Customer Management**
- ✅ **Reservation System** (with status tracking)
- ✅ **Billing Module** (auto-linked to reservations)
- ✅ **Report View** (basic reporting logic per reservation/customer/vehicle)
- ✅ **Sidebar UI** with Bootstrap 5

---

## 💻 Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (LocalDB or SQL Express)
- Bootstrap 5 (CDN)
- Session-based authentication

---

## 🧰 Requirements

- .NET 6 or 7 SDK
- SQL Server (LocalDB or Express)
- Visual Studio or VS Code

---

## 🚀 Getting Started

### 1. Clone the Repo

bash
git clone https://github.com/YOUR_USERNAME/VehicleRentalSystem.git
cd VehicleRentalSystem

2. Configure the Database

Update the connection string in appsettings.json:

"ConnectionStrings": {
"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=VehicleRentalDB;Trusted_Connection=True;"
}

3. Run Migrations and Seed Database

Open the terminal or Package Manager Console and run:
dotnet ef database update

-- 📦 Insert Vehicles
INSERT INTO Vehicles (Make, Model, Year, LicensePlate, Status) VALUES
('Toyota', 'Camry', 2020, 'ABC123', 'Available'),
('Honda', 'Civic', 2019, 'XYZ456', 'Available'),
('Ford', 'Focus', 2018, 'LMN789', 'Unavailable'),
('Chevrolet', 'Malibu', 2021, 'JKL321', 'Available'),
('Nissan', 'Altima', 2020, 'DEF654', 'Available'),
('Hyundai', 'Elantra', 2022, 'GHI987', 'Available'),
('BMW', '3 Series', 2021, 'BMW001', 'Unavailable'),
('Tesla', 'Model 3', 2023, 'TES123', 'Available'),
('Kia', 'Soul', 2020, 'KIA999', 'Available'),
('Mazda', '6', 2019, 'MAZ456', 'Available');

-- 👥 Insert Customers
INSERT INTO Customers (Name, Email, Phone, Address) VALUES
('Alice Johnson', 'alice@example.com', '555-1234', '123 Main St'),
('Bob Smith', 'bob@example.com', '555-5678', '456 Elm St'),
('Carol White', 'carol@example.com', '555-9012', '789 Oak St'),
('David Brown', 'david@example.com', '555-3456', '321 Pine St'),
('Eve Green', 'eve@example.com', '555-7890', '654 Maple St'),
('Frank Miller', 'frank@example.com', '555-4321', '987 Cedar St'),
('Grace Lee', 'grace@example.com', '555-8765', '222 Walnut St'),
('Henry Adams', 'henry@example.com', '555-6543', '888 Ash St'),
('Isla Davis', 'isla@example.com', '555-2109', '444 Birch St'),
('Jack Black', 'jack@example.com', '555-3450', '777 Spruce St');

-- 📅 Insert Reservations
INSERT INTO Reservations (VehicleId, CustomerId, StartDate, EndDate, Status) VALUES
(1, 1, GETDATE()-10, GETDATE()-7, 'Completed'),
(2, 2, GETDATE()-5, GETDATE()-3, 'Completed'),
(3, 3, GETDATE()-2, GETDATE()+2, 'Confirmed'),
(4, 4, GETDATE(), GETDATE()+3, 'Pending'),
(5, 5, GETDATE()-1, GETDATE()+1, 'Confirmed'),
(6, 6, GETDATE()-3, GETDATE()+2, 'Confirmed'),
(7, 7, GETDATE()+1, GETDATE()+5, 'Pending'),
(8, 8, GETDATE()-6, GETDATE()-2, 'Completed'),
(9, 9, GETDATE()-4, GETDATE(), 'Completed'),
(10, 10, GETDATE(), GETDATE()+4, 'Pending');

-- 💵 Insert Billings (linked to ReservationId 1–10)
INSERT INTO Billings (ReservationId, Subtotal, Tax, TotalAmount, IssuedDate) VALUES
(1, 300, 45, 345, GETDATE()),
(2, 400, 60, 460, GETDATE()),
(3, 350, 52.5, 402.5, GETDATE()),
(4, 280, 42, 322, GETDATE()),
(5, 500, 75, 575, GETDATE()),
(6, 420, 63, 483, GETDATE()),
(7, 310, 46.5, 356.5, GETDATE()),
(8, 275, 41.25, 316.25, GETDATE()),
(9, 380, 57, 437, GETDATE()),
(10, 360, 54, 414, GETDATE());

```

```
