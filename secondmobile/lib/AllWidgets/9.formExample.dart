import 'package:flutter/material.dart';

class Formexample extends StatelessWidget {
  const Formexample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blue,
        title: const Text('Form Example'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(12.0),
        child: Form(child: Column(
          children: [
            TextFormField(
              decoration: InputDecoration(
                  labelText: "Username"
              ),
              validator: (value){
                if (value == null || value.isEmpty) {
                  return "Please Enter your username";
                }
                return null;
              },
            ),
            const SizedBox(
              height: 20,
            ),
            TextFormField(
              decoration: InputDecoration(
                  labelText: "Password"
              ),
              validator: (value){
                if (value == null || value.isEmpty) {
                  return "Please Enter your username";
                }
                return null;
              },
            ),

          ],
        ),
        ),
      ),
    );
  }
}