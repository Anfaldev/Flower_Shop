import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data/connection.dart';
import '../providers/cartProvider.dart';
import '../providers/orderProvider.dart';

class CartScreen extends StatefulWidget {
  final int userId;

  const CartScreen(this.userId, {super.key});

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {
  @override
  void initState() {
    super.initState();

    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<CartProvider>().fetchCart(widget.userId);
    });
  }

  Future<void> deleteProduct(int productId) async {
    final success = await context
        .read<CartProvider>()
        .removeFromCart(widget.userId, productId);

    if (!mounted) return;

    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text(
          success
              ? 'Product removed from cart'
              : 'Failed to remove product from cart',
        ),
        backgroundColor: success ? Colors.green : Colors.red,
      ),
    );
  }

  Future<void> makeOrder() async {
    final orderProvider = context.read<OrderProvider>();
    final success = await orderProvider.makeOrder(widget.userId);

    if (!mounted) return;

    if (!success) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text(
            orderProvider.error ?? 'Failed to create order',
          ),
          backgroundColor: Colors.red,
        ),
      );
      return;
    }

    await context.read<CartProvider>().fetchCart(widget.userId);

    if (!mounted) return;

    final orderId = orderProvider.lastOrderId;

    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text(
          orderId == null
              ? 'Order created successfully'
              : 'Order #$orderId created successfully',
        ),
        backgroundColor: Colors.green,
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('My Cart'),
        backgroundColor: Colors.indigo,
      ),
      body: Consumer<CartProvider>(
        builder: (context, provider, child) {
          if (provider.isLoading && provider.cartItems.isEmpty) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }

          if (provider.error != null && provider.cartItems.isEmpty) {
            return Center(
              child: Text(provider.error!),
            );
          }

          if (provider.cartItems.isEmpty) {
            return const Center(
              child: Text('Your Cart is Empty'),
            );
          }

          return Column(
            children: [
              Expanded(
                child: ListView.builder(
                  itemCount: provider.cartItems.length,
                  itemBuilder: (context, index) {
                    final item = provider.cartItems[index];

                    final imagePath =
                        item['imageUrl']?.toString() ?? '';

                    final imageUrl = imagePath.isEmpty
                        ? ''
                        : Uri.parse(ConnectionString.dashboardUrl)
                        .resolve(imagePath)
                        .toString();

                    final productIdValue = item['productId'] ??
                        item['ProductId'] ??
                        item['id'] ??
                        item['Id'];

                    final productId = productIdValue is num
                        ? productIdValue.toInt()
                        : int.tryParse(
                      productIdValue?.toString() ?? '',
                    );

                    return Card(
                      margin: const EdgeInsets.all(10),
                      child: ListTile(
                        leading: SizedBox(
                          width: 65,
                          height: 65,
                          child: imageUrl.isNotEmpty
                              ? Image.network(
                            imageUrl,
                            fit: BoxFit.cover,
                            errorBuilder: (context, error, stackTrace) {
                              return const Icon(Icons.image);
                            },
                          )
                              : const Icon(Icons.image),
                        ),
                        title: Text(
                          item['name']?.toString() ?? '',
                        ),
                        subtitle: Text(
                          '${item['price'] ?? 0} SAR\n'
                              'Quantity: ${item['quantity'] ?? 0}',
                        ),
                        isThreeLine: true,
                        trailing: IconButton(
                          icon: const Icon(
                            Icons.delete,
                            color: Colors.red,
                          ),
                          onPressed: productId == null
                              ? null
                              : () => deleteProduct(productId),
                        ),
                      ),
                    );
                  },
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(20),
                child: Text(
                  'Total: ${provider.total.toStringAsFixed(2)} SAR',
                  textAlign: TextAlign.center,
                  style: const TextStyle(
                    fontSize: 23,
                    fontWeight: FontWeight.bold,
                    color: Colors.green,
                  ),
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(16, 0, 16, 16),
                child: Consumer<OrderProvider>(
                  builder: (context, orderProvider, child) {
                    return SizedBox(
                      width: double.infinity,
                      height: 50,
                      child: ElevatedButton(
                        onPressed: orderProvider.isCreatingOrder
                            ? null
                            : makeOrder,
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.indigo,
                          foregroundColor: Colors.white,
                        ),
                        child: orderProvider.isCreatingOrder
                            ? const CircularProgressIndicator(
                          color: Colors.white,
                        )
                            : const Text(
                          'Make Order',
                          style: TextStyle(fontSize: 18),
                        ),
                      ),
                    );
                  },
                ),
              ),
            ],
          );
        },
      ),
    );
  }
}