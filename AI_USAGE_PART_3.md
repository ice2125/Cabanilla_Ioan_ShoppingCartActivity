## AI Usage

**Tool Used:** ChatGPT / GitHub Copilot

---

### How AI Was Used

I wrote the original Part 1 code myself, including the Product class, CartItem class, basic menu loop, add-to-cart logic, receipt printing, and input validation. For Part 2, I asked AI to help me build the additional features on top of my existing code.

AI helped with:

- Converting public fields to C# properties with `get` and `private set` accessors
- Building `ReduceStock` and `AddStock` methods with guard clauses
- Creating `SetQuantity` and updating `Addmore` to keep `Subtotal` in sync
- Nesting helper classes (`Product`, `Cartitem`, `Order`) inside `Program`
- Building the cart management menu (view, remove, update quantity, clear)
- Setting up payment validation loops and change calculation
- Generating auto-incrementing receipt numbers and DateTime formatting
- Creating the order history storage and display system
- Adding low stock alert logic after checkout
- Implementing product search and category filtering
- Fixing array manipulation for removing and shifting items

---

### AI Prompts Used

- "How do I convert public fields to properties with private setters in C#? Show me examples with constructors."
- "How do I add guard clauses to methods so stock can't go negative?"
- "How do I nest classes inside another class in C#?"
- "How do I update quantity and recalculate subtotal automatically?"
- "How do I build a cart management menu with view, remove, update, and clear options?"
- "How do I validate payment input and calculate change in C#?"
- "How do I format receipt numbers with leading zeros and DateTime as 'April 24, 2026 8:30 PM'?"
- "How do I store completed orders in an array and display order history?"
- "How do I check for duplicate items in a cart array and update quantity instead of adding a new entry?"
- "How do I filter products by category and search with partial string matching?"
- "How do I fix array manipulation when removing items from the middle and shifting elements left?"
- "How do I return stock when removing items from the cart?"
- "How do I prevent crashes when the cart is empty and the user tries to remove or update?"
- "How do I use int.TryParse() for input validation instead of Convert.ToInt32()?"
- "How do I handle Console.ReadKey exceptions when the console input is redirected?"

---

### What I Did Myself

- Wrote the original Part 1 code from scratch (Product class, CartItem class, main menu, add-to-cart, receipt, basic validation)
- Designed the overall program structure and flow
- Chose to use arrays instead of Lists per assignment requirements
- Manually converted fields to properties and verified no regressions
- Integrated AI-suggested methods into my existing codebase without breaking functionality
- Tested the program with multiple scenarios (adding items, duplicates, out of stock, discounts, cart management)
- Adjusted output formatting to match assignment requirements
- Verified all validation paths work correctly after property refactor
- Wrote the README.md and sample output documentation
- Created the Git commits and pull request
- Understood and modified AI-generated code to fit my existing codebase
