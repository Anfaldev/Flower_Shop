import 'package:flutter/material.dart';

class Statefullexample extends StatefulWidget {
  const Statefullexample({super.key});

  @override
  State<Statefullexample> createState() => _StatefullexampleState();
}

class _StatefullexampleState extends State<Statefullexample> {
  int counter = 1;

  void incrementCounter(){
    setState(() {
      counter++;
    });
  }

  void decrementCounter(){
    setState(() {
      counter--;
    });
  }


  @override
  void initState() {
    // TODO: implement initState
    super.initState();
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('StatFullWidget'),
        backgroundColor: Colors.blue,
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text('Counter Value: ',
              style: TextStyle(
                  fontSize: 20
              ),
            ),
            Text('$counter',
              style: TextStyle(
                  fontSize: 20
              ),
            ),

            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                ElevatedButton(onPressed: incrementCounter, child: Text('+')),
                SizedBox(
                  width: 20,
                ),
                ElevatedButton(onPressed:decrementCounter,
                    child: Text('-'))
              ],
            )
          ],
        ),
      ),
    );
  }
}