import 'dart:convert';
import 'package:http/http.dart' as http;

class UserService {

  Future<bool> login(String username, String password) async {

    final response = await http.post(
      Uri.parse('http://localhost:5004/api/Users/login'),

      headers: {
        'Content-Type': 'application/json',
      },

      body: json.encode({
        'username': username,
        'password': password,
      }),
    );

    if (response.statusCode == 200) {
      return true;
    } else if (response.statusCode == 401) {
      return false;
    } else {
      throw Exception('Failed to login');
    }
  }


  Future<bool> register(
      String name,
      String email,
      String username,
      String password
      ) async {

    final response = await http.post(
      Uri.parse('http://localhost:5004/api/Users/register'),

      headers: {
        'Content-Type': 'application/json',
      },

      body: json.encode({
        'name': name,
        'email': email,
        'username': username,
        'password': password,
      }),
    );

    if (response.statusCode == 200) {
      return true;
    } else if (response.statusCode == 409) {
      return false;
    } else {
      throw Exception('Registration failed: ${response.body}');
    }
  }





}