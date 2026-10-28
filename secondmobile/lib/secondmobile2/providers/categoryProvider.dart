import 'package:flutter/material.dart';

import '../data/CategoryService.dart';

class CategoryProvider extends ChangeNotifier {
  final CategoryService categoryService = CategoryService();

  List<dynamic> categories = [];
  bool isLoading = false;
  String? error;

  Future<void> getAllCategories() async {
    isLoading = true;
    error = null;
    notifyListeners();

    try {
      categories = await categoryService.getAllCategories();
    } catch (e) {
      error = 'Failed to load categories';
    } finally {
      isLoading = false;
      notifyListeners();
    }
  }
}