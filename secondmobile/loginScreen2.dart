

import 'dart:convert';

import 'package:secondmobile/secondmobile/signupscreen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import 'homeScreen.dart';


class Loginscreen2 extends StatelessWidget {
  Loginscreen2({super.key});

  TextEditingController usernamecontroller = TextEditingController();
  TextEditingController passwordcontroller = TextEditingController();

  //تحميل ملف Json من داخل فولدر Data
  Future<List<dynamic>> loadUsers() async {
    String JsonString = await rootBundle.loadString('lib/App1/data/users.json');
    return json.decode(JsonString);
  }

  void login(BuildContext context) async {
    final users = await loadUsers();

    String username = usernamecontroller.text;
    String password = passwordcontroller.text;

    bool userFound = users.any(
            (user) => user['username'] == username && user['password'] == password);

    if (userFound) {
      Navigator.push(
        context,
        MaterialPageRoute(
          builder: (context) => HomeScreen(username),
        ),
      );
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: const Text('Invalid username or password'),
          behavior: SnackBarBehavior.floating,
          duration: const Duration(seconds: 3),
          // margin: const EdgeInsets.only(bottom: 700),
          shape: OutlineInputBorder(borderRadius: BorderRadius.circular(20)),
          backgroundColor: Colors.black38,
        ),
      );
    }
  }




  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Login '),
        backgroundColor: Colors.indigo,
      ),
      body: Padding(padding: EdgeInsets.all(16,),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            const SizedBox(height: 50,),
            const Icon(Icons.person, size: 100, color: Colors.indigo),
            TextField(
              controller: usernamecontroller,
              decoration: const InputDecoration(
                labelText: 'Username',
                border: const OutlineInputBorder(),
                prefixIcon: const Icon(Icons.person),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            TextField(
              controller: passwordcontroller,
              obscureText: true,
              decoration: const InputDecoration(
                labelText: 'Password',
                border: const OutlineInputBorder(),
                prefixIcon: const Icon(Icons.lock),
              ),
            ),
            const SizedBox(
              height: 20,
            ),

            ElevatedButton(
              onPressed:()=> login(context),
              child: const Text('Login'),
            ),
            const SizedBox(
              height: 20,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text('Dont have an account?'),
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => Signupscreen(),
                        ));
                  },
                  child: const Text(
                    ' Sign Up',
                    style: TextStyle(
                        decoration: TextDecoration.underline,
                        color: Colors.blue),
                  ),
                ),


              ],
            ),
            const SizedBox(
              height: 10,
            ),
            const Text('Navigate to Forget Password?'),
            GestureDetector(
              onTap: () {},
              child: const Text(
                'Fofget Password',
                style: TextStyle(
                    decoration: TextDecoration.underline, color: Colors.blue),
              ),
            ),


          ],
        ),
      ),
    );
  }
}