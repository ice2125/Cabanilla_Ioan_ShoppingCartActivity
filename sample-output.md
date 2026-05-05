# Sample Output - Shopping Cart System Part 2

## Main Menu
```
=================================
Welcome to the Resurgo Gym Store!
=================================

================================
STORE MENU
================================
1 Gym-Shorts 599 - Stock: 20
2 Gym-Shirts 799 - Stock: 15
3 Gym-Accesories 399 - Stock: 10
4 Gym-Bags 699 - Stock: 8
================================
Enter -2 to filter by category
Enter -1 to search products
Enter 0 to finish shopping

Enter product number
```

## Search Example
```
Enter product name to search: shirt
2 Gym-Shirts 799 - Stock: 15
```

## Category Filter Example
```
1. Clothing  2. Accessories
Enter category number: 1
1 Gym-Shorts 599 - Stock: 20
2 Gym-Shirts 799 - Stock: 15
```

## Adding to Cart
```
Enter product number
1
Enter quantity: 
3
Success: Added to cart!
 3 x Gym-Shorts = $1797

1. Keep shopping
2. Go to Cart Menu
Choose: 2
```

## Cart Menu - View Cart
```
========== CART MENU ==========
1. View Cart
2. Remove Item
3. Update Quantity
4. Clear Cart
5. Checkout
===============================
Choose option: 1
1. Gym-Shorts x 3 = $1797
```

## Cart Menu - Update Quantity
```
Choose option: 3
1. Gym-Shorts x 3 = $1797
Enter item number to update: 1
Enter new quantity: 5
Quantity updated.
```

## Cart Menu - Remove Item
```
Choose option: 2
1. Gym-Shorts x 5 = $2995
Enter item number to remove: 1
Item removed.
```

## Payment and Receipt
```
================================
RECEIPT
================================
Receipt No: 0001
Date: May 5, 2026 6:45 PM
Item               Qty   Price    Total
-----------------------------------
Gym-Shirts         2     $799    $1598
Gym-Bags           1     $699    $699
-----------------------------------
GRAND TOTAL: $2297
FINAL TOTAL: $2297
-----------------------------------
Enter payment: $2000
Insufficient payment.
Enter payment: $2500
PAYMENT: $2500
CHANGE: $203
===================================
```

## Low Stock Alert
```
========== LOW STOCK ALERTS ==========
All products have sufficient stock.
```

## Order History
```
========== ORDER HISTORY ==========
Receipt #0001 - Final Total: $2297
```

## Inventory Update
```
Gym-Shorts: 20 left
Gym-Shirts: 13 left
Gym-Accesories: 10 left
Gym-Bags: 7 left
Thank you for shopping with us!
Press any key to exit...
```

## Validation Examples

### Invalid Y/N Input
```
Continue shopping? (Y/N): maybe
Invalid input. Please enter Y or N only.
Continue shopping? (Y/N): n
```

### Invalid Payment
```
Enter payment: abc
Payment must be numeric.
Enter payment: 100
Insufficient payment.
Enter payment: 2500
```

### Out of Stock
```
Enter product number
1
Enter quantity: 
25
Error: Not enough stock. 20 available
```

### Invalid Product Number
```
Enter product number
99
Error: Product number does not exist
```

### Cart Limit Reached
```
Enter product number
2
Enter quantity: 
8
Error: Cannot add items. Cart total would exceed maximum of 10 items.
```
