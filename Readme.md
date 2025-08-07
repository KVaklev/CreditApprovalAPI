# 💳 Credit Approval API

This project is a backend API for processing and reviewing credit requests, built using ASP.NET Core (.NET 9). It allows users to submit a credit application, and administrators to review (approve or reject) it based on specified business rules.

---

## 🧩 Features

- Submit a credit request with:
  - Full name
  - Email
  - Monthly income
  - Credit amount
  - Credit type (MORTGAGE, AUTO, PERSONAL)
- Auto-generated unique request ID (e.g., `CRE-20250801-0001`)
- Validation rules enforced (see below)
- Review (Approve/Reject) requests
- List all requests with optional filtering
- Status management: `PENDING_REVIEW`, `APPROVED`, `REJECTED`
- In-memory data persistence
- Swagger UI with XML comments enabled

---

## 🧪 Validation Rules

- Credit Amount:
  - Max **500,000** for MORTGAGE
  - Max **50,000** for AUTO
  - Max **10,000** for PERSONAL
- Credit amount and monthly income **must be greater than 0**
- Email must be **valid**
- **Approval denied** if credit amount exceeds **20× monthly income**
- Once reviewed, a request **cannot be modified**

---

## 🛠 Technologies Used

- .NET 9 (ASP.NET Core Web API)
- Entity Framework Core (In-Memory)
- AutoMapper
- MediatR (CQRS pattern)
- FluentValidation
- Swagger / Swashbuckle (with XML comments)
- Visual Studio 2022+

---

## 🚀 Setup Instructions (Visual Studio only)

Follow these steps to run the project locally **without using terminal/CLI**:

### ✅ 1. Clone the Repository

1. Go to your browser and open the GitHub repository:  
   👉 [https://github.com/KVaklev/CreditApprovalAPI]

2. Click on the green **`<> Code`** button and **copy the HTTPS link**.

3. In **Visual Studio**:
   - Go to **File > Clone Repository**
   - Paste the GitHub link into the field.
   - Choose a folder to store the project.
   - Click **Clone**.

---

### ✅ 2. Open the Project

Once cloned:

- Double-click the solution file: `CreditApprovalAPI.sln`  
- Wait for packages to restore (Visual Studio handles it automatically)

---

### ✅ 3. Build and Run

- Set the startup project to `CreditApprovalAPI` (right-click → Set as Startup Project)
- Press **F5** or click the green **Run** button
- Your browser will launch Swagger UI:  
  👉 `http://localhost:5041/swagger`

---

### ✅ 4. Test Endpoints in Swagger

Use Swagger UI to:

- `POST /api/creditrequests` – Submit a credit request  
- `POST /api/creditrequests/{id}/review` – Review (approve/reject) a request  
- `GET /api/creditrequests` – List all requests

Each controller action has **XML documentation** visible in Swagger.

---

## 🤝 Assumptions

- No authentication/authorization required
- In-memory DB used for simplicity and easy testing
- Frontend is not part of this task

---

## ✅ Optional Enhancements (future work)

- Introduce layered project structure (e.g. Persistence, Application/Service, and Presentation layers) to improve scalability, separation of concerns, and maintainability as the API grows in size
- Add authentication (e.g. JWT)
- Move to SQL Server/PostgreSQL for persistence
- Add unit/integration tests
- Add Docker support

---

## 📄 Folder Structure (Simplified)
CreditApprovalAPI/
│
├── Controllers/
├── Data/
├── DTOs/
├── Models/
├── Repositories/
├── Services/
├── Validators/
├── Mapping/
├── Program.cs
└── README.md ← This file
