
import 'package:flutter/material.dart';
import 'data/OrderService.dart';

class MyOrdersScreen extends StatefulWidget {
final int userId;

const MyOrdersScreen(this.userId, {super.key});

@override
State<MyOrdersScreen> createState() => _MyOrdersScreenState();
}

class _MyOrdersScreenState extends State<MyOrdersScreen> {
final OrderService orderService = OrderService();

late Future<List<dynamic>> orders;

@override
void initState() {
super.initState();
loadOrders();
}

void loadOrders() {
orders = orderService.getMyOrders(widget.userId);
}

Future<void> refreshOrders() async {
setState(() {
loadOrders();
});

await orders;
}

void showOrderDetails(
BuildContext context,
dynamic order,
) {
final products = order['items'] as List? ?? [];

showModalBottomSheet(
context: context,
isScrollControlled: true,
showDragHandle: true,
builder: (context) {
return SafeArea(
child: DraggableScrollableSheet(
expand: false,
initialChildSize: 0.75,
minChildSize: 0.4,
maxChildSize: 0.95,
builder: (context, scrollController) {
return ListView(
controller: scrollController,
padding: const EdgeInsets.all(20),
children: [
Text(
'Order #${order['id']} Details',
style: const TextStyle(
fontSize: 23,
fontWeight: FontWeight.bold,
),
),
const SizedBox(height: 16),
Text('Date: ${order['createdAt'] ?? 'N/A'}'),
const SizedBox(height: 8),
Text('Status: ${order['status'] ?? 'N/A'}'),
const SizedBox(height: 8),
Text(
'Total: ${order['totalAmount'] ?? 0} SAR',
style: const TextStyle(
fontSize: 18,
fontWeight: FontWeight.bold,
color: Colors.green,
),
),
const Divider(height: 30),
const Text(
'Products',
style: TextStyle(
fontSize: 19,
fontWeight: FontWeight.bold,
),
),
const SizedBox(height: 10),
if (products.isEmpty)
const Text('No products found in this order')
else
...products.map<Widget>((product) {
return ListTile(
contentPadding: EdgeInsets.zero,
title: Text(
product['name']?.toString() ??
'Unnamed Product',
),
subtitle: Text(
'Quantity: ${product['quantity'] ?? 0}',
),
trailing: Text(
'${product['price'] ?? 0} SAR',
),
);
}),
],
);
},
),
);
},
);
}

@override
Widget build(BuildContext context) {
return Scaffold(
appBar: AppBar(
title: const Text('My Orders'),
backgroundColor: Colors.indigo,
),
body: FutureBuilder<List<dynamic>>(
future: orders,
builder: (context, snapshot) {
if (snapshot.connectionState == ConnectionState.waiting) {
return const Center(
child: CircularProgressIndicator(),
);
}

if (snapshot.hasError) {
return Center(
child: Text('Error: ${snapshot.error}'),
);
}

final items = snapshot.data ?? [];

if (items.isEmpty) {
return const Center(
child: Text('No Orders Found'),
);
}

return RefreshIndicator(
onRefresh: refreshOrders,
child: ListView.builder(
physics: const AlwaysScrollableScrollPhysics(),
padding: const EdgeInsets.all(10),
itemCount: items.length,
itemBuilder: (context, index) {
final order = items[index];

return Card(
margin: const EdgeInsets.only(bottom: 12),
child: ListTile(
contentPadding: const EdgeInsets.all(16),
leading: const CircleAvatar(
child: Icon(Icons.receipt_long),
),
title: Text(
'Order #${order['id']}',
style: const TextStyle(
fontWeight: FontWeight.bold,
fontSize: 18,
),
),
subtitle: Padding(
padding: const EdgeInsets.only(top: 8),
child: Column(
crossAxisAlignment: CrossAxisAlignment.start,
children: [
Text(
'Status: ${order['status'] ?? 'N/A'}',
),
const SizedBox(height: 4),
Text(
'Total: ${order['totalAmount'] ?? 0} SAR',
),
],
),
),
trailing: const Icon(
Icons.chevron_right,
),
onTap: () {
showOrderDetails(context, order);
},
),
);
},
),
);
},
),
);
}
}