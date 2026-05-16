**Changes:**
- Replaced public fields with properties (example: `public int RemainingStock` -> `public int RemainingStock { get; private set; }`).
- Added `ReduceStock(int)` and `AddStock(int)` to manage stock safely.
- Added property accessors for `Id`, `Name`, `Price`, `Category`.

**Code examples:**

**Before:**
```csharp
public class Product
{
    # Program.cs — Compact Commit Summary

    Overview: the following concise entries describe code-only changes made to `Program.cs`.

    Day 1 — Convert fields to properties
    - Replaced public fields with properties (example: `RemainingStock` -> `public int RemainingStock { get; private set; }`).
    - Added `ReduceStock(int)` and `AddStock(int)` to manage stock.

    Before (Product):
    ```csharp
    public int RemainingStock; // field
    ```

    After (Product):
    ```csharp
    public int RemainingStock { get; private set; }
    public void ReduceStock(int quantity) { RemainingStock -= quantity; if (RemainingStock < 0) RemainingStock = 0; }
    public void AddStock(int quantity) { if (quantity <= 0) return; RemainingStock += quantity; }
    ```

    Day 2 — Nest classes inside `Program`
    - `Product`, `Cartitem`, and `Order` were moved to private nested classes inside `Program`.

    Before:
    ```csharp
    class Product { ... }
    class Cartitem { ... }
    class Order { ... }
    ```

    After:
    ```csharp
    class Program {
        private class Product { ... }
        private class Cartitem { ... }
        private class Order { ... }
    }
    ```

    Day 3 — Encapsulate updates; remove direct writes
    - Replaced direct writes to `RemainingStock`/`Quantity` with method calls.
    - Added `Cartitem.Addmore(int)` and `Cartitem.SetQuantity(int)` to keep `Subtotal` consistent.

    Before:
    ```csharp
    cart[removeIndex-1].Product.RemainingStock += cart[removeIndex-1].Quantity;
    cart[updateIndex-1].Quantity = newQty;
    cart[updateIndex-1].Subtotal = cart[updateIndex-1].Product.Price * newQty;
    ```

    After:
    ```csharp
    cart[removeIndex-1].Product.AddStock(cart[removeIndex-1].Quantity);
    cart[updateIndex-1].SetQuantity(newQty);
    ```

    Cartitem additions:
    ```csharp
    public void Addmore(int add) { if (add <= 0) return; Quantity += add; Subtotal = Product.Price * Quantity; }
    public void SetQuantity(int newQty) { if (newQty < 0) return; Quantity = newQty; Subtotal = Product.Price * newQty; }
    ```
