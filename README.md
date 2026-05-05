### Cabanilla_Ioan_ShoppingCartActivity_Part_2
##Student: Cabanilla, Ioan Rayne J.
##Course: BSIT 1-2

#About the Project

This is a Shopping Cart System made in C#. It runs in the console and shows how to use classes, objects, and arrays in a real program. It also has input validation, stock tracking, and a discount system.

The store has four products. Each product has a stock count that goes down every time you add it to your cart. If you try to add the same product twice, it just updates the quantity instead of adding a new row. The cart can hold up to 10 different products. When you check out, it shows a receipt with all your items, the prices, and the total. If your total is ₱5,000 or more, you automatically get a 10% discount. The program also handles mistakes like typing letters instead of numbers, picking a product that doesn't exist, entering a quantity of 0, or trying to buy something that's out of stock.

Part 2 Features

Cart Management Menu. Before checking out, you can open the Cart Menu to view everything currently in your cart with quantities and subtotals, remove a product and return its stock to the store, change how many of a product you want, clear your entire cart and return all stock, or proceed to checkout.

Product Search. You can search for products by typing part of the name. The search is case-insensitive.

Product Categories. Products are grouped into categories such as Clothing and Accessories. You can filter the store menu to show only products from one category.

Payment Validation. At checkout, the program asks for your payment amount. It checks that the input is a number and that the payment is enough to cover the final total, then calculates and shows your change.

Receipt Details. Every receipt shows a receipt number that auto-increments like 0001 and 0002, the date and time of checkout, all purchased items with quantity, price, and total, the grand total, discount if applicable, the final total, and the payment amount with change.

Low Stock Alerts. After checkout, the program warns you if any product has 5 or fewer items left in stock.

Order History. All completed transactions are saved during the program run. You can view the order history after checkout to see past receipts and their totals.

Better Validation. All Yes/No prompts will keep asking until you enter Y or N, so the program no longer crashes or skips on bad input.

How do I loop through the array to display all products? How do I calculate the subtotal in the constructor? How do I update the quantity and recalculate the subtotal?
