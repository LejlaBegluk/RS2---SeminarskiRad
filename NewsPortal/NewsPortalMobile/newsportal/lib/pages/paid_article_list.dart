// ignore_for_file: unused_import, unnecessary_import, prefer_final_fields

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:newsportal/models/PaidArticleStatus.dart';
import 'package:newsportal/pages/paid_article.dart';
import 'package:newsportal/services/APIService.dart';
import 'package:newsportal/utils/util.dart';
import 'package:newsportal/widgets/master_screen.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';
import 'package:provider/provider.dart';

import '../models/PaidArticle.dart';


class PaidArticleListScreen extends StatefulWidget {
  const PaidArticleListScreen({Key? key}) : super(key: key);

  @override
  _PaidArticleListScreenState createState() => _PaidArticleListScreenState();
}

class _PaidArticleListScreenState extends State<PaidArticleListScreen> with SingleTickerProviderStateMixin{
final DateFormat formatter = DateFormat('dd.MM.yyyy');
 final _formKey = GlobalKey<FormState>();
 TextEditingController contentController= TextEditingController();
 TextEditingController titleController= TextEditingController();
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
          backgroundColor: Colors.grey,
        ),
        
        body: bodyWidget(),
        floatingActionButton: Visibility(
          child:FloatingActionButton(
             backgroundColor: Colors.blueGrey,
          child: Icon(Icons.add),
          onPressed: (){showDialog(
                context: context,
                builder: (BuildContext context) {
                  return AlertDialog(
                    content: Stack(
                      children: <Widget>[
                        Positioned(
                          right: -40.0,
                          top: -40.0,
                          child: InkResponse(
                            onTap: () {
                              Navigator.of(context).pop();
                            },
                            child: CircleAvatar(
                              child: Icon(Icons.close),
                              backgroundColor: Colors.red,
                            ),
                          ),
                        ),
                        Form(
                          key: _formKey,
                          child: Column(
                            mainAxisSize: MainAxisSize.min,
                            children: <Widget>[
                              Padding(
                                padding: EdgeInsets.all(8.0),
                                child: TextFormField(
                                   controller: titleController,
                                   decoration: InputDecoration( hintText: "Title"),
                                   validator: (value) {
                                     if(value!.isEmpty) {
                                      return 'Title can not be empty';
                                       }
                                  },
                                ),
                              ),
                              Padding(
                                padding: EdgeInsets.all(8.0),
                                child: TextFormField(
                                   controller: contentController,
                                   decoration: InputDecoration( hintText: "Content"),
                                    keyboardType: TextInputType.multiline,
                                    maxLines: 5,
                                   validator: (value) {
                                     if(value!.isEmpty) {
                                      return 'Content can not be empty';
                                       }
                                  },
                                ),
                              ),
                              Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: ElevatedButton(
                                   style: ElevatedButton.styleFrom(
                                    primary:  Colors.blueGrey),
                                  child: Text("Save"),
                                  onPressed: () {
                                     if (_formKey.currentState!.validate()) {
                                      //_formKey.currentState!.save();
                                     insertPaidArticle(titleController.text,contentController.text);
                                     bodyWidget();
                                      Navigator.pushReplacement(context,MaterialPageRoute(builder:(context)=>PaidArticleListScreen()));

                                    }
                                  },
                                ),
                              )
                            ],
                          ),
                        ),
                      ],
                    ),
                  );
                });},
          )
          )
          );
      
  }
  insertPaidArticle(String Title,String Content) async {
    var request = PaidArticle(
      UserId: APIService.UserId?.toInt() ?? 0,
      Content: Content,
      Title: Title,
      Active:true,
      PaidArticleStatusId:PaidArticleStatus.created.index,
      CreateOn: DateTime.now(),
      Id:0
    );

    await APIService.post("PaidArticle", json.encode(request.toJson()));
  }
    Widget bodyWidget() {
    return FutureBuilder<List<PaidArticle>>(
      future: getList(),
      builder: (BuildContext context, AsyncSnapshot<List<PaidArticle>> snapshot) {
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
   Future<List<PaidArticle>> getList() async {

    var articles = await APIService.Get('PaidArticle',null);
    return articles!.map((i) => PaidArticle.fromJson(i)).toList();
  } 

  Widget ArticleWidget(item) {
    return GestureDetector(
      child:Card(
    elevation: 2.0,
    margin: EdgeInsets.only(bottom: 20.0),
    child: Padding(padding: EdgeInsets.all(8.0),
   
    child: Row(children: [
      
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
                  Icon(Icons.archive),
                  Text(item.PaidArticleStatusName,
                  style: TextStyle(fontSize: 12.0),
                  ),
                  SizedBox(width: 10.0,),
                   Icon(Icons.calendar_month),
                  Text(formatter.format(item.CreateOn).toString(),
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
          Navigator.push(context, MaterialPageRoute(builder: (context)=>PaidArticleForm(item: item, tag: item.Title)));
          }
);
}
}



