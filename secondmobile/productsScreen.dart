import 'package:flutter/material.dart';
import 'data/ProductService.dart';

class ProductsScreen extends StatefulWidget {
  const ProductsScreen({super.key});

  @override
  State<ProductsScreen> createState() => _ProductsScreenState();
}

class _ProductsScreenState extends State<ProductsScreen> {
  final ProductService productService = ProductService();

  late Future<List<dynamic>> productsFuture;

  @override
  void initState() {
    super.initState();
    productsFuture = productService.getAllProducts();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Products'),
        backgroundColor: Colors.green,
      ),
      body: FutureBuilder<List<dynamic>>(
        future: productsFuture,
        builder: (context, snapshot) {
          // Loading
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }

          // Error
          if (snapshot.hasError) {
            return Center(
              child: Padding(
                padding: const EdgeInsets.all(16),
                child: Text(
                  'Failed to load products:\n${snapshot.error}',
                  textAlign: TextAlign.center,
                ),
              ),
            );
          }

          // Empty list
          final products = snapshot.data ?? [];

          if (products.isEmpty) {
            return const Center(
              child: Text('No products found'),
            );
          }

          // Display products
          return ListView.builder(
            padding: const EdgeInsets.all(12),
            itemCount: products.length,
            itemBuilder: (context, index) {
              final product = products[index];

              final String name =
                  product['name']?.toString() ?? 'Unnamed Product';

              final String price =
                  product['price']?.toString() ?? '0';

              final String stock =
                  product['stock']?.toString() ?? '0';

              final String? imageUrl =
              product['imageUrl']?.toString();

              return Card(
                margin: const EdgeInsets.only(bottom: 12),
                child: ListTile(
                  contentPadding: const EdgeInsets.all(12),

                  // Product image
                  leading: imageUrl != null && imageUrl.isNotEmpty
                      ? Image.network(
                    imageUrl,
                    width: 60,
                    height: 60,
                    fit: BoxFit.cover,
                    errorBuilder: (context, error, stackTrace) {
                      return const Icon(
                        Icons.local_florist,
                        size: 45,
                        color: Colors.green,
                      );
                    },
                  )
                      : const Icon(
                    Icons.local_florist,
                    size: 45,
                    color: Colors.green,
                  ),

                  // Product details
                  title: Text(
                    name,
                    style: const TextStyle(
                      fontWeight: FontWeight.bold,
                    ),
                  ),

                  subtitle: Text(
                    'Price: $price SAR\nStock: $stock',
                  ),

                  isThreeLine: true,
                ),
              );
            },
          );
        },
      ),
    );
  }
}