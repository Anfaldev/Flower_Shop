

import 'package:flutter/material.dart';
import '9.myTextFormField.dart';

class FormExample3 extends StatelessWidget {
  const FormExample3({super.key});

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
            MyTextFormField(name: "Username"),
            const SizedBox(
              height: 20,
            ),
            MyTextFormField(name:"Password"),
          ],
        ),
        ),
      ),
    );
  }










}