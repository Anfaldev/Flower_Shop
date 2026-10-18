

import 'package:secondmobile/secondmobile/signupscreen.dart';
import 'package:flutter/material.dart';

class Loginscreen extends StatelessWidget {
  Loginscreen({super.key});

  TextEditingController usernamecontroller = TextEditingController();
  TextEditingController passwordcontroller = TextEditingController();

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
              onPressed: () {
                String user = usernamecontroller.text;
                String pass = passwordcontroller.text;
                print('Username: $user');
                print('Password: $pass');
              },
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