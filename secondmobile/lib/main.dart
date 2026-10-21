import 'package:secondmobile/AllWidgets/0scaffoldExample2.dart';
import 'package:flutter/material.dart';
import 'package:secondmobile/secondmobile/categoryScreen.dart';
import 'package:secondmobile/secondmobile/data/CategoryService.dart';
import 'package:secondmobile/secondmobile/loginScreen3.dart';
import 'package:secondmobile/secondmobile/signupscreen.dart';

import 'AllWidgets/0.scaffoldexample.dart';

import 'AllWidgets/18.progressExamplePage.dart';
import 'secondmobile/loginScreen.dart';
import 'secondmobile/loginScreen2.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(

        colorScheme: .fromSeed(seedColor: Colors.deepPurple),
      ),
      home: Loginscreen3(),
      debugShowCheckedModeBanner: false,
    );
  }
}