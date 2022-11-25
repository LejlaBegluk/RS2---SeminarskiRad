import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:newsportal/models/Comment.dart';
import 'package:newsportal/services/APIService.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';
class CommentListScreen extends StatelessWidget {
  final int articleId;
  TextEditingController commentController = TextEditingController();
 CommentListScreen({Key? key,required this.articleId}) : super(key: key);
 final _formKey = GlobalKey<FormState>();
  final List<Comment> data = [];
final DateFormat formatter = DateFormat('dd.MM.yyyy');

  @override
  Widget build(BuildContext context) {

    return Scaffold(
        drawer:MenuDrawer(),
        appBar: AppBar(
          title: const Text('Comments'),
          backgroundColor: Colors.grey,
        ),
        body: bodyWidget(),

        floatingActionButton: Visibility(
          visible: APIService.UserId!=null,
          child:FloatingActionButton(
            backgroundColor: Colors.blueGrey,
          child: Icon(Icons.add),
          onPressed: (){showDialog(
                context: context,
                builder: (BuildContext context) {
                  return AlertDialog(
                    content: Stack(
                     // overflow: Overflow.visible,
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
                                   controller: commentController,
                                   decoration: InputDecoration( hintText: "Add a comment"),
                                   validator: (value) {
                                     if(value!.isEmpty) {
                                      return 'Comment can not be empty';
                                       }
                                  },
                                ),
                              ),
                            
                              Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: ElevatedButton(
                               
                                  child: Text("Save"),
                                  onPressed: () {
                                     if (_formKey.currentState!.validate()) {
                                     insertComment(commentController.text);
                                     bodyWidget();
                                      Navigator.pushReplacement(context,MaterialPageRoute(builder:(context)=>CommentListScreen(articleId: articleId)));
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
          ),
          
        );

  }
    Widget bodyWidget() {
    return FutureBuilder<List<Comment>>(
      future: getList(),
      builder: (BuildContext context, AsyncSnapshot<List<Comment>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ListView(
              children: snapshot.data!.map((e) => CommentWidget(e)).toList(),
            );
          }
        }
      },
    );
  }
  Future<List<Comment>> getList() async {
    var comments = await APIService.getComments('Comment',articleId);
    return comments!.map((i) => Comment.fromJson(i)).toList();
  } 

  Widget CommentWidget(item) {
    return Card(
    elevation: 2.0,
    margin: EdgeInsets.only(bottom: 20.0),
    child: Padding(padding: EdgeInsets.all(8.0),
   
    child: Row(children: [
        SizedBox(
          width: 5.0,
        ),
        Expanded(
          
          child: Column(
       
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
               
            children: [
              Text(item.Content,
              style: TextStyle(fontSize: 18.0),),
              SizedBox(height: 5.0,),
              Row(
                children: [
                  Icon(Icons.person),
                  Text(item.Username,
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
  
  
  );
}
 
  insertComment(String Content) async {
    var request = Comment(
      UserId: APIService.UserId?.toInt() ?? 0,
      Content: Content,
      ArticleId: articleId,
      
    );

    await APIService.post("Comment", json.encode(request.toJson()));
  }
}
