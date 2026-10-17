# Taller #5 — Listas Ligadas (Doubly Linked Lists)

[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Tests](https://img.shields.io/badge/xUnit-Passed%20(9%2F9)-success?logo=xunit)](file:///C:/Users/santi/.gemini/antigravity/scratch/Estructura_de_datos_ITM_Taller-5/Backend.Tests)
[![Deploy](https://img.shields.io/badge/Deploy-Vercel%20%7C%20GitHub%20Pages-black?logo=vercel)](https://github.com/santy8151/Estructura_de_datos_ITM_Taller-5)

**Student:** Santiago Suarez  
**Institution:** Instituto Tecnológico Metropolitano (ITM)  
**Course:** Estructura de Datos (Data Structures)  
**Assignment:** Taller #5 — Listas Ligadas (Valor: 20%)  

---

## 🌐 Live Demos (Generic Domains)

- **Vercel Web App:** Deployed automatically using `vercel.json` and static hosting.
- **GitHub Pages:** [`https://santy8151.github.io/Estructura_de_datos_ITM_Taller-5/`](https://santy8151.github.io/Estructura_de_datos_ITM_Taller-5/)

---

## 🏗️ Architecture

```
DoublyLinkedListApp (solution)
├── Backend/                  ← Class library (pure data structure, no UI)
│   ├── DoubleNode.cs         (Generic node with Value, Next, and Previous pointers)
│   └── DoublyLinkedList.cs   (Sorted insertion, traversal, descending sort, mode, chart)
├── Frontend.Console/         ← Interactive CLI menu with exact 1-9 & 0 options
├── Frontend.Web/             ← Interactive Blazor WebAssembly visualizer (Vercel)
├── Frontend.Windows/         ← Windows Forms desktop application
└── Backend.Tests/            ← xUnit automated test suite (100% coverage)
```

---

## 📋 Features Implemented (Assignment Specification)

| # | Menu Option | Description |
|---|---|---|
| **1** | **Adicionar** | Inserts elements in ascending sorted order automatically (`Blanco, Azul, Amarillo, Verde, Negro` → `Amarillo, Azul, Blanco, Negro, Verde`). Allows duplicates. |
| **2** | **Mostrar hacia adelante** | Traverses from `Head` to `Tail` following `Next` links. |
| **3** | **Mostrar hacia atrás** | Traverses from `Tail` to `Head` following `Previous` links. |
| **4** | **Ordenar descendentemente** | Reverses the internal pointer links in-place so forward traversal outputs descending order (`Verde, Negro, Blanco, Azul, Amarillo`). |
| **5** | **Mostrar la(s) moda(s)** | Computes unimodal and multimodal distributions. Example 1: `1, 2, 3, 3, 2, 5, 6, 6, 6, 3, 6` → mode is `6`. Example 2: `1, 2, 3, 3, 2, 5, 6, 6, 6, 3` → modes are `3, 6`. |
| **6** | **Mostrar gráfico** | Displays an asterisk frequency chart matching the PDF layout (`1 *`, `2 **`, `3 ***`, etc.). |
| **7** | **Existe** | Returns whether the element is present in the list (`El elemento existe` / `No existe`). |
| **8** | **Eliminar una ocurrencia** | Removes only the first matching node from the list and reconnects pointers. |
| **9** | **Eliminar todas las ocurrencias** | Removes all occurrences of the specified value. |
| **0** | **Salir** | Exits the program cleanly. |

---

## 🚀 Build & Run

**Prerequisites:** [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

```bash
# Build the entire solution from repository root
dotnet build DoublyLinkedListApp.sln

# Run all unit tests
dotnet test

# Run the interactive Console Menu
dotnet run --project Frontend.Console

# Run the Blazor WebAssembly visualizer locally
dotnet run --project Frontend.Web

# Run the Windows Forms GUI application (Windows only)
dotnet run --project Frontend.Windows
```

---

## ☁️ Vercel Deployment

The repository includes a ready-to-deploy `vercel.json` configured for Blazor WebAssembly:

```json
{
  "buildCommand": "curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 9.0 && export PATH=\"$HOME/.dotnet:$PATH\" && dotnet publish Frontend.Web/Frontend.Web.csproj -c Release -o dist",
  "outputDirectory": "dist/wwwroot",
  "framework": {
    "name": "@vercel/static",
    "version": "0.x"
  },
  "rewrites": [
    { "source": "/(.*)", "destination": "/index.html" }
  ]
}
```

To deploy via Vercel:
1. Import `santy8151/Estructura_de_datos_ITM_Taller-5` into Vercel Dashboard.
2. Vercel automatically detects `vercel.json` and builds the static WebAssembly site.
3. Access your live generic URL `https://estructura-de-datos-itm-taller-5.vercel.app`.

---

   - Show the GitHub repository with clean commits and README.
