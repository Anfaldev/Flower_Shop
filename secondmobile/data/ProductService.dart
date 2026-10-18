import 'dart:convert';
import 'package:http/http.dart' as http;

class ProductService {
  final String baseUrl =
      'http://localhost:8081/api/Products';

  // Get all products
  Future<List<dynamic>> getAllProducts() async {
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {
        'Content-Type': 'application/json',
      },
    );

    if (response.statusCode == 200) {
      return json.decode(response.body) as List<dynamic>;
    } else {
      throw Exception(
        'Failed to load products: ${response.statusCode}',
      );
    }
  }

  // Get product by ID
  Future<Map<String, dynamic>> getProductById(int id) async {
    final response = await http.get(
      Uri.parse('$baseUrl/$id'),
      headers: {
        'Content-Type': 'application/json',
      },
    );

    if (response.statusCode == 200) {
      return json.decode(response.body) as Map<String, dynamic>;
    } else {
      throw Exception(
        'Failed to load product: ${response.statusCode}',
      );
    }
  }

  // Get product by UID
  Future<Map<String, dynamic>> getProductByUid(String uid) async {
    final response = await http.get(
      Uri.parse('$baseUrl/uid/${Uri.encodeComponent(uid)}'),
      headers: {
        'Content-Type': 'application/json',
      },
    );

    if (response.statusCode == 200) {
      return json.decode(response.body) as Map<String, dynamic>;
    } else {
      throw Exception(
        'Failed to load product: ${response.statusCode}',
      );
    }
  }
}