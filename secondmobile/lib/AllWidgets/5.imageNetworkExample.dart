import 'package:flutter/material.dart';

class Imagenetworkexample extends StatelessWidget {
  const Imagenetworkexample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Image.network(
          'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-SmX4r9PqcGnGPwacyYSQYLojk85juniI4A&s',
          width: 300,
          height: 200,
        ),
      ),
    );
  }
}