
import 'package:flutter/material.dart';
import 'data/CartService.dart';

class ProductDetailsScreen extends StatefulWidget {
  final dynamic product;
  final int userId;

  const ProductDetailsScreen({
    super.key,
    required this.product,
    required this.userId,
  });

  @override
  State<ProductDetailsScreen> createState() =>
      _ProductDetailsScreenState();
}

class _ProductDetailsScreenState extends State<ProductDetailsScreen> {
  final CartService cartService = CartService();

  bool isAdding = false;

  Future<void> addProductToCart() async {
    final rawId =
        widget.product['id'] ?? widget.product['Id'];

    final int? productId = rawId is num
        ? rawId.toInt()
        : int.tryParse(rawId?.toString() ?? '');

    if (productId == null) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Product ID was not found'),
        ),
      );
      return;
    }

    setState(() => isAdding = true);

    try {
      await cartService.addToCart(widget.userId, productId);

      if (!mounted) return;

      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Product added to cart successfully'),
        ),
      );
    } catch (e) {
      if (!mounted) return;

      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Could not add product: $e')),
      );
    } finally {
      if (mounted) {
        setState(() => isAdding = false);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    final product = widget.product;

    final name =
        product['name']?.toString() ?? 'Unnamed Product';
    final price = product['price']?.toString() ?? '0';
    final stock = product['stock']?.toString() ?? '0';
    final imageUrl = product['imageUrl']?.toString() ?? '';

    return Scaffold(
      appBar: AppBar(
        title: const Text('Product Details'),
        backgroundColor: Colors.green,
      ),
      body: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Expanded(
              child: imageUrl.isNotEmpty
                  ? Image.network(
                imageUrl,
                fit: BoxFit.contain,
                errorBuilder: (_, __, ___) => const Icon(
                  Icons.local_florist,
                  size: 120,
                  color: Colors.green,
                ),
              )
                  : const Icon(
                Icons.local_florist,
                size: 120,
                color: Colors.green,
              ),
            ),
            const SizedBox(height: 20),
            Text(
              name,
              style: const TextStyle(
                fontSize: 25,
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 12),
            Text(
              'Price: $price SAR',
              style: const TextStyle(fontSize: 20),
            ),
            const SizedBox(height: 8),
            Text(
              'Available stock: $stock',
              style: const TextStyle(fontSize: 16),
            ),
            const SizedBox(height: 24),
            ElevatedButton.icon(
              onPressed: isAdding ? null : addProductToCart,
              icon: isAdding
                  ? const SizedBox(
                width: 20,
                height: 20,
                child: CircularProgressIndicator(
                  strokeWidth: 2,
                ),
              )
                  : const Icon(Icons.add_shopping_cart),
              label: Text(
                isAdding ? 'Adding...' : 'Add to Cart',
              ),
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.green,
                foregroundColor: Colors.white,
                padding: const EdgeInsets.all(16),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
