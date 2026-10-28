import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/orderProvider.dart';

class OrdersScreen extends StatefulWidget {
  final int userId;

  const OrdersScreen(this.userId, {super.key});

  @override
  State<OrdersScreen> createState() => _OrdersScreenState();
}

class _OrdersScreenState extends State<OrdersScreen> {
  @override
  void initState() {
    super.initState();

    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<OrderProvider>().fetchMyOrders(widget.userId);
    });
  }

  Future<void> refreshOrders() async {
    await context.read<OrderProvider>().fetchMyOrders(widget.userId);
  }

  void showOrderDetails(BuildContext context, dynamic order) {
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
                    'Order #${order['id'] ?? 'N/A'} Details',
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
      body: Consumer<OrderProvider>(
        builder: (context, provider, child) {
          if (provider.isLoading && provider.orders.isEmpty) {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }

          if (provider.error != null && provider.orders.isEmpty) {
            return Center(
              child: Text('Error: ${provider.error}'),
            );
          }

          if (provider.orders.isEmpty) {
            return RefreshIndicator(
              onRefresh: refreshOrders,
              child: ListView(
                physics: const AlwaysScrollableScrollPhysics(),
                children: const [
                  SizedBox(height: 250),
                  Center(
                    child: Text('No Orders Found'),
                  ),
                ],
              ),
            );
          }

          return RefreshIndicator(
            onRefresh: refreshOrders,
            child: ListView.builder(
              physics: const AlwaysScrollableScrollPhysics(),
              padding: const EdgeInsets.all(10),
              itemCount: provider.orders.length,
              itemBuilder: (context, index) {
                final order = provider.orders[index];

                return Card(
                  margin: const EdgeInsets.only(bottom: 12),
                  child: ListTile(
                    contentPadding: const EdgeInsets.all(16),
                    leading: const CircleAvatar(
                      child: Icon(Icons.receipt_long),
                    ),
                    title: Text(
                      'Order #${order['id'] ?? 'N/A'}',
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
                    trailing: const Icon(Icons.chevron_right),
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