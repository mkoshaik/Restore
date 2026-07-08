# E-Commerce Project Context

This project is a full-stack e-commerce application consisting of a .NET 9 Web API backend and a React 19 frontend.

## Project Overview

- **Backend:** ASP.NET Core Web API built with .NET 9.
  - **Data Access:** Entity Framework Core with SQLite.
  - **Architecture:** Controller-based API with custom middleware for exception handling.
  - **Key Entities:** `Product`, `Basket`, `BasketItem`.
  - **Authentication:** (Pending implementation based on current files).
- **Frontend:** React 19 SPA built with TypeScript and Vite.
  - **UI Framework:** Material UI (MUI).
  - **State Management:** Redux Toolkit with RTK Query for API calls.
  - **Routing:** React Router 7.
  - **Features:** Catalog (Product List, Details), Basket (In progress), Dark Mode toggle.

## Building and Running

### Backend (API)
The backend is located in the `/API` directory.
- **Run:** `dotnet run` or `dotnet watch` for development.
- **Base URL:** `https://localhost:5001/api`
- **Database:** SQLite (`store.db`). Initialized by `DbInitializer.cs`.

### Frontend (Client)
The frontend is located in the `/client` directory.
- **Install Dependencies:** `npm install`
- **Run Dev Server:** `npm run dev` (Runs on `https://localhost:3000` by default).
- **Build:** `npm run build`
- **Lint:** `npm run lint`

## Development Conventions

### Backend
- **Controllers:** Inherit from `BaseApiController`.
- **Entities:** Located in `API/Entities`.
- **Migrations:** Managed via EF Core migrations in `API/Data/Migrations`.
- **Error Handling:** Centralized in `ExceptionMiddleware.cs`.

### Frontend
- **Functional Components:** Use React functional components with TypeScript.
- **Styling:** Use Material UI components and the `sx` prop for custom styles.
- **API Calls:** Use RTK Query (e.g., `catalogApi.ts`) for data fetching.
- **Custom Hooks:** Use `useAppSelector` and `useAppDispatch` for Redux state.
- **Naming:** Follow standard React and TypeScript naming conventions (PascalCase for components, camelCase for variables/functions).

## Key Files
- `API/Program.cs`: Backend entry point and service configuration.
- `API/Data/StoreContext.cs`: EF Core database context.
- `client/src/app/layout/App.tsx`: Main React component and theme provider.
- `client/src/app/api/baseApi.ts`: Base RTK Query configuration with global error handling.
- `client/src/app/store/store.ts`: Redux store configuration.
