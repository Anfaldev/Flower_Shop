import 'package:flutter/material.dart';

class Scaffoldexample2 extends StatelessWidget {
  const Scaffoldexample2({super.key});

  @override
  Widget build(BuildContext context) {
    return Directionality(

      textDirection: TextDirection.rtl,
      child: Scaffold(
        drawer: Drawer(),
        appBar: AppBar(
          title: Text('اول صفحة'),
          backgroundColor: Colors.blue,
        ),
        body: Container(
          //alignment: Alignment.bottomLeft,
          color: Colors.red,
          child: Center(
            child: Text(
              'مرحبا',
              style: TextStyle(color: Colors.white, fontSize: 24),
            ),
          ),
        ),
        floatingActionButton: Container(
          color: Colors.green,
          height: 100,
          width: 100,
          child: Center(child: Text('زر')),
        ),
        bottomNavigationBar: Container(
          color: Colors.amberAccent,
          height: 80,
          child: Center(child: Text('قائمة سفلية')),
        ),
      ),
    );
  }
}