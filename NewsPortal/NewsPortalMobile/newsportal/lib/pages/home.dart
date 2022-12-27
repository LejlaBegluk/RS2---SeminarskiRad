// ignore_for_file: prefer_const_constructors, unused_field, prefer_final_fields, prefer_typing_uninitialized_variables, unused_import, import_of_legacy_library_into_null_safe, avoid_unnecessary_containers, depend_on_referenced_packages, library_private_types_in_public_api, non_constant_identifier_names
////////////////// https://www.youtube.com/watch?v=VWLWjAJT9Vs      16:00
import 'dart:typed_data';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:newsportal/models/Article.dart';
import 'package:newsportal/pages/article_detail.dart';
import 'package:newsportal/services/APIService.dart';
import 'package:newsportal/utils/util.dart';
import '../widgets/news_portal_drawer.dart';
void main() {
  runApp(const Home());
}

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);
  @override
  _HomeState createState() => _HomeState();
}
class _HomeState extends State<Home> with SingleTickerProviderStateMixin {
final DateFormat formatter = DateFormat('dd.MM.yyyy');
 //Article? recommended;
  @override
  void initState(){
    super.initState();
  }
   @override
   void dispose(){
     super.dispose();

   }
  @override
  Widget build(BuildContext context) {

    return Scaffold(
        drawer:MenuDrawer(),
        appBar: AppBar(
          title: const Text('Home'),
          backgroundColor: Colors.grey,
        ),
        body: bodyWidget());

  }
    Widget bodyWidget() {
    return FutureBuilder<List<Article>>(
      future: getList(),
      builder: (BuildContext context, AsyncSnapshot<List<Article>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ListView(
              children: snapshot.data!.map((e) => ArticleWidget(e)).toList(),
            );
          }
        }
      },
    );
  }
  Future<List<Article>> getList() async {
    var articles = await APIService.Get('Article', null);
    if(articles!=null){
    return articles.map((i) => Article.fromJson(i)).toList();
    }
    return <Article>[];
  } 

  Widget ArticleWidget(item) {
    return GestureDetector(
      child:Card(
    elevation: 2.0,
    margin: EdgeInsets.only(bottom: 20.0),
    child: Padding(padding: EdgeInsets.all(8.0),
   
    child: Row(children: [
      
         item.Photo.isNotEmpty
                ? SizedBox(
                    height: 50,
                    width: 50,
                    child: imageFromBase64String(item.Photo!),
                  )
                : SizedBox(
                  height: 50,
                    width: 50,
                 child: Image(
                      image: AssetImage('assets/images/news.jpg'),
                ),
                ),
        SizedBox(
          width: 5.0,
        ),
        Expanded(
          
          child: Column(
       
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
               
            children: [
              Text(item.Title,
              style: TextStyle(fontSize: 18.0),),
              SizedBox(height: 5.0,),
              Row(
                children: [
                  Icon(Icons.person),
                  Text(item.Author,
                  style: TextStyle(fontSize: 12.0),
                  ),
                  SizedBox(width: 10.0,),
                   Icon(Icons.calendar_month),
                  Text(formatter.format(item.Date).toString(),
                  style: TextStyle(fontSize: 12.0),
                  ),
                  SizedBox(width: 10.0,),
                    Padding(
          padding: const EdgeInsets.all(5),
              )],
              )
            ],
          ),
        )
    ]
    ),
    ),
  
  
  ),
  onTap:(){
          Navigator.push(context, MaterialPageRoute(builder: (context)=>ArticleDetailScreen(item: item, tag: item.Title)));
          }
);
}

}
