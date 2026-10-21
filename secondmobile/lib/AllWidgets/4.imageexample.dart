import 'package:flutter/material.dart';

class ImageExample extends StatelessWidget {
  const ImageExample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Image.asset(
          'assets/Images/dice-1.png',
          width: 250,
          height: 200,
          //color: Colors.red,
        ),
      ),
    );
  }
}