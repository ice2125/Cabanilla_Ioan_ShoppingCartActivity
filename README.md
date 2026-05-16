Shopping Cart (Console)
Author: Ioan Cabanilla

What it does:
- Simple console shopping cart program written in C#.
- Lets you add products to a cart, update quantities, remove items, clear cart, and checkout.
- Tracks product stock and applies a 10% discount for totals >= ₱5,000.

How to run:
1. Open a terminal in the project folder that contains `ShoppingCart.csproj`.
2. Run:

   dotnet run

Quick notes about the code (current):
- `Program.cs` contains the main program. Helper types (`Product`, `Cartitem`, `Order`) are nested and private.
- Fields were replaced with properties (`get` / `private set`) for safer access.
- Use `Product.ReduceStock(int)` / `Product.AddStock(int)` to change stock.
- Use `Cartitem.Addmore(int)` or `Cartitem.SetQuantity(int)` to change quantities and recompute subtotals.

Files you may want:
- `Program.cs` — main program
- `ai_prompts_get_set.txt` — example AI prompts for converting fields to properties

That's all — simple and ready to read.