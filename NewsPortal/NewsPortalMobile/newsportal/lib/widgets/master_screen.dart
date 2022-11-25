import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';

import '../pages/article_list_screen.dart';

//import '../screens/cart/cart_screen.dart';

class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  MasterScreenWidget({this.child, Key? key}) : super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  int currentIndex = 0;

  void _onItemTapped(int index) {
    setState(() {
      currentIndex = index;
    });
    if (currentIndex == 0) {
     // Navigator.pushNamed(context, ArticleListScreen.routeName);
    } else if (currentIndex == 1) {
      //Navigator.pushNamed(context, CartScreen.routeName);
    }

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(),
      drawer: MenuDrawer(),
      body: SafeArea(
        child: widget.child!,
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
            
          ),
         
        ],
        
        selectedItemColor: Colors.amber[800],
        currentIndex: currentIndex,
        onTap: _onItemTapped,
      ),
      
    );
  }
}