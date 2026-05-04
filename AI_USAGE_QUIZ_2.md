
## AI Usage

**Tool Used:** GitHub Copilot / ChatGPT

---

### How AI Was Used

I wrote the original Part 1 code myself, including the Product class, CartItem class, basic menu loop, add-to-cart logic, receipt printing, and input validation. For Part 2, I asked AI to help me build the additional features on top of my existing code.

AI helped with:

- Integrating Part 2 features into my existing codebase without breaking Part 1
- Building the cart management menu (view, remove, update quantity, clear)
- Setting up payment validation loops and change calculation
- Generating auto-incrementing receipt numbers and DateTime formatting
- Creating the order history storage and display system
- Adding low stock alert logic after checkout
- Implementing product search and category filtering
- Fixing array manipulation for removing and shifting items

---

### AI Prompts Used

- "The code is running because of code failure. What could be the cause and how should I fix this?"
- "Unhandled exception. System.InvalidOperationException: Cannot read keys when either application does not have a console or when console input has been redirected. Try Console.Read. How can I fix this?"
- "How do I use int.TryParse() for input validation in C# instead of Convert.ToInt32()? Show me examples with error handling."
- "Explain how to check for duplicate items in a cart array and update quantity instead of adding a new entry."
- "How do I declare an array that holds 5 products?"
- "How do I loop through the array to display all products?"
- "How do I calculate subtotal in the constructor?"
- "How do I update quantity and recalculate subtotal?"
- "How do I fix 'cart.Count' and 'cart.Add()' not working on arrays, track actual item count, and shift elements left when removing from the middle?"
- "How do I return stock when removing items, auto-recalculate subtotals on quantity change, and prevent crashes on empty cart operations?"
- "How do I filter an array by category, search with partial string matching, and compare strings case-insensitively?"
- "How do I format numbers with leading zeros like 0001, format DateTime as 'April 24, 2026 8:30 PM', and pad strings for aligned columns?"
- "How do I validate numeric input with double.TryParse, loop until user enters Y or N, and handle invalid menu choices?"
- "How do I store completed orders in an array, auto-increment a checkout counter, and show warnings only when conditions are met?"
- "How do I pass arrays by reference, add fields without breaking code, and handle Console.ReadKey exceptions?"

---

### What I Did Myself

- Wrote the original Part 1 code from scratch (Product class, CartItem class, main menu, add-to-cart, receipt, basic validation)
- Designed the overall program structure and flow
- Chose to use arrays instead of Lists per assignment requirements
- Tested the program with multiple scenarios (adding items, duplicates, out of stock, discounts)
- Adjusted output formatting to match assignment requirements
- Verified all validation paths work correctly
- Wrote the README.md and sample output documentation
- Created the Git commits and pull request
- Understood and modified AI-generated code to fit my existing codebase
