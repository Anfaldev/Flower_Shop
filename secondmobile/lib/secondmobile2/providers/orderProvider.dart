import 'package:flutter/material.dart';

import '../data/orderService.dart';

class OrderProvider extends ChangeNotifier {
  final OrderService orderService = OrderService();

  List<dynamic> orders = [];
  bool isLoading = false;
  bool isCreatingOrder = false;
  String? error;
  int? lastOrderId;

  Future<bool> makeOrder(int userId) async {
    isCreatingOrder = true;
    error = null;
    lastOrderId = null;
    notifyListeners();

    try {
      lastOrderId = await orderService.makeOrder(userId);
      return true;
    } catch (e) {
      error = 'Failed to create order';
      return false;
    } finally {
      isCreatingOrder = false;
      notifyListeners();
    }
  }

  Future<void> fetchMyOrders(int userId) async {
    isLoading = true;
    error = null;
    notifyListeners();

    try {
      orders = await orderService.getMyOrders(userId);
    } catch (e) {
      error = 'Failed to load orders';
    } finally {
      isLoading = false;
      notifyListeners();
    }
  }
}