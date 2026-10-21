import 'package:flutter/material.dart';

class Textexample extends StatelessWidget {
  const Textexample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Center(
          child: Text('Text Example'),
        ),
        backgroundColor: Colors.blue,
      ),
      body:  Center(
        child: Text(
          'Welcome',
          style: TextStyle(
            color: Colors.blue,
            fontSize: 40,
            fontWeight: FontWeight.bold,
          ),
        ),
      ),
    );
  }
}