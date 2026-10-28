
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'connection.dart';

class OrderService {

  // Make Order
  Future<int?> makeOrder(int userId) async {
    final response = await http.post(
      Uri.parse('${ConnectionString.orders}/$userId'),
    );

    if (response.statusCode == 200 || response.statusCode == 201) {
      // The API may confirm order creation without returning an order ID.
      if (response.body.trim().isEmpty) return null;

      final decoded = jsonDecode(response.body);
      if (decoded is num) return decoded.toInt();
      if (decoded is Map) {
        final rawId = decoded['orderId'] ?? decoded['id'];
        if (rawId is num) return rawId.toInt();
        if (rawId is String) return int.tryParse(rawId);
      }
      return null;
    }

    throw Exception('Failed to create order: ${response.body}');
  }

  // Get My Orders
  Future<List<dynamic>> getMyOrders(int userId) async {
    final response = await http.get(
      Uri.parse('${ConnectionString.orders}/user/$userId'),
    );

    if (response.statusCode == 200) {
      return jsonDecode(response.body) as List<dynamic>;
    }

    throw Exception('Failed to load orders');
  }
}