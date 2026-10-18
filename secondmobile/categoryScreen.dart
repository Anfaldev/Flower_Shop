import 'package:flutter/material.dart';

import 'data/CategoryService.dart';


class CategoryScreen extends StatefulWidget {
  const CategoryScreen({super.key});

  @override
  State<CategoryScreen> createState() => _CategoryScreenState();
}

class _CategoryScreenState extends State<CategoryScreen> {
  final CategoryService categoryService = CategoryService();

  late Future<List<dynamic>> categories;

  @override
  void initState() {
    super.initState();
    categories = categoryService.getAllCategories();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Categories'),
        backgroundColor: Colors.blue,
      ),

      body: FutureBuilder<List<dynamic>>(
        future: categories,

        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }

          if (snapshot.hasError) {
            return Center(
              child: Text(
                'Error: ${snapshot.error}',
                textAlign: TextAlign.center,
              ),
            );
          }

          if (!snapshot.hasData || snapshot.data!.isEmpty) {
            return const Center(
              child: Text('No categories found'),
            );
          }

          final items = snapshot.data!;

          return ListView.builder(
            itemCount: items.length,

            itemBuilder: (context, index) {
              final category = items[index];

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