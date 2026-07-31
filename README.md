# 🏥 Hospital ERP System — Backend

> **Team Engineering Project** | A Hospital Management ERP backend built by a first-time distributed team to practice production-grade backend architecture, Git-based collaboration, and code review — structured the way this work would be organized inside a company, while remaining transparent about what is finished and what isn't.

⚠️ **This repository contains only the backend components of the project.**

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-Latest-239120?logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-2019+-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![EF Core](https://img.shields.io/badge/EF_Core-8.0-512BD4?logo=dotnet)](https://docs.microsoft.com/en-us/ef/core/)
[![Dapper](https://img.shields.io/badge/Dapper-2.1-A91D22)](https://github.com/DapperLib/Dapper)
[![Status](https://img.shields.io/badge/Status-Active_Development-yellow)](https://github.com/Dev0-0Team/Hospital-ERP-Backend)

**Contributors:**
[![Compiler-A](https://img.shields.io/badge/GitHub-Compiler--A-181717?logo=github)](https://github.com/Compiler-A)
[![Abdel-RahmanOwais](https://img.shields.io/badge/GitHub-Abdel--RahmanOwais-181717?logo=github)](https://github.com/Abdel-RahmanOwais)
[![ahmedayman25606](https://img.shields.io/badge/GitHub-ahmedayman25606-181717?logo=github)](https://github.com/ahmedayman25606)

---

## Table of Contents

- [Problem It Solves](#-problem-it-solves)
- [Tech Stack](#-tech-stack)
- [Architecture Overview](#-architecture-overview)
- [CQRS Approach & Data Access Strategy](#-cqrs-approach--data-access-strategy)
- [Identity & Access Control](#-identity--access-control)
- [Domain Coverage](#-domain-coverage)
- [Team & Roles](#-team--roles)
- [Known Issues & Technical Debt](#-known-issues--technical-debt)
- [Roadmap](#-roadmap)
- [API Overview](#-api-overview)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Engineering Notes](#-engineering-notes)
- [License](#-license)

---

## 📌 Problem It Solves

Hospitals need a centralized system to manage patients, appointments, staff, lab and radiology work, medication, room and bed assignments, and billing — while keeping data consistent, auditable, and secure. This project provides a scalable, API-first backend covering that full operational surface (roughly 35 related tables across clinical and administrative domains), designed to plug into any frontend — web, mobile, or an internal admin dashboard.

Beyond the domain itself, the project exists to give a first-time distributed team hands-on practice with the parts of software engineering that don't show up in a solo tutorial: architectural boundaries that hold up under multiple contributors, Git workflow discipline, code review, and honest tracking of technical debt. The result is a codebase that sits **closer to production quality than a tutorial project, but is deliberately not represented as 100% production-ready** — see [Known Issues & Technical Debt](#-known-issues--technical-debt) for exactly where that line is drawn.

---

## 🛠 Tech Stack

| Layer | Technology |
|---|---|
| API Framework | ASP.NET Core Web API |
| Language | C# (.NET 8) |
| Write-side ORM | Entity Framework Core 8 (Fluent API configurations, soft-delete query filters) |
| Read-side Data Access | Dapper + Stored Procedures (`CommandType.StoredProcedure`) |
| Database | Microsoft SQL Server |
| Mediator / CQRS Pipeline | MediatR 14.2.0 |
| Validation | FluentValidation |
| Password Hashing | BCrypt.Net |
| Planned Authentication | JWT Bearer (`Microsoft.AspNetCore.Authentication.JwtBearer`) — package referenced, pipeline wiring in progress (see [Known Issues](#-known-issues--technical-debt)) |
| API Documentation | Swagger / OpenAPI |
| Architecture | Clean Architecture, Vertical Slice Architecture, CQRS |
| Collaboration | GitHub (monorepo, Issues-based task assignment, protected branches) |

---

## 🏗 Architecture Overview

The solution follows **Clean Architecture combined with a Vertical Slice approach**: each feature (e.g. *"Add Lab Test"*, *"Book Appointment"*) is organized as a self-contained slice with its own Request, Response, Validator, and Handler, rather than being scattered across generic technical layers.

```
Hospital-ERP-Backend/
│
├── Hopital-ERP-Backend.API/            ← Presentation Layer (Controllers, Middleware, Swagger, DI)
├── Hospital-ERP-Backend.Application/   ← Vertical-slice features (CQRS Commands/Queries), DTOs, FluentValidation
├── Hospital-ERP-Backend.Domain/        ← Entities, Enums, base repository interfaces
├── Hospital-ERP-Backend.Infrastructure/← EF Core / Dapper, Repositories, DI wiring
└── database/                           ← Stored procedures & schema scripts, versioned outside the solution
```

> The API project directory is named `Hopital-ERP-Backend.API` while the remaining projects use `Hospital`. This naming inconsistency predates the team's shared conventions and is tracked under [Known Issues](#-known-issues--technical-debt).

**Key patterns used:**

- **CQRS + MediatR** — separates write (Commands) from read (Queries) operations
- **Repository Pattern** — `IBaseCommandRepository<T>` (EF Core-backed writes) and `IBaseQueryRepository<T>` (Dapper-backed reads), abstracting data access per module
- **FluentValidation** — every Command/Query is validated before it reaches business logic
- **Soft-delete & audit metadata** — every entity carries `CreatedAt`, `UpdatedAt`, `DeletedAt`, and `IsDeleted` via a shared `BaseEntity`, enforced on both the write side (`HasQueryFilter`) and the read side (`WHERE is_deleted = 0` in every stored procedure)

### Request Flow

```
HTTP Request
    │
    ▼
[API] Controller → builds Request DTO → dispatches via ISender (MediatR)
    │
    ▼
[Application] Feature Handler (IRequestHandler)
    │   ├── FluentValidation on the request
    │   ├── Business rule checks against related entities
    │   └── calls IBaseCommandRepository<T> (writes) or IBaseQueryRepository<T> (reads)
    │
    ▼
[Infrastructure]
    ├── Write → EF Core → SQL Server (change tracking, soft-delete flags)
    └── Read  → Dapper → Stored Procedure → SQL Server
    │
    ▼
[Application] maps entity → Response DTO
    │
    ▼
[API] wraps in ApiResponse<T> → JSON response
```

---

## 🔄 CQRS Approach & Data Access Strategy

**Read/write separation.** Writes go through EF Core, where change tracking and relationship management are handled naturally by the ORM. Reads go through Dapper against stored procedures, since several read paths — particularly Medical Records and Billing — require joins and shaped projections that a generic ORM query doesn't express well at this schema size.

**Mediator adoption.** The project initially used a manual CQRS split (Command/Query separation without a mediator library), by design, so the team would understand what a mediator pattern automates before adopting one. MediatR has since been reintroduced across the codebase, with every feature implemented as an `IRequestHandler<TRequest, TResponse>`. This is an active, deliberate architectural decision, documented rather than incidental — see [Engineering Notes](#-engineering-notes).

---

## 🔐 Identity & Access Control

The identity and RBAC foundation is the most complete and heavily reviewed module in the system:

```
Persons ── 1:1 ──> Users
   │
   ├── 1:1 ──> Doctors
   ├── 1:1 ──> Nurses
   ├── 1:1 ──> Patients
   └── 1:1 ──> AdministrativeStaff

Users ── M:N ──> Roles ── M:N ──> Permissions
   (via UserRoles)         (via RolePermissions)
```

`Person` is the shared identity root — a given person may be a `Doctor`, `Nurse`, `Patient`, and/or `AdministrativeStaff`, and optionally hold a `User` account, all linked back to a single `Person` record. Roles and Permissions are modeled as first-class many-to-many relationships (`UserRole`, `RolePermission`), each carrying its own audit and soft-delete metadata, rather than being treated as simple lookup joins.

> Access control is currently implemented as custom entities (`User`, `Role`, `Permission`) with BCrypt password hashing — **not** ASP.NET Core Identity — and the JWT pipeline that would enforce it at the API boundary is not yet wired in. See [Known Issues](#-known-issues--technical-debt).

---

## 📦 Domain Coverage

| Area | Entities |
|---|---|
| **Identity & Access** | Person, User, Role, Permission, UserRole, RolePermission |
| **Clinical Staff & Structure** | Doctor, Nurse, AdministrativeStaff, Department, Specialization, DoctorSchedule |
| **Patients** | Patient, Allergy, ChronicDisease, EmergencyContact, SurgeriesHistory |
| **Scheduling** | Appointment, AppointmentQueue, QueuePriority |
| **Clinical Records** | MedicalRecord, Prescription, PrescriptionItem, Medication, MedicationInventory, DrugInteraction |
| **Diagnostics** | LabOrder, LabTest, LabTestResult, RadiologyOrder, RadiologyImage, RadiologyReport |
| **Facilities** | Room, RoomType, Bed, RoomAssignment |
| **Emergency** | EmergencyCase |
| **Billing & Finance** | Invoice, InvoiceItem, Payment, PaymentMethod |
| **System** | Notification |

Module depth varies: Identity & Access Control is functionally complete, while several clinical modules currently have full CRUD and validation in place with business logic still being layered in.

---

## 👥 Team & Roles

| Role | Member | Focus | Links |
|---|---|---|---|
| **Lead Backend Architect** | Ali Mousa ([@Compiler-A](https://github.com/Compiler-A)) | Owns the Identity & RBAC foundation (Persons, Users, Roles, Permissions, UserRoles, RolePermissions) and the final integration layer (Medical Records, Billing, Invoices, Payments, Notifications); responsible for overall architecture, cross-cutting concerns (JWT, CORS, soft-delete enforcement), and code review across the team | [GitHub](https://github.com/Compiler-A) |
| **Backend Developer** | Abdel-Rahman Owais ([@Abdel-RahmanOwais](https://github.com/Abdel-RahmanOwais)) | Feature-module development on the ASP.NET Core Web API — implementing Commands/Queries, EF Core and Dapper data access, and FluentValidation rules for assigned domain slices | [GitHub](https://github.com/Abdel-RahmanOwais) · [LinkedIn](https://linkedin.com/in/eowais) |
| **Backend Developer** | Ahmed Ayman ([@ahmedayman25606](https://github.com/ahmedayman25606)) | Feature-module development on the ASP.NET Core Web API, working in parallel on assigned domain slices via the team's GitHub Issues workflow | [GitHub](https://github.com/ahmedayman25606) |

**Ownership model.** Cross-cutting concerns — authentication, CORS, soft-delete enforcement, connection resilience — are owned at the architecture level rather than distributed across feature work, so that gaps in those areas are tracked as scope of ownership rather than individual contributor error.

**Standards.** A shared `NamingConventions&GitStandards.md` document was authored early in the project, before individual task assignments were made, covering:

- Naming conventions (PascalCase / camelCase / `_camelCase` / `I`-prefixed interfaces / `UPPER_SNAKE_CASE`) mapped to specific code contexts
- File and class naming per architectural layer (Controllers, Middleware, Extensions, Repositories, EF Core Configurations, Stored Procedures)
- Branch naming (`feature/*`, `fix/*`, `refactor/*`) and commit message format (`feat(module): description`, `fix(module): description`)
- Pull request rules: PRs always target `develop`, one feature per PR, mandatory peer review, a soft 400-line size cap
- Protected branches: `main` and `develop` both require a pull request and review before merge

**Dependency injection** follows a consistent layered extension pattern throughout: per-feature `*ServiceExtensions.cs` files aggregate into `ApplicationServiceExtensions` / `InfrastructureServiceExtensions`, which aggregate into `AppServiceExtensions` at the API layer, resolving to a single registration call in `Program.cs`.

---

## ⚠️ Known Issues & Technical Debt

The following were identified during an internal code review and are tracked here rather than omitted, consistent with treating this as a realistic engineering environment rather than an idealized portfolio artifact.

### Critical

- **JWT authentication is not wired into the pipeline.** `Microsoft.AspNetCore.Authentication.JwtBearer` is referenced across all layers, but `Program.cs` does not call `AddAuthentication()` / `UseAuthentication()`. Endpoints are currently unauthenticated, and no `/api/auth/login` endpoint exists yet.
- **No CORS policy is configured.**
- **Inconsistent handling of empty result sets.** Fifteen or more `GetAll` handlers throw `KeyNotFoundException` when a page returns zero results, where an empty list is the correct response. This is a systemic pattern requiring a coordinated fix.
- **Domain layer has infrastructure dependencies.** All four projects — including Domain — reference identical packages (EF Core, Dapper, BCrypt, JWT), which violates the dependency direction Clean Architecture is meant to enforce.

### Medium

- A `FluentValidation.ValidationException` thrown in `UpdateRolePermissionService` is not handled by `GlobalExceptionMiddleware`'s exception map and falls through to a generic 500 response instead of 400.
- `DeleteLabTestService` throws `ArgumentException` for a not-found condition, where the rest of the codebase consistently uses `KeyNotFoundException`.
- `DateTime.Now` vs. `DateTime.UtcNow` usage is inconsistent across modules, though adherence improves measurably in more recently written code.
- The namespace split between `Hopital_ERP_Backend` (API project) and `Hospital_ERP_Backend` (all other projects) has only been partially corrected, and only in newer controllers.
- No automated test project exists yet.

### Open Architectural Decisions

- Finalizing the scope of MediatR adoption, including whether to introduce a `ValidationBehavior` pipeline to remove the roughly 80 duplicated "validate → throw" blocks currently present across handlers.
- `IBaseQueryRepository<T>` currently exposes only `GetAllAsync(page)` and `GetAsync(id)`, which is insufficient for the join-heavy reads required by upcoming Medical Records and Billing work; this interface needs to be extended before those modules progress further.

### Resolved

- Missing dependency injection registration for RolePermissions
- Missing `CommandType.StoredProcedure` on Dapper calls
- Missing `HasQueryFilter` for soft-delete across several entity configurations

---

## 🗺 Roadmap

- [ ] Wire JWT authentication into the request pipeline (including an `/api/auth/login` endpoint) and configure CORS
- [ ] Add role-based authorization for staff vs. admin
- [ ] Systematically correct the empty-result-throws-exception pattern across all affected services
- [ ] Remove infrastructure package references from the Domain layer
- [ ] Complete the `Hopital` → `Hospital` namespace unification
- [ ] Standardize on `DateTime.UtcNow` across all modules
- [ ] Add unit & integration tests
- [ ] Add a CI pipeline (GitHub Actions)
- [ ] Add Docker Compose for local development
- [ ] Finalize the MediatR adoption decision and extend `IBaseQueryRepository<T>` ahead of Medical Records, Billing, and Payments development
- [ ] Complete business logic for the remaining scaffolded modules

---

## 📖 API Overview

Every resource follows the same REST shape (`GET` list, `GET /{id}`, `POST`, `PUT`, `DELETE`), wrapped in a consistent `ApiResponse<T>` envelope. A representative sample:

| Endpoint | Method | Description |
|---|---|---|
| `/api/Patients` | GET / POST | List / create patients |
| `/api/Appointments` | GET / POST | List / book appointments |
| `/api/Doctors` | GET / POST | List / register doctors |
| `/api/LabTests` | GET / POST | List / add lab tests |
| `/api/LabOrders` | GET / POST | List / place lab orders |
| `/api/RadiologyOrders` | GET / POST | List / place radiology orders |
| `/api/Prescriptions` | GET / POST | List / issue prescriptions |
| `/api/Invoices` | GET / POST | List / create invoices |
| `/api/Rooms`, `/api/Beds`, `/api/RoomAssignments` | GET / POST | Facility and admission management |
| `/api/Roles`, `/api/Permissions`, `/api/Users` | GET / POST | Identity & access administration |

This is a sample, not the full surface — the API currently exposes roughly 40 resource controllers spanning every entity in [Domain Coverage](#-domain-coverage). The complete, always-current list is available via Swagger once the API is running (see [Getting Started](#-getting-started)).

> `POST`, `PUT`, and `DELETE` on any resource are currently reachable without a token — see [Known Issues](#-known-issues--technical-debt).

*Add a Swagger screenshot here once available:* `![Swagger UI](docs/swagger-screenshot.png)`

---

## ⚙️ Getting Started

**Prerequisites**

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or Docker)
- Visual Studio 2022+ or JetBrains Rider (optional)

**Setup**

```bash
# 1. Clone the repository
git clone https://github.com/Dev0-0Team/Hospital-ERP-Backend.git
cd Hospital-ERP-Backend

# 2. Restore dependencies
dotnet restore

# 3. Configure the connection string in Hopital-ERP-Backend.API/appsettings.json
# {
#   "AllowedHosts": "*",
#   "MySettings": {
#     "ConnectionString": "Server=localhost\\SQLEXPRESS;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True;",
#     "RowsPerPage": 20
#   }
# }

# 4. Set up the database
# Run the schema and stored procedure scripts from the top-level `database/` folder
# against SQL Server. The read-side stored procedures are maintained independently
# from the EF Core model, by design — see CQRS Approach & Data Access Strategy above.

# 5. Run the API
dotnet run --project Hopital-ERP-Backend.API
```

The API will be available at `https://localhost:XXXX/swagger` with full Swagger documentation.

> **Note:** Authentication is not yet wired into the request pipeline. All endpoints are currently reachable without a token — do not expose this API on an untrusted network until JWT wiring is complete.

---

## 📁 Project Structure

```
Hospital-ERP-Backend/
├── Hopital-ERP-Backend.API/
│   ├── Controllers/            ← One per entity, inheriting BaseController
│   ├── Extensions/             ← DI wiring split by concern (Configuration, Mediator, Services)
│   ├── Filters/                ← Swagger operation filters
│   ├── Middleware/             ← GlobalExceptionMiddleware
│   ├── ApiResponse.cs
│   └── Program.cs
│
├── Hospital-ERP-Backend.Application/
│   └── Features/
│       └── <Entity>/
│           ├── Commands/<Action>/   ← Request, Response, Validator, Handler
│           ├── Queries/<Action>/    ← Request, Response, Validator, Handler
│           └── Extensions/          ← Feature-level DI registration
│
├── Hospital-ERP-Backend.Domain/
│   ├── Entities/                ← Plain POCOs, BaseEntity for audit/soft-delete fields
│   ├── Interfaces/Base/         ← IBaseCommandRepository<T>, IBaseQueryRepository<T>
│   └── Enums/
│
├── Hospital-ERP-Backend.Infrastructure/
│   ├── Data/
│   │   ├── HospitalDbContext.cs
│   │   ├── Configurations/       ← Fluent API IEntityTypeConfiguration<T> per entity
│   │   └── Extension/
│   └── Repositories/
│       ├── Commands/              ← EF Core-backed, one per entity
│       └── Queries/                ← Dapper-backed, one per entity, calling stored procedures
│
└── database/                     ← Stored procedures & schema scripts, versioned outside the solution
```

---

## 🧠 Engineering Notes

**Query repository granularity.** A single generic `IBaseQueryRepository<T>` was evaluated and rejected once it became clear it could not express the join-heavy reads required by modules such as Medical Records and Billing. Per-module Query Repositories were adopted instead, trading additional files for correct per-module query shape.

**Ownership of cross-cutting concerns.** Authentication, CORS, and soft-delete enforcement are owned at the architecture level rather than distributed across feature developers, since gaps in these areas reflect the scope of architectural ownership rather than individual contributor performance. This distinction kept code review constructive during the team's first collaborative project.

**Transparent technical debt tracking.** Known issues are documented in this README rather than resolved silently or omitted, in keeping with the project's goal of simulating a realistic engineering environment rather than presenting an idealized final state.

---

## 📄 License

This project was developed for educational and portfolio purposes as part of a team engineering exercise. No formal open-source license has been applied. Please contact the maintainers before reuse or redistribution.
