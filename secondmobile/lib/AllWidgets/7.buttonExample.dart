import 'package:flutter/material.dart';

class Buttonexample extends StatelessWidget {
  const Buttonexample({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Button Example'),
        backgroundColor: Colors.blue,
      ),
      body: Column(
//mainAxisAlignment: MainAxisAlignment.center,
//crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          ElevatedButton(onPressed: (){}, child: Text('Elevated Button')),
          const SizedBox(height: 10,),
          TextButton(onPressed:(){}, child: Text('Text Button')),
          const SizedBox(height: 10,),
          OutlinedButton(onPressed: (){}, child: Text('Outlined Button')),
          const SizedBox(height: 10,),

          ElevatedButton(onPressed: (){}, child: Icon(Icons.add_box_rounded)),
          const SizedBox(height: 10,),
          ElevatedButton(onPressed: (){}, child: SizedBox(
            width: 100,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Icon(Icons.add_box_rounded),
                const SizedBox(width: 10,),
                Text('Add')
              ],
            ),
          )
          ),
          const SizedBox(
            height: 10,
          ),
          GestureDetector(
            onTap: (){
              print('Tapped!');
            },
            onLongPress: (){
              print('Long Press!');
            },
            onDoubleTap: () {
              print('Double Tap!');
            },
            child: Text('Gesture Detector'),
          ),
          InkWell(
            onTap: (){
              print('InkWell tapped!');
            },
            borderRadius: BorderRadius.circular(8),
            child: Container(
              padding: EdgeInsets.all(16),
              decoration: BoxDecoration(
                color: Colors.amber,
                borderRadius: BorderRadius.circular(8),
              ),
              child: Text( 'InkWell (with ripple)',style: TextStyle(color: Colors.black,),),
            ),
          ),
          InkResponse(
            onTap: (){
              print('InkResponse tapped!');
            },
            radius: 30,
            child: Icon(Icons.favorite,size: 40,color: Colors.red,),
          ),
          GestureDetector(
            onTap: () {
              print('Image tapped');
            },
            child: Image.network(
              'https://picsum.photos/200',
              width: 120,
              height: 120,
            ),
          ),
          Container(
            decoration: BoxDecoration(
                border: Border.all(
                  color: Colors.blue,
                  style: BorderStyle.solid,
                  width: 2,
                ),
                borderRadius: BorderRadius.circular(20)),
            child: ListTile(
              leading: Icon(Icons.person),
              title: Text('Profile') ,
              subtitle:Text('Go to profile page') ,
              trailing: const Icon(Icons.arrow_forward_ios),
              onTap: (){
                print('ListTile tapped!');
              },
            ),
          )
        ],
      ),
      floatingActionButton: FloatingActionButton(onPressed: (){},child: Icon(Icons.add),),

    );
  }
}