# Shopping Cart Code - Mistakes vs Fixes

## Issue 1: Incorrect Class Nesting ❌→✅

### ❌ **MISTAKE (Original Code)**
```csharp
class Product
{
    // ... Product class code ...
    
    public void ReduceStock(int quantity)
    {
        RemainingStock = RemainingStock - quantity;
    }
    
    // WRONG: Cartitem class is NESTED inside Product class
    class Cartitem
    {
        public Product Product;
        public int Quantity;
        public double Subtotal;
        // ...
    }
    
    // WRONG: Program class is NESTED inside Product class
    class Program
    {
        static void Main(string[] args)
        {
            // ...
        }
    }
}
```

### ✅ **FIX**
```csharp
class Product
{
    // ... Product class code ...
    public void ReduceStock(int quantity)
    {
        RemainingStock = RemainingStock - quantity;
    }
} // Product class ends here

// NOW: Cartitem is a separate TOP-LEVEL class
class Cartitem
{
    public Product Product;
    public int Quantity;
    public double Subtotal;
    // ...
}

// NOW: Program is a separate TOP-LEVEL class
class Program
{
    static void Main(string[] args)
    {
        // ...
    }
}
```

**Why it matters:** Classes should not be nested inside other classes unless intentionally designed as inner classes. This causes compilation errors and makes code structure confusing.

---

## Issue 2: Duplicate Variable Declaration ❌→✅

### ❌ **MISTAKE (Original Code)**
```csharp
// First declaration
bool enoughStock = selectedProduct.HasEnoughStock(quantity);
if (enoughStock == false)
{
    Console.WriteLine("Error: Not enough stock" + selectedProduct.RemainingStock + "available");
    continue;
}

// Later in code - DUPLICATE DECLARATION in same scope
int foundInCart = -1;
// ...
if (foundInCart != -1)
{
    int newTotalQuantity = cart[foundInCart].Quantity + quantity;
    bool enoughStock = selectedProduct.HasEnoughStock(newTotalQuantity); // ❌ DUPLICATE!
    if (enoughStock == false)
    {
        // ...
    }
}
```

### ✅ **FIX**
```csharp
// First declaration - renamed for clarity
bool enoughStock = selectedProduct.HasEnoughStock(quantity);
if (enoughStock == false)
{
    Console.WriteLine("Error: Not enough stock" + selectedProduct.RemainingStock + "available");
    continue;
}

// Later in code
int foundInCart = -1;
// ...
if (foundInCart != -1)
{
    int newTotalQuantity = cart[foundInCart].Quantity + quantity;
    bool hasEnoughStock = selectedProduct.HasEnoughStock(newTotalQuantity); // ✅ Different name
    if (hasEnoughStock == false)
    {
        // ...
    }
}
```

**Why it matters:** Declaring the same variable twice in the same scope causes a compilation error. Use different names or different scopes.

---

## Issue 3: Malformed Error Message ❌→✅

### ❌ **MISTAKE (Original Code)**
```csharp
if (hasEnoughStock == false)
{
    System.Console.WriteLine("Error: you already have a cart" + quantity + cart[foundInCart].Quantity + " in your cart. Only " + "in cart");
    System.Console.WriteLine("Maximum you can have: " + selectedProduct.RemainingStock);
    continue;
}
```
**Problem:** Message is incomplete and confusing - "Only " + "in cart" doesn't make sense.

### ✅ **FIX**
```csharp
if (hasEnoughStock == false)
{
    System.Console.WriteLine("Error: You already have " + cart[foundInCart].Quantity + " in your cart. Adding " + quantity + " more would exceed stock.");
    System.Console.WriteLine("Maximum you can have: " + selectedProduct.RemainingStock);
    continue;
}
```

**Why it matters:** Error messages should be clear and informative to help users understand what went wrong.

---

## Issue 4: InvalidOperationException with Console.ReadKey() ❌→✅

### ❌ **MISTAKE (Original Code)**
```csharp
Console.WriteLine("Press any key to exit...");
Console.ReadKey(); // ❌ CRASHES when console input is redirected/unavailable
```

**Exception:** 
```
System.InvalidOperationException: Cannot read keys when either application does not have a 
console or when console input has been redirected. Try Console.Read.
```

### ✅ **FIX**
```csharp
Console.WriteLine("Press any key to exit...");
try
{
    Console.ReadKey();
}
catch (InvalidOperationException)
{
    Console.WriteLine("Press Enter to exit...");
    Console.ReadLine();
}
```

**Why it matters:** When running in certain environments (debuggers, redirected input), `Console.ReadKey()` fails. The try-catch allows graceful fallback to `Console.ReadLine()`.

---

## Issue 5: Fixed-Size Cart Array Limit ❌→✅

### ❌ **MISTAKE (Original Code)**
```csharp
// Fixed array with 10-item hard limit
Cartitem[] cart = new Cartitem[10];
int cartCount = 0;

// ... later in code ...
if (cartCount == 10)
{
    Console.WriteLine("Error: Cart is full. Cannot add more items.");
    continue;
}
Cartitem newItem = new Cartitem(selectedProduct, quantity);
cart[cartCount] = newItem; // Array access
cartCount = cartCount + 1;

// Loop through cart
for (int i = 0; i < cartCount; i++)
{
    // ...
}
```

**Problem:** Fixed array requires manual size management and wastes memory if not fully used. Requires tracking `cartCount` separately.

### ✅ **FIX**
```csharp
// Add Collections.Generic namespace at top
using System.Collections.Generic;

// Dynamic list with 10-item limit enforced by logic
List<Cartitem> cart = new List<Cartitem>();

// ... later in code ...
if (cart.Count == 10)
{
    Console.WriteLine("Error: Cart is full. Cannot add more items.");
    continue;
}
Cartitem newItem = new Cartitem(selectedProduct, quantity);
cart.Add(newItem); // List method

// Loop through cart
for (int i = 0; i < cart.Count; i++)
{
    // ...
}
```

**Why it matters:** 
- **List<T>** is more flexible and cleaner than manual array management
- No need for separate `cartCount` variable
- `cart.Add()` is more intuitive than `cart[index] = item`
- Can easily change the limit without resizing code

---

## Summary of All Fixes

| Issue | Type | Severity | Fix |
|-------|------|----------|-----|
| Class Nesting | Structural | 🔴 Critical | Move classes to top-level namespace |
| Duplicate Variable | Compilation | 🔴 Critical | Rename duplicate variable |
| Malformed Message | Logic | 🟡 Warning | Fix string concatenation |
| Console.ReadKey() Exception | Runtime | 🔴 Critical | Wrap in try-catch with fallback |
| Fixed Array Limit | Design | 🟢 Improvement | Convert to List<T> |

---

## How to Run the Fixed Code

1. Open `shoppingcart.cs`
2. Build: `dotnet build`
3. Run: `dotnet run`

The program now works without errors and handles edge cases properly! ✅
