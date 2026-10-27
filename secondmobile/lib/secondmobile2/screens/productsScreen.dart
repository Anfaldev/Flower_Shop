
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/ProductsProvider.dart';

class ProductsScreen extends StatefulWidget {
  const ProductsScreen({super.key});

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
        backgroundColor: Colors.indigo,
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
              child: Text(provider.error!),
            );
          }

          if (provider.products.isEmpty) {
            return const Center(
              child: Text('No products found'),
            );
          }

          return ListView.builder(
            itemCount: provider.products.length,
            itemBuilder: (context, index) {
              final product = provider.products[index];

              return ListTile(
                leading: const Icon(
                  Icons.shopping_bag,
                  color: Colors.indigo,
                ),
                title: Text(
                  (product['name'] ?? product['Name'] ?? 'No name')
                      .toString(),
                ),
                subtitle: Text(
                  'Price: ${product['price'] ?? product['Price'] ?? 0}',
                ),
              );
            },
          );
        },
      ),
    );
  }
}
