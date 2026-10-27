
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'connection.dart';

class ProductService {
  Future<List<Map<String, dynamic>>> getProducts() async {
    final response = await http.get(
      Uri.parse(ConnectionString.products),
    );

    if (response.statusCode == 200) {
      final data = jsonDecode(response.body);

      return List<Map<String, dynamic>>.from(data);
    } else {
      throw Exception('Failed to load products');
    }
  }
}
