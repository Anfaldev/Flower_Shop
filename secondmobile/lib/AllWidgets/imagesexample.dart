import 'package:flutter/material.dart';

class Imageexample extends StatelessWidget {
  const Imageexample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Image.asset(
          'assets/images/IMG_1194.jpg',
          width: 250,
          height: 200,
        ),
      ),
    );
  }
}