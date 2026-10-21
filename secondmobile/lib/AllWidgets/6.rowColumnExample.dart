import 'package:flutter/material.dart';

class Rowcolumnexample extends StatelessWidget {
  const Rowcolumnexample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Row & Column Example'),
          backgroundColor: Colors.blue,
        ),
        body:Column(
          //mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Text('Row:'),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Icon(Icons.person,color: Colors.amber,size: 60,),
                Icon(Icons.apple),
                Icon(Icons.bookmark_add),
                Icon(Icons.update),
              ],
            ),
            SizedBox(
              height: 50,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Icon(Icons.person,color: Colors.amber,size: 60,),
                Icon(Icons.apple),
                Icon(Icons.bookmark_add),
                Icon(Icons.update),
              ],
            ),
            SizedBox(
              height: 50,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Icon(Icons.person,color: Colors.amber,size: 60,),
                Icon(Icons.apple),
                Icon(Icons.bookmark_add),
                Icon(Icons.update),
              ],
            ),
            SizedBox(
              height: 50,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Icon(Icons.person,color: Colors.amber,size: 60,),
                Icon(Icons.apple),
                Icon(Icons.bookmark_add),
                Icon(Icons.update),
              ],
            ),

            Container(
              padding: EdgeInsets.all(30),
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.all(Radius.circular(20)),
                  border: Border.all(color: Colors.blue,style: BorderStyle.solid)
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Text('data'),
                  Text('data'),
                  Text('data'),
                  Text('data'),

                ],
              ),
            ),

            Container(
              padding: EdgeInsets.all(30),
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.all(Radius.circular(20)),
                  border: Border.all(color: Colors.blue,style: BorderStyle.solid)
              ),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Text('data'),
                  Text('data'),
                  Text('data'),
                  Text('data'),

                ],
              ),
            ),




          ],
        ) );
  }
}