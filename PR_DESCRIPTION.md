## Part 2: Enhanced Shopping Cart System

### Summary of Changes

This pull request adds all 8 required Part 2 features to the existing Shopping Cart System:

1. **Cart Management Menu** – Added a full cart menu where users can view cart contents, remove items, update quantities, clear the entire cart, or proceed to checkout. Accessible mid-shopping without losing progress.

2. **Product Search** – Users can search for products by typing part of the product name. Search is case-insensitive and uses `string.Contains()` for partial matching.

3. **Product Categories** – Added a `Category` field to the `Product` class. Products are categorized as "Clothing" or "Accessories". Users can filter the store menu by category number.

4. **Payment Validation & Change Computation** – At checkout, the program validates that payment is numeric and sufficient to cover the final total. If insufficient, it re-prompts. It then calculates and displays the change.

5. **Receipt Number & Date/Time** – Each receipt gets an auto-incrementing receipt number formatted as `0001`, `0002`, etc. The checkout date and time are displayed using `DateTime.Now`.

6. **Low Stock Alerts** – After checkout, the program checks all products and displays a warning for any product with 5 or fewer items remaining in stock.

7. **Order History** – Completed transactions are stored in an `Order` array during the program run. Users can view all past orders with receipt numbers and final totals.

8. **Better Y/N Validation** – All Yes/No prompts now loop until the user enters exactly `Y` or `N`. Invalid input shows an error message and re-prompts.

### Additional Improvements

- **Cart Limit Enforcement** – Cart enforces max 10 different products and max 10 total items across all quantities
- **Null-safe array handling** – Uses `FindFirstEmptySlot()` and `FindInCart()` helper methods for safer array operations
- **Stock restoration** – Removing items or clearing cart properly returns stock to inventory

### Files Changed

| File | Change |
|------|--------|
| `Program.cs` | Added all Part 2 features (cart menu, search, categories, payment, receipt, alerts, history, validation) |
| `README.md` | Updated with Part 2 features, how to run, sample output link, AI usage, and commit history |
| `AI_USAGE.md` | New file documenting AI prompts and assistance |
| `sample-output.md` | New file with example program output showing all features |

### Commits

- `Add cart management menu` – Added view, remove, update quantity, clear cart, and checkout options
- `Add product search and category filter` – Added search by name and filter by Clothing/Accessories category
- `Add payment validation, receipt details, and order history` – Added payment checking, receipt number, date/time, low stock alerts, and order history storage

### Testing

- Tested adding, removing, and updating cart items
- Tested search with partial names and case variations
- Tested category filtering for both Clothing and Accessories
- Tested payment with invalid input, insufficient payment, and correct payment
- Tested receipt generation and order history after multiple checkouts
- Tested low stock alert by purchasing items until stock dropped below 5
- Tested Y/N validation with invalid inputs (numbers, words, empty input)
- Tested cart limit enforcement (10 different products, 10 total items)

### Notes

- All features use arrays as required by the assignment (no Lists)
- Original Part 1 functionality (discounts, stock tracking, input validation) is preserved
- Code style matches the original codebase for consistency
