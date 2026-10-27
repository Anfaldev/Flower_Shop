
import 'package:flutter/material.dart';
import '../data/ProductService.dart';

class ProductsProvider extends ChangeNotifier {
  final ProductService productService = ProductService();

  List<Map<String, dynamic>> products = [];

  bool isLoading = false;
  String? error;

  Future<void> fetchProducts() async {
    isLoading = true;
    error = null;
    notifyListeners();

    try {
      products = await productService.getProducts();
    } catch (e) {
      error = 'Failed to load products';
    } finally {
      isLoading = false;
      notifyListeners();
    }
  }
}
