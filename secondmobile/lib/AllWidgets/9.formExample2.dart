

import 'package:flutter/material.dart';

class Formexample2 extends StatelessWidget {
  const Formexample2({super.key});

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
            MyTextFormField("Username"),
            const SizedBox(
              height: 20,
            ),
            MyTextFormField("Password"),
          ],
        ),
        ),
      ),
    );
  }




  Widget  MyTextFormField(String name){
    return   TextFormField(
      decoration: InputDecoration(
        labelText: "$name",
        enabledBorder: OutlineInputBorder(
            borderSide: BorderSide(
                color: Colors.blue,
                width: 1
            ),
            borderRadius: BorderRadius.all(Radius.circular(20))

        ),
      ),
      validator: (value){
        if (value == null || value.isEmpty) {
          return "Please Enter your $name";
        }
        return null;
      },
    );



  }





}