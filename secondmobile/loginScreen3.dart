import 'package:flutter/material.dart';
import 'package:secondmobile/secondmobile/signupscreen.dart';

import 'homeScreen.dart';
import 'data/UserService.dart';

class Loginscreen3 extends StatefulWidget {
  const Loginscreen3({super.key});

  @override
  State<Loginscreen3> createState() => _Loginscreen3State();
}

class _Loginscreen3State extends State<Loginscreen3> {
  final TextEditingController usernamecontroller =
  TextEditingController();

  final TextEditingController passwordcontroller =
  TextEditingController();

  final UserService userService = UserService();

  bool isLoading = false;

  // Login function
  Future<void> login(BuildContext context) async {
    String username = usernamecontroller.text.trim();
    String password = passwordcontroller.text;

    // Check empty fields
    if (username.isEmpty || password.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Please enter username and password'),
        ),
      );
      return;
    }

    // Start loading
    setState(() {
      isLoading = true;
    });

    try {
      // Check username and password using UserService
      bool userFound = await userService.login(username, password);

      if (!context.mounted) return;

      if (userFound) {
        // Navigate to HomeScreen
        Navigator.pushReplacement(
          context,
          MaterialPageRoute(
            builder: (context) => HomeScreen(username),
          ),
        );
      } else {
        // Invalid credentials
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: const Text('Invalid username or password'),
            behavior: SnackBarBehavior.floating,
            duration: const Duration(seconds: 3),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(20),
            ),
            backgroundColor: Colors.amber,
          ),
        );
      }
    } catch (e) {
      if (!context.mounted) return;

      // Connection or login error
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Failed to connect to server'),
          backgroundColor: Colors.red,
        ),
      );
    } finally {
      if (mounted) {
        setState(() {
          isLoading = false;
        });
      }
    }
  }

  @override
  void dispose() {
    usernamecontroller.dispose();
    passwordcontroller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Login'),
        backgroundColor: Colors.indigo,
      ),

      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),

          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,

            children: [
              const SizedBox(height: 50),

              const Icon(
                Icons.person,
                size: 100,
                color: Colors.indigo,
              ),

              const SizedBox(height: 20),

              // Username field
              TextField(
                controller: usernamecontroller,
                decoration: const InputDecoration(
                  labelText: 'Username',
                  border: OutlineInputBorder(),
                  prefixIcon: Icon(Icons.person),
                ),
              ),

              const SizedBox(height: 20),

              // Password field
              TextField(
                controller: passwordcontroller,
                obscureText: true,
                decoration: const InputDecoration(
                  labelText: 'Password',
                  border: OutlineInputBorder(),
                  prefixIcon: Icon(Icons.lock),
                ),
              ),

              const SizedBox(height: 20),

              // Login button
              ElevatedButton(
                onPressed: isLoading ? null : () => login(context),
                child: isLoading
                    ? const SizedBox(
                  width: 24,
                  height: 24,
                  child: CircularProgressIndicator(
                    strokeWidth: 2,
                  ),
                )
                    : const Text('Login'),
              ),

              const SizedBox(height: 20),

              // Navigate to Sign Up
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text("Don't have an account?"),

                  GestureDetector(
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => Signupscreen(),
                        ),
                      );
                    },

                    child: const Text(
                      ' Sign Up',
                      style: TextStyle(
                        decoration: TextDecoration.underline,
                        color: Colors.blue,
                      ),
                    ),
                  ),
                ],
              ),

              const SizedBox(height: 10),

              const Text('Navigate to Forget Password?'),

              // Forget Password
              GestureDetector(
                onTap: () {
                  // Add Forget Password navigation later
                },

                child: const Text(
                  'Forget Password',
                  style: TextStyle(
                    decoration: TextDecoration.underline,
                    color: Colors.blue,
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}