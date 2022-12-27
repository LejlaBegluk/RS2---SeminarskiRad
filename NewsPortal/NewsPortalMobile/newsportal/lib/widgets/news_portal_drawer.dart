// ignore_for_file: prefer_const_constructors, non_constant_identifier_names

import 'package:flutter/material.dart';
import 'package:newsportal/models/Category.dart';
import 'package:newsportal/pages/article_list_screen.dart';
import 'package:newsportal/pages/home.dart';
import 'package:newsportal/pages/login.dart';
import 'package:newsportal/pages/paid_article_list.dart';
import 'package:newsportal/pages/poll_list_screen.dart';
import 'package:newsportal/pages/profile.dart';
import 'package:newsportal/services/APIService.dart';
//import '../pages/login_screen.dart';
class MenuDrawer extends StatelessWidget {
  const MenuDrawer({ Key? key }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: buildMenuItems(context),
      ),
    );
  }
  List<Widget>buildMenuItems(BuildContext context){

    final List<String> menuTitles=[
      'Home',
      'Sport',
      'Buisness',
      'Sponsored',
      'Poll'
    ];
    if(APIService.UserId!=null){
      menuTitles.add("Paid articles");
      menuTitles.add("Profile");
      menuTitles.add("Logout");


    }
    else{
      menuTitles.add("Login");
    }
    List<Widget> menuItems=[];
    menuItems.add(DrawerHeader(
      decoration: BoxDecoration(color:Colors.blueGrey),
      child: Text('News.com',style: TextStyle(color:Colors.white,fontSize: 28),),));
    for (var element in menuTitles) { 
      Widget screen=Container();
      menuItems.add(ListTile(
          title: Text(element,style: TextStyle(fontSize: 18),),
          onTap: (){
            switch(element){
       
            case 'Home' :
              screen=Home();
              break;
            case 'Sport' :
              screen=ArticleListScreen(categoryId:Category.sport.index);
              break;
               case 'Buisness' :
              screen=ArticleListScreen(categoryId:Category.buisness.index);
             break;
              case 'Sponsored' :
              screen=ArticleListScreen(categoryId:Category.sponsored.index);
             break;
              case 'Poll' :
              screen=PollListScreen();
             break;
               case 'Login' :
              screen=Login(); 
              break;
                case 'Logout' :
                Logout ();
              screen=Home(); 
              break;
               case 'Paid articles' :
              screen=PaidArticleListScreen(); 
                  break;
               case 'Profile' :
              screen=Profil(); 
                  break;
            }
            Navigator.of(context).pop();
            Navigator.of(context).push(
            MaterialPageRoute(builder: (context)=>screen));
          },
        
      ));
    }
return menuItems;
  }

}
void Logout (){
  APIService.UserId=null;
  APIService.password=null;
  APIService.username=null;
}