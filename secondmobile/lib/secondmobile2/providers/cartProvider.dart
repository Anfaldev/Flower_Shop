import 'package:flutter/material.dart';

import '../data/CartService.dart';

class CartProvider extends ChangeNotifier {
  final CartService cartService = CartService();

  List<dynamic> cartItems = [];
  bool isLoading = false;
  String? error;

  double get total {
    double result = 0;

    for (final item in cartItems) {
      final price = item['price'];
      final quantity = item['quantity'];

      final itemPrice = price is num ? price.toDouble() : 0.0;
      final itemQuantity = quantity is num ? quantity.toInt() : 0;

      result += itemPrice * itemQuantity;
    }

    return result;
  }

  Future<void> fetchCart(int userId) async {
    isLoading = true;
    error = null;
    notifyListeners();

    try {
      cartItems = await cartService.getCart(userId);
    } catch (e) {
      error = 'Failed to load cart';
    } finally {
      isLoading = false;
      notifyListeners();
    }
  }

  Future<bool> addToCart(int userId, int productId) async {
    error = null;

    try {
      await cartService.addToCart(userId, productId);
      await fetchCart(userId);
      return true;
    } catch (e) {
      error = 'Failed to add product to cart';
      notifyListeners();
      return false;
    }
  }

  Future<bool> removeFromCart(int userId, int productId) async {
    error = null;

    try {
      await cartService.removeFromCart(userId, productId);
      await fetchCart(userId);
      return true;
    } catch (e) {
      error = 'Failed to remove product from cart';
      notifyListeners();
      return false;
    }
  }
}