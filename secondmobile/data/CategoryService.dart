import 'dart:convert';
import 'package:http/http.dart' as http;

class CategoryService {
  final String baseUrl =
      'http://localhost:8081/api/Categories';

  Future<List<dynamic>> getAllCategories() async {
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {
        'Content-Type': 'application/json',
      },
    );

    if (response.statusCode == 200) {
      return json.decode(response.body);
    } else {
      throw Exception('Failed to load categories');
    }
  }
}