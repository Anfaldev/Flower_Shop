
import 'package:flutter/material.dart';
import 'cartScreen.dart';
import 'myOrdersScreen.dart';
import 'productsScreen.dart';

class HomeScreen extends StatelessWidget {
  HomeScreen(this.username,this.userId,this.Email, {super.key});

  String username;
  final int userId ;
  String Email;

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
              accountEmail:  Text(Email),
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

            // Products
            ListTile(
              leading: const Icon(Icons.shopping_cart),
              title: const Text('Products'),
              onTap: () {
                Navigator.pop(context);

                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) =>
                        ProductsScreen(userId),
                  ),
                );
              },
            ),


            ListTile(
              leading: const Icon(Icons.shopping_cart),
              title: const Text('My Cart'),
              onTap: () {
                Navigator.pop(context);

                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => CartScreen(userId),
                  ),
                );
              },
            ),




            ListTile(
              leading: const Icon(Icons.shopping_bag),
              title: const Text('My Orders'),
              onTap: () {
                Navigator.pop(context);

                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => MyOrdersScreen(userId),
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