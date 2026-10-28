import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/ProductsProvider.dart';
import 'productDetailsScreen.dart';

class ProductsScreen extends StatefulWidget {
  final int userId;

  const ProductsScreen(this.userId, {super.key});

  @override
  State<ProductsScreen> createState() => _ProductsScreenState();
}

class _ProductsScreenState extends State<ProductsScreen> {
  @override
  void initState() {
    super.initState();

    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<ProductsProvider>().fetchProducts();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Products'),
        backgroundColor: Colors.green,
      ),
      body: Consumer<ProductsProvider>(
        builder: (context, provider, child) {
          if (provider.isLoading) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }

          if (provider.error != null) {
            return Center(
              child: Text(
                'Failed to load products:\n${provider.error}',
                textAlign: TextAlign.center,
              ),
            );
          }

          final products = provider.products;

          if (products.isEmpty) {
            return const Center(
              child: Text('No products found'),
            );
          }

          return ListView.builder(
            padding: const EdgeInsets.all(12),
            itemCount: products.length,
            itemBuilder: (context, index) {
              final product = products[index];

              final name =
                  product['name']?.toString() ?? 'Unnamed Product';
              final price = product['price']?.toString() ?? '0';
              final stock = product['stock']?.toString() ?? '0';
              final imageUrl = product['imageUrl']?.toString() ?? '';

              return Card(
                margin: const EdgeInsets.only(bottom: 12),
                child: ListTile(
                  contentPadding: const EdgeInsets.all(12),
                  leading: imageUrl.isNotEmpty
                      ? Image.network(
                    imageUrl,
                    width: 60,
                    height: 60,
                    fit: BoxFit.cover,
                    errorBuilder: (context, error, stackTrace) {
                      return const Icon(
                        Icons.local_florist,
                        size: 40,
                        color: Colors.green,
                      );
                    },
                  )
                      : const Icon(
                    Icons.local_florist,
                    size: 40,
                    color: Colors.green,
                  ),
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
                  trailing: const Icon(
                    Icons.arrow_forward_ios,
                    size: 16,
                  ),
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (_) => ProductDetailsScreen(
                          product,
                          widget.userId,
                        ),
                      ),
                    );
                  },
                ),
              );
            },
          );
        },
      ),
    );
  }
}