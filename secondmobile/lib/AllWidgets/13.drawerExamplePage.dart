import 'package:flutter/material.dart';

class DrawerExamplePage extends StatelessWidget {
  const DrawerExamplePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      // السحب من اليسار
      drawer: Drawer(
        child: Column(
          children: [
            // الهيدر العلوي
            const UserAccountsDrawerHeader(
              accountName: Text('Mohamed Alswaify'),
              accountEmail: Text('alswaify@example.com'),
              currentAccountPicture: CircleAvatar(
                backgroundColor: Colors.white,
                child: Text(
                  'M',
                  style: TextStyle(
                    fontSize: 24,
                    color: Colors.blue,
                  ),
                ),
              ),
              decoration: BoxDecoration(
                color: Colors.blue,
              ),
            ),

            // عناصر القائمة
            ListTile(
              leading: const Icon(Icons.home),
              title: const Text('Home'),
              subtitle: const Text('Go to Home screen'),
              trailing: Icon(Icons.arrow_forward_ios),
              onTap: () {
                Navigator.pop(context); // يقفل الـ Drawer
                // هنا تقدر تروح لصفحة ثانية
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => const HomeScreen(),
                  ),
                );
              },
            ),

            ListTile(
              leading: const Icon(Icons.person),
              title: const Text('Profile'),
              onTap: () {
                Navigator.pop(context);
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => const ProfileScreen(),
                  ),
                );
              },
            ),

            const Divider(), // خط فاصل

            ListTile(
              leading: const Icon(Icons.settings),
              title: const Text('Settings'),
              onTap: () {
                Navigator.pop(context);
                print('Settings tapped');
              },
            ),

            const Spacer(),

            // زر تسجيل الخروج في الأسفل
            ListTile(
              leading: const Icon(Icons.logout, color: Colors.red),
              title: const Text(
                'Logout',
                style: const TextStyle(color: Colors.red),
              ),
              onTap: () {
                Navigator.pop(context);
                print('Logout tapped');
              },
            ),
          ],
        ),
      ),

      // للسحب من اليمين (مفيد للغة العربية)
      endDrawer: Drawer(
        child: SafeArea(
          child: Column(
            children: [
              const ListTile(
                title: Text(
                  'القائمة الجانبية (يمين)',
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                ),
              ),
              const Divider(),
              ListTile(
                leading: const Icon(Icons.info),
                title: const Text('عن التطبيق'),
                onTap: () {
                  Navigator.pop(context);
                  print('About tapped');
                },
              ),
            ],
          ),
        ),
      ),

      appBar: AppBar(
        title: const Text('Drawer Demo'),
        backgroundColor: Colors.blue,
        // لو تبي تفتح endDrawer بزر في الـ AppBar
        actions: [
          Builder(
            builder: (context) => IconButton(
              icon: const Icon(Icons.menu_open),
              onPressed: () {
                Scaffold.of(context).openEndDrawer(); // يفتح الـ endDrawer
              },
            ),
          ),
        ],
      ),

      body: const Center(
        child: Text(
          'اسحب من اليسار لفتح الـ Drawer\nواسحب من اليمين لفتح الـ endDrawer',
          textAlign: TextAlign.center,
          style: TextStyle(fontSize: 18),
        ),
      ),
    );
  }
}







// صفحة Home
class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Home Screen'),
        backgroundColor: Colors.green,
      ),
      body: const Center(
        child: const Text(
          'Welcome Home 👋',
          style: const TextStyle(fontSize: 22),
        ),
      ),
    );
  }
}

// صفحة Profile
class ProfileScreen extends StatelessWidget {
  const ProfileScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('My Profile'),
        backgroundColor: Colors.deepPurple,
      ),
      body: const Center(
        child: const Text(
          'This is Profile Page',
          style: const TextStyle(fontSize: 22),
        ),
      ),
    );
  }
}