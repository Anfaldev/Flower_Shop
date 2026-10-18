import 'package:flutter/material.dart';
import 'categoryScreen.dart';
import 'productsScreen.dart';

class HomeScreen extends StatelessWidget {
  HomeScreen(this.username, {super.key});

  final String username;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.green,
        title: const Text('Home Page'),
      ),

      // Drawer
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            UserAccountsDrawerHeader(
              accountName: Text(username),
              accountEmail: const Text('Welcome to our App'),
              currentAccountPicture: const CircleAvatar(
                child: Icon(Icons.person, size: 40),
              ),
              decoration: const BoxDecoration(
                color: Colors.green,
              ),
            ),

            // Home
            ListTile(
              leading: const Icon(Icons.home),
              title: const Text('Home'),
              onTap: () {
                Navigator.pop(context);
              },
            ),

            // Categories
            ListTile(
              leading: const Icon(Icons.category),
              title: const Text('Categories'),
              onTap: () {
                Navigator.pop(context);

                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => const CategoryScreen(),
                  ),
                );
              },
            ),

            ListTile(
              leading: const Icon(Icons.shopping_cart),
              title: const Text('Products'),
              onTap: () {
                Navigator.pop(context);

                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => const ProductsScreen(),
                  ),
                );
              },
            ),


            const Divider(),

            // Logout
            ListTile(
              leading: const Icon(
                Icons.logout,
                color: Colors.red,
              ),
              title: const Text('Logout'),
              onTap: () {
                Navigator.pop(context);

                Navigator.pushNamedAndRemoveUntil(
                  context,
                  '/',
                      (route) => false,
                );
              },
            ),
          ],
        ),
      ),

      body: Center(
        child: Text(
          'Welcome Ya $username',
          style: const TextStyle(fontSize: 20),
        ),
      ),
    );
  }
}