import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/categoryProvider.dart';

class CategoryScreen extends StatefulWidget {
  const CategoryScreen({super.key});

  @override
  State<CategoryScreen> createState() => _CategoryScreenState();
}

class _CategoryScreenState extends State<CategoryScreen> {
  @override
  void initState() {
    super.initState();

    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<CategoryProvider>().getAllCategories();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Categories'),
        backgroundColor: Colors.blue,
      ),
      body: Consumer<CategoryProvider>(
        builder: (context, provider, child) {
          if (provider.isLoading) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }

          if (provider.error != null) {
            return Center(
              child: Text(
                provider.error!,
                textAlign: TextAlign.center,
              ),
            );
          }

          if (provider.categories.isEmpty) {
            return const Center(
              child: Text('No categories found'),
            );
          }

          return ListView.builder(
            itemCount: provider.categories.length,
            itemBuilder: (context, index) {
              final category = provider.categories[index];

              return Container(
                padding: const EdgeInsets.symmetric(
                  vertical: 5,
                  horizontal: 10,
                ),
                child: ListTile(
                  leading: const Icon(
                    Icons.category,
                    color: Colors.blue,
                  ),
                  title: Text(
                    category['Name']?.toString() ??
                        category['name']?.toString() ??
                        'Unnamed Category',
                  ),
                  subtitle: Text(
                    'ID: ${category['Id'] ?? category['id'] ?? ''}',
                  ),
                  trailing: const Icon(
                    Icons.arrow_forward_ios,
                    size: 16,
                  ),
                  tileColor: Colors.amber.shade100,
                  shape: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(20),
                    borderSide: BorderSide.none,
                  ),
                ),
              );
            },
          );
        },
      ),
    );
  }
}