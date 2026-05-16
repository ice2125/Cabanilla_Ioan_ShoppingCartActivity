### Cabanilla_Ioan_ShoppingCartActivity_Part_3
## Student: Cabanilla, Ioan Rayne J.
## Course: BSIT 1-2

# About the Project

This is a Shopping Cart System written in C# that runs in the console and demonstrates classes, objects, and arrays. It includes input validation, stock tracking, and a discount system.

The store contains four products. Each product has a stock count that decreases when added to the cart. Adding the same product again updates the quantity instead of creating a duplicate cart row. The cart supports up to 10 different products. On checkout the program prints a receipt with items, prices, totals, and applies a 10% discount for totals >= ₱5,000. The app validates numeric input and prevents buying out-of-stock items.

Part 2 Features

- Cart management menu: view cart, remove item (restores stock), update quantity (updates subtotal), clear cart (restores stock), or checkout.
- Product search (case-insensitive) and category filtering (Clothing / Accessories).
- Payment validation and change calculation at checkout.
- Receipt details: padded receipt number, date/time, per-item totals, grand total, discount, final total, payment, and change.
- Low-stock alerts for items with 5 or fewer units remaining.
- Order history recorded during the program session.

Recent refactor notes (updated to match current code):

- Encapsulation: public fields were replaced with C# properties (`get` / `private set`) for safer access.
- Helper classes (`Product`, `Cartitem`, `Order`) are now nested private classes inside `Program` because they are only used there.
- Stock and quantity are updated through methods instead of direct field writes:
	- `Product.ReduceStock(int qty)` and `Product.AddStock(int qty)` manage stock changes and guard against negative values.
	- `Cartitem.Addmore(int add)` and `Cartitem.SetQuantity(int newQty)` update quantity and recalculate `Subtotal`.
- The code no longer writes directly to fields like `RemainingStock` or `Quantity`; it uses the above methods to keep state consistent.

Files of interest:

- `Program.cs` — main program and the refactored classes.
- `ai_prompts_get_set.txt` — examples of AI prompts to ask for help converting fields to `get`/`set` properties.

FAQ / developer questions:

- How do I loop through the array to display all products? Use a `for` or `foreach` loop over the `storeMenu` array and call `DisplayProduct()` on each element.
- How do I calculate the subtotal in the constructor? Multiply `product.Price * quantity` and assign to the `Subtotal` property inside the `Cartitem` constructor.
- How do I update the quantity and recalculate the subtotal? Use `Cartitem.SetQuantity(newQty)` or `Cartitem.Addmore(add)` which update `Quantity` and recompute `Subtotal`.
