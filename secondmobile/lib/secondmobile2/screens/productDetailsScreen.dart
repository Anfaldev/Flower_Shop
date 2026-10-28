import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../data/connection.dart';
import '../providers/cartProvider.dart';

class ProductDetailsScreen extends StatelessWidget {
  final Map<String, dynamic> product;
  final int userId;

  const ProductDetailsScreen(
      this.product,
      this.userId, {
        super.key,
      });

  Future<void> addToCart(BuildContext context) async {
    final idValue = product['productId'] ??
        product['ProductId'] ??
        product['id'] ??
        product['Id'];

    final productId = idValue is num
        ? idValue.toInt()
        : int.tryParse(idValue?.toString() ?? '');

    if (productId == null) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Could not find this product ID'),
          backgroundColor: Colors.red,
        ),
      );
      return;
    }

    final success = await context.read<CartProvider>().addToCart(
      userId,
      productId,
    );

    if (!context.mounted) return;

    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text(
          success ? 'Product added to cart' : 'Failed to add product',
        ),
        backgroundColor: success ? Colors.green : Colors.red,
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    final imagePath =
    (product['imageUrl'] ?? product['ImageUrl'] ?? '').toString();

    final imageUrl = imagePath.isEmpty
        ? ''
        : Uri.parse(ConnectionString.dashboardUrl)
        .resolve(imagePath)
        .toString();

    final name =
    (product['name'] ?? product['Name'] ?? 'No name').toString();
    final price = product['price'] ?? product['Price'] ?? 0;
    final categoryId =
        product['categoryId'] ?? product['CategoryId'] ?? 'N/A';
    final description = (
        product['description'] ??
            product['Description'] ??
            'No description available'
    ).toString();

    return Scaffold(
      appBar: AppBar(
        title: const Text('Product Details'),
        backgroundColor: Colors.indigo,
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(
              width: double.infinity,
              height: 300,
              child: imageUrl.isNotEmpty
                  ? Image.network(
                imageUrl,
                fit: BoxFit.contain,
                errorBuilder: (context, error, stackTrace) {
                  return const Icon(
                    Icons.image_not_supported,
                    size: 100,
                  );
                },
              )
                  : const Icon(
                Icons.image,
                size: 100,
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(16),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    name,
                    style: const TextStyle(
                      fontSize: 26,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  const SizedBox(height: 15),
                  Text(
                    '$price SAR',
                    style: const TextStyle(
                      fontSize: 24,
                      color: Colors.green,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  const SizedBox(height: 20),
                  const Divider(),
                  const SizedBox(height: 15),
                  Text(
                    'Category ID: $categoryId',
                    style: const TextStyle(fontSize: 18),
                  ),
                  const SizedBox(height: 20),
                  Text(
                    description,
                    style: const TextStyle(fontSize: 16),
                  ),
                  const SizedBox(height: 30),
                  SizedBox(
                    width: double.infinity,
                    height: 50,
                    child: ElevatedButton.icon(
                      onPressed: () => addToCart(context),
                      icon: const Icon(Icons.add_shopping_cart),
                      label: const Text(
                        'Add to Cart',
                        style: TextStyle(fontSize: 18),
                      ),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.green,
                        foregroundColor: Colors.white,
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}