import 'package:flutter/material.dart';

class BoxDecorationExample extends StatelessWidget {
  const BoxDecorationExample({super.key});

  // Flutter فيه 3 أنواع رئيسية من التدرجات:
  //
  // LinearGradient → تدرج خطي (من نقطة إلى نقطة).
  //
  // RadialGradient → تدرج شعاعي (دائري من المركز للخارج).
  //
  // SweepGradient → تدرج دائري على شكل دوران حول المركز (زاوي).

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blue,
        title: const Center(child: Text('Container Example')),
      ),
      body: Center(
        child: Container(
          width: 200,
          height: 100,
          decoration: BoxDecoration(
              color: Colors.blue,
              borderRadius: BorderRadius.circular(20),
              gradient: const SweepGradient(
                colors: [
                  Colors.blue,
                  Colors.green,
                  Colors.red,
                  Colors.green,
                ],
              ),
              image: const DecorationImage(
                image: AssetImage('assets/Images/dice-1.png'),
                fit: BoxFit.fill,
                opacity: 0.2,
              ),
              border: Border.all(width: 5.0, color: Colors.black),
              boxShadow: const [
                BoxShadow(
                  color: Colors.red,
                  blurRadius: 10.0,
                  offset: Offset(7, 7),
                ),
                BoxShadow(
                  color: Colors.red,
                  blurRadius: 10.0,
                  offset: Offset(-7, -7),
                ),
              ],
              shape: BoxShape.rectangle),
          child: const Center(
            child: Text(
              'Inside Container',
              style: TextStyle(color: Colors.white),
            ),
          ),
        ),
      ),
    );
  }
}