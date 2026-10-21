import 'package:flutter/material.dart';

class Scaffoldexample extends StatelessWidget {
  const Scaffoldexample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: Drawer(),
      appBar: AppBar(
        title: Text('First'),
        backgroundColor: Colors.amber,
      ),
      body: Container(
        color: Colors.blueGrey,
      ),
      floatingActionButton: Container(
        color: Colors.red,
        height: 80,
        width: 80,
      ),
      bottomNavigationBar:
      Container(
        color: Colors.amber,
        height: 80,
      ),
    );
  }
}