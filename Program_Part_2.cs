using System;

namespace ShoppingCartSystem
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int RemainingStock;
        public string Category;

        public Product(int id, string name, double price, int remainingStock, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            RemainingStock = remainingStock;
            Category = category;
        }

        public void DisplayProduct()
        {
            if (RemainingStock == 0)
                Console.WriteLine(Id + " " + Name + " " + Price + " - Out of Stock");
            else
                Console.WriteLine(Id + " " + Name + " " + Price + " - Stock: " + RemainingStock);
        }

        public bool HasEnoughStock(int quantity)
        {
            return RemainingStock >= quantity;
        }

        public void ReduceStock(int quantity)
        {
            RemainingStock -= quantity;
            if (RemainingStock < 0) RemainingStock = 0;
        }
    }

    class Cartitem
    {
        public Product Product;
        public int Quantity;
        public double Subtotal;

        public Cartitem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Subtotal = product.Price * quantity;
        }

        public void Addmore(int add)
        {
            Quantity += add;
            Subtotal = Product.Price * Quantity;
        }
    }

    class Order
    {
        public string Receipt;
        public double Total;

        public Order(string receipt, double total)
        {
            Receipt = receipt;
            Total = total;
        }
    }

    class Program
    {
        const int MAX_CART_SLOTS = 10;       // max different products in cart
        const int MAX_TOTAL_ITEMS = 10;      // max total quantity across all products
        const int MAX_HISTORY = 100;

        static int GetTotalItems(Cartitem[] cart)
        {
            int total = 0;
            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i] != null) total += cart[i].Quantity;
            }
            return total;
        }

        static int FindInCart(Cartitem[] cart, int productId, int cartCount)
        {
            for (int i = 0; i < cartCount; i++)
            {
                if (cart[i] != null && cart[i].Product.Id == productId) return i;
            }
            return -1;
        }

        static int FindFirstEmptySlot(Cartitem[] cart)
        {
            for (int i = 0; i < cart.Length; i++) if (cart[i] == null) return i;
            return -1;
        }

        static void Main(string[] args)
        {
            Product product1 = new Product(1, "Gym-Shorts", 599.00, 20, "Clothing");
            Product product2 = new Product(2, "Gym-Shirts", 799.00, 15, "Clothing");
            Product product3 = new Product(3, "Gym-Accesories", 399.00, 10, "Accessories");
            Product product4 = new Product(4, "Gym-Bags", 699.00, 8, "Accessories");

            Product[] storeMenu = new Product[4] { product1, product2, product3, product4 };

            Cartitem[] cart = new Cartitem[MAX_CART_SLOTS];
            int cartItemCount = 0; // number of occupied slots (not total quantity)

            Order[] history = new Order[MAX_HISTORY];
            int histCount = 0;
            int receiptNum = 1;

            bool keepShopping = true;

            Console.WriteLine("=================================");
            Console.WriteLine("Welcome to the Resurgo Gym Store!");
            Console.WriteLine("=================================");

            while (keepShopping)
            {
                Console.WriteLine();
                Console.WriteLine("================================");
                Console.WriteLine("STORE MENU");
                Console.WriteLine("================================");
                for (int i = 0; i < storeMenu.Length; i++) storeMenu[i].DisplayProduct();
                Console.WriteLine("================================");
                Console.WriteLine("Enter -2 to filter by category");
                Console.WriteLine("Enter -1 to search products");
                Console.WriteLine("Enter 0 to finish shopping");
                Console.WriteLine();
                Console.WriteLine("Enter product number");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int productNumber))
                {
                    Console.WriteLine("Error: Please enter number only");
                    continue;
                }

                if (productNumber == -2)
                {
                    Console.WriteLine("1. Clothing  2. Accessories");
                    Console.Write("Enter category number: ");
                    string catChoice = Console.ReadLine();
                    string category = catChoice == "1" ? "Clothing" : "Accessories";
                    for (int i = 0; i < storeMenu.Length; i++) if (storeMenu[i].Category == category) storeMenu[i].DisplayProduct();
                    continue;
                }

                if (productNumber == -1)
                {
                    Console.Write("Enter product name to search: ");
                    string search = Console.ReadLine().ToLower();
                    bool found = false;
                    for (int i = 0; i < storeMenu.Length; i++)
                    {
                        if (storeMenu[i].Name.ToLower().Contains(search))
                        {
                            storeMenu[i].DisplayProduct();
                            found = true;
                        }
                    }
                    if (!found) Console.WriteLine("No products found.");
                    continue;
                }

                if (productNumber == 0) break;

                Product selected = null;
                for (int i = 0; i < storeMenu.Length; i++) if (storeMenu[i].Id == productNumber) { selected = storeMenu[i]; break; }
                if (selected == null)
                {
                    Console.WriteLine("Error: Product number does not exist");
                    continue;
                }

                if (selected.RemainingStock == 0)
                {
                    Console.WriteLine("Error: Product is out of stock");
                    continue;
                }

                Console.WriteLine("Enter quantity: ");
                string qtyIn = Console.ReadLine();
                if (!int.TryParse(qtyIn, out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Error: Quantity must be a positive integer");
                    continue;
                }

                if (!selected.HasEnoughStock(quantity))
                {
                    Console.WriteLine("Error: Not enough stock. " + selected.RemainingStock + " available");
                    continue;
                }

                // enforce global total quantity limit
                int totalNow = GetTotalItems(cart);
                if (totalNow + quantity > MAX_TOTAL_ITEMS)
                {
                    Console.WriteLine("Error: Cannot add items. Cart total would exceed maximum of " + MAX_TOTAL_ITEMS + " items.");
                    continue;
                }

                int foundIndex = FindInCart(cart, selected.Id, cartItemCount);
                if (foundIndex != -1)
                {
                    // update existing cart slot
                    cart[foundIndex].Addmore(quantity);
                    selected.ReduceStock(quantity);
                    Console.WriteLine("SUCCESS: Updated cart! Now you have " + cart[foundIndex].Quantity + " " + selected.Name);
                    Console.WriteLine("Subtotal: $" + cart[foundIndex].Subtotal);
                }
                else
                {
                    // new cart slot
                    int slot = FindFirstEmptySlot(cart);
                    if (slot == -1)
                    {
                        Console.WriteLine("Error: Cart is full (max " + MAX_CART_SLOTS + " different products). Cannot add more items.");
                        continue;
                    }
                    cart[slot] = new Cartitem(selected, quantity);
                    cartItemCount = 0; for (int c = 0; c < cart.Length; c++) if (cart[c] != null) cartItemCount++;
                    selected.ReduceStock(quantity);
                    Console.WriteLine("Success: Added to cart!");
                    Console.WriteLine(" " + quantity + " x " + selected.Name + " = $" + cart[slot].Subtotal);
                }

                Console.WriteLine();
                Console.WriteLine("1. Keep shopping");
                Console.WriteLine("2. Go to Cart Menu");
                Console.Write("Choose: ");
                string menuChoice = Console.ReadLine();

                if (menuChoice == "2")
                {
                    bool inCart = true;
                    while (inCart)
                    {
                        Console.WriteLine();
                        Console.WriteLine("========== CART MENU ==========");
                        Console.WriteLine("1. View Cart");
                        Console.WriteLine("2. Remove Item");
                        Console.WriteLine("3. Update Quantity");
                        Console.WriteLine("4. Clear Cart");
                        Console.WriteLine("5. Checkout");
                        Console.WriteLine("===============================");
                        Console.Write("Choose option: ");
                        string choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            if (cartItemCount == 0) Console.WriteLine("Cart is empty.");
                            else for (int i = 0; i < cartItemCount; i++) Console.WriteLine((i + 1) + ". " + cart[i].Product.Name + " x " + cart[i].Quantity + " = $" + cart[i].Subtotal);
                        }
                        else if (choice == "2")
                        {
                            if (cartItemCount == 0) { Console.WriteLine("Cart is empty."); continue; }
                            for (int i = 0; i < cartItemCount; i++) Console.WriteLine((i + 1) + ". " + cart[i].Product.Name + " x " + cart[i].Quantity + " = $" + cart[i].Subtotal);
                            Console.Write("Enter item number to remove: ");
                            if (!int.TryParse(Console.ReadLine(), out int removeIndex) || removeIndex < 1 || removeIndex > cartItemCount) { Console.WriteLine("Invalid selection."); continue; }
                            cart[removeIndex - 1].Product.RemainingStock += cart[removeIndex - 1].Quantity;
                            // shift left
                            for (int s = removeIndex - 1; s < cartItemCount - 1; s++) cart[s] = cart[s + 1];
                            cart[cartItemCount - 1] = null; cartItemCount--;
                            Console.WriteLine("Item removed.");
                        }
                        else if (choice == "3")
                        {
                            if (cartItemCount == 0) { Console.WriteLine("Cart is empty."); continue; }
                            for (int i = 0; i < cartItemCount; i++) Console.WriteLine((i + 1) + ". " + cart[i].Product.Name + " x " + cart[i].Quantity + " = $" + cart[i].Subtotal);
                            Console.Write("Enter item number to update: ");
                            if (!int.TryParse(Console.ReadLine(), out int updateIndex) || updateIndex < 1 || updateIndex > cartItemCount) { Console.WriteLine("Invalid selection."); continue; }
                            Console.Write("Enter new quantity: ");
                            if (!int.TryParse(Console.ReadLine(), out int newQty) || newQty < 1) { Console.WriteLine("Invalid quantity."); continue; }
                            int diff = newQty - cart[updateIndex - 1].Quantity;
                            if (diff > 0 && !cart[updateIndex - 1].Product.HasEnoughStock(diff)) { Console.WriteLine("Not enough stock."); continue; }
                            if (diff > 0 && GetTotalItems(cart) + diff > MAX_TOTAL_ITEMS) { Console.WriteLine("Cannot update. Would exceed max total items of " + MAX_TOTAL_ITEMS); continue; }
                            cart[updateIndex - 1].Product.ReduceStock(diff);
                            cart[updateIndex - 1].Quantity = newQty;
                            cart[updateIndex - 1].Subtotal = cart[updateIndex - 1].Product.Price * newQty;
                            Console.WriteLine("Quantity updated.");
                        }
                        else if (choice == "4")
                        {
                            for (int i = 0; i < cartItemCount; i++) { cart[i].Product.RemainingStock += cart[i].Quantity; cart[i] = null; }
                            cartItemCount = 0;
                            Console.WriteLine("Cart cleared.");
                        }
                        else if (choice == "5")
                        {
                            inCart = false; keepShopping = false;
                        }
                        else Console.WriteLine("Invalid option.");
                    }
                }
                else if (menuChoice != "1") Console.WriteLine("Invalid choice.");
            }

            // Checkout / receipt
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("RECEIPT");
            Console.WriteLine("================================");
            Console.WriteLine("Receipt No: " + receiptNum.ToString("D4"));
            Console.WriteLine("Date: " + DateTime.Now.ToString("MMMM dd, yyyy h:mm tt"));
            Console.WriteLine("Item Qty Price Total");
            Console.WriteLine("-----------------------------------");
            double grandTotal = 0;
            for (int i = 0; i < cartItemCount; i++)
            {
                string itemName = cart[i].Product.Name;
                int itemQty = cart[i].Quantity;
                double itemPrice = cart[i].Product.Price;
                double itemTotal = cart[i].Subtotal;
                grandTotal += itemTotal;
                Console.Write(itemName);
                int spacesNeeded = Math.Max(1, 18 - itemName.Length);
                for (int s = 0; s < spacesNeeded; s++) Console.Write(" ");
                Console.Write(itemQty + "     ");
                Console.Write("$" + itemPrice + "    ");
                Console.WriteLine("$" + itemTotal);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("GRAND TOTAL: $" + grandTotal);
            double finalTotal = grandTotal;
            double discount = 0;
            if (grandTotal >= 5000)
            {
                discount = grandTotal * 0.10;
                finalTotal = grandTotal - discount;
                Console.WriteLine("DISCOUNT (10%): -$" + discount);
            }
            Console.WriteLine("FINAL TOTAL: $" + finalTotal);
            Console.WriteLine("-----------------------------------");

            double payment;
            do
            {
                Console.Write("Enter payment: $");
                string pay = Console.ReadLine();
                if (!double.TryParse(pay, out payment)) { Console.WriteLine("Payment must be numeric."); continue; }
                if (payment < finalTotal) Console.WriteLine("Insufficient payment.");
            } while (payment < finalTotal);

            Console.WriteLine("PAYMENT: $" + payment);
            Console.WriteLine("CHANGE: $" + (payment - finalTotal));
            Console.WriteLine("===================================");

            // store history
            if (histCount < MAX_HISTORY) history[histCount++] = new Order(receiptNum.ToString("D4"), finalTotal);

            Console.WriteLine();
            Console.WriteLine("========== LOW STOCK ALERTS ==========");
            bool hasAlert = false;
            for (int i = 0; i < storeMenu.Length; i++)
            {
                if (storeMenu[i].RemainingStock <= 5)
                {
                    Console.WriteLine("LOW STOCK: " + storeMenu[i].Name + " has only " + storeMenu[i].RemainingStock + " left.");
                    hasAlert = true;
                }
            }
            if (!hasAlert) Console.WriteLine("All products have sufficient stock.");

            Console.WriteLine();
            Console.WriteLine("========== ORDER HISTORY ==========");
            for (int i = 0; i < histCount; i++) Console.WriteLine("Receipt #" + history[i].Receipt + " - Final Total: $" + history[i].Total);

            Console.WriteLine();
            for (int i = 0; i < storeMenu.Length; i++) Console.WriteLine(storeMenu[i].Name + ": " + storeMenu[i].RemainingStock + " left");
            Console.WriteLine("Thank you for shopping with us!");
            Console.WriteLine("Press any key to exit...");
            try { Console.ReadKey(); } catch (InvalidOperationException) { Console.ReadLine(); }
        }
    }
}
