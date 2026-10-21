import 'package:flutter/material.dart';

class ContainerExample extends StatelessWidget {
  const ContainerExample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Hello with padding and Margin'),
        backgroundColor: Colors.blue,
      ),
      body: Container(
        padding: EdgeInsets.symmetric(horizontal: 50,vertical: 50),
        //  padding: EdgeInsets.only(top: 100,left: 80),
        margin: EdgeInsets.only(top: 200,),
        decoration:BoxDecoration(
            color: Colors.black,
            borderRadius: BorderRadius.circular(50)
        ) ,
        child: Text('Hello with padding and Margin',style: TextStyle(
            fontSize: 20,
            color: Colors.blue
        ),),
      ),


    );
  }
}