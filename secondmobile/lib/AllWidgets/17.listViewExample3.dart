import 'package:flutter/material.dart';

class Listviewexample3 extends StatelessWidget {
  Listviewexample3({super.key});

  final List<String> items =
  List<String>.generate(10, (index) => "Item ${index + 1}");

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('ListView Example'),
        backgroundColor: Colors.blue,
      ),
      body: ListView.builder(
          itemCount: items.length,
          itemBuilder: (context, index) {
            return Card(
              elevation: 7,
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(20)),
              child: ListTile(
                leading: const Icon(
                  Icons.label,
                  color: Colors.blue,
                ),
                title: Text(items[index]),
                subtitle: Text(items[index]),
                trailing: const Icon(Icons.video_label_outlined),
                tileColor: Colors.amber,
                shape:
                OutlineInputBorder(borderRadius: BorderRadius.circular(20)),
              ),
            );
          }),
    );
  }
}