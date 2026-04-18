# Property History 🏠

A C# console application demonstrating the **Generic Repository Pattern** for managing real estate property data. The project uses abstraction and generics to provide a clean, reusable data access layer for any entity type.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Design Patterns Used](#design-patterns-used)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Classes & Interfaces](#classes--interfaces)

---

## Overview

Property History is a console-based application built with C# that simulates a property management system. It uses a **generic repository pattern** to perform CRUD operations on entities like `Category` and `Property`, making the data layer reusable and extensible without code duplication.

---

## Architecture

```
Program
  └── TestClass (Consumer)
        └── IRepoCompany (Factory Interface)
              └── RepoCompany (Factory Implementation)
                    └── IRepo<T> (Repository Interface)
                          └── GenericRepo<T> (Generic Repository)
                                ├── Category : BaseEntity
                                └── Property : BaseEntity
```

---

## Project Structure

```
Property_History/
│
├── BaseEntity.cs          # Abstract base class with shared 'id' property
├── Category.cs            # Category entity (Residential, Commercial, etc.)
├── Property.cs            # Property entity with full land/price details
│
├── IRepo.cs               # Generic repository interface (CRUD)
├── GenericRepo.cs         # In-memory implementation of IRepo<T>
│
├── IRepoCompany.cs        # Factory interface for creating repositories
├── RepoCompany.cs         # Concrete factory that instantiates GenericRepo<T>
│
├── TestClass.cs           # Demonstrates all CRUD operations
└── Program.cs             # Entry point
```

---

## Design Patterns Used

| Pattern | Implementation |
|---|---|
| **Repository Pattern** | `IRepo<T>` / `GenericRepo<T>` abstracts data access |
| **Factory Pattern** | `IRepoCompany` / `RepoCompany` creates typed repositories |
| **Dependency Injection** | `TestClass` receives `IRepoCompany` via constructor |
| **Generic Constraint** | `where T : BaseEntity` enforces entity contract |

---

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later recommended)
- Visual Studio / VS Code / Rider

### Run the Project

```bash
# Clone the repository
git clone https://github.com/your-username/property-history.git
cd property-history

# Build
dotnet build

# Run
dotnet run
```

---

## Usage

The `TestClass.Run()` method demonstrates full CRUD operations for both `Category` and `Property` entities:

```csharp
// Create a typed repository via factory
IRepo<Category> repoC = company.CreateRepo<Category>();

// Add entities
repoC.AddRange(new Category[] {
    new Category { id = 1, Name = "Residential" },
    new Category { id = 2, Name = "Commercial" },
});

// Read all
repoC.GetAll().ForEach(c => Console.WriteLine($"{c.id}, {c.Name}"));

// Read by ID
var category = repoC.Get(1);

// Update
category.Name = "Updated Name";
repoC.Update(category);

// Delete
repoC.Delete(2);
```

### Sample Output

```
==================Get All==================
1,Residential
2,Commercial
3,Industrial
4,Agricultural

============================Get==================
ID : 3,Name : Industrial

============================Update==================
ID : 1,Name : Residential
ID : 2,Name : Commercial
ID : 3,Name : Commercial
ID : 4,Name : Agricultural

============================delete==================
ID : 1,Name : Residential
...
```

---

## Classes & Interfaces

### `BaseEntity`
Abstract base class inherited by all entities.
```csharp
public abstract class BaseEntity {
    public int id { get; set; }
}
```

### `IRepo<T>`
Generic CRUD interface constrained to `BaseEntity`.
```csharp
public interface IRepo<T> where T : BaseEntity {
    List<T> GetAll();
    T Get(int id);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(int id);
}
```

### `GenericRepo<T>`
In-memory implementation using `IList<T>`.

### `IRepoCompany` / `RepoCompany`
Factory for creating `IRepo<T>` instances for any entity type.

### `Category`
| Property | Type | Description |
|---|---|---|
| `id` | `int` | Unique identifier (from BaseEntity) |
| `Name` | `string` | Category name (e.g., Residential) |

### `Property`
| Property | Type | Description |
|---|---|---|
| `id` | `int` | Unique identifier (from BaseEntity) |
| `PropertyName` | `string` | Name of the property |
| `Location` | `string` | Address/location |
| `TypeOfLand` | `string` | Land type (e.g., Nal, Store) |
| `Size` | `string` | Size of the property |
| `Price` | `double` | Price in BDT |
| `CategoryId` | `int` | Foreign key to Category |

---

