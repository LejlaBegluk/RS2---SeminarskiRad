// ignore_for_file: import_of_legacy_library_into_null_safe, prefer_const_constructors, avoid_unnecessary_containers, depend_on_referenced_packages, avoid_web_libraries_in_flutter, library_private_types_in_public_api, no_leading_underscores_for_local_identifiers, non_constant_identifier_names, unused_local_variable

import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:like_button/like_button.dart';
import 'package:newsportal/models/Article.dart';
import 'package:newsportal/pages/comment_list_screen.dart';
import 'package:newsportal/pages/home.dart';
import 'package:newsportal/services/APIService.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';

class ArticleDetailScreen extends StatefulWidget  {
  final String tag;
  final Article item;
 const ArticleDetailScreen({Key? key,required this.item,required this.tag}) : super(key: key);
 
  @override
  _ArticleDetailScreenState createState() => _ArticleDetailScreenState();
}
class _ArticleDetailScreenState extends State<ArticleDetailScreen> with SingleTickerProviderStateMixin{
   late Article recommended=Article(Title: "", CategoryId: widget.item.CategoryId,Id: 0,Likes: 0,Author: "",Photo: "",Content: "",Date: DateTime.now());

   @override
  void initState(){
        super.initState();
  }
  @override
  void setState(fn) {
    if(mounted) {
      super.setState(fn);
    }
  }
  @override
void dispose() {
  super.dispose();
}
  @override
  Widget build(BuildContext context) {
    Recommended(widget.item.Id);
    final DateFormat formatter = DateFormat('dd.MM.yyyy');
     int numberOfLikes=widget.item.Likes;
     bool _isLiked =  APIService.likedArticles.contains(widget.item.Id);
    return Scaffold(
       drawer:MenuDrawer(),
       appBar: AppBar(
          title: const Text('Article'),
          backgroundColor: Colors.grey,
         
        ),
    body:Container(
      child:Scaffold(
        
        backgroundColor: Colors.white,
        body: Stack(
          children:[
              SingleChildScrollView(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Hero(
                    tag: widget.item.Title,
                    child:
                     Container(
                          margin: const EdgeInsets.only(top: 20.0),
                    height: 200,
                    width: 400,
                    child: widget.item.Photo!.isNotEmpty?
                     Image.memory(
                      Base64Decoder().convert(widget.item.Photo!),
                    // fit: BoxFit.fill,
                      gaplessPlayback: true,
                 
                    ):
                       Image(
                      image: AssetImage('assets/images/news.jpg'),
                ),
                     )
                     ),
                  SizedBox(height: 10.0
                  ),
                  Padding(padding: EdgeInsets.symmetric(horizontal: 8.0),
                  child: Column(
                    children: [
                      Text(
                        widget.item.Title,
                       style: TextStyle(
                         fontSize: 22.0,
                         fontWeight: FontWeight.w500,
                       )
                      ),
                     SizedBox(height: 10.0,),
                     Row(
                       children: [
                         Icon(Icons.person),
                         Text(widget.item.Author.toString(),
                         style: TextStyle(fontSize: 12.0,),
                         ),
                         SizedBox(width: 30.0,),
                          Icon(Icons.calendar_month),
                         Text(formatter.format(widget.item.Date).toString(),
                         style: TextStyle(fontSize: 12.0,),
                         ),
                            SizedBox(width: 30.0,),
                        Center(
                          child:LikeButton(
                            likeCount:numberOfLikes ,
                            isLiked: _isLiked,
                            onTap:onLikeButtonTapped
                        )
                        ),
                       ],
                     ),
                    SizedBox(height: 20.0,),
                    Text(
                      widget.item.Content,
                      style: TextStyle(fontSize: 18.0),
                    ),
                  Row(
                    children: [
                      Container(
                        margin:EdgeInsets.only(top: 20.0),
                        height: 50,
                        width: 340,
                        decoration: BoxDecoration(
                    color: Colors.grey),
                child: TextButton(
                  onPressed: () async {
                    Navigator.push(context, MaterialPageRoute(builder: (context)=>CommentListScreen(articleId: widget.item.Id)));         
                    },
                  child: Text('Komentari',
                      style: TextStyle(color: Colors.white, fontSize: 20)),
                ),
                      )
                    ],

                  ),   
                  Divider(), 
                  SizedBox(height: 10.0,),
                  Text('Recommended',
                      style: TextStyle(color: Colors.blueGrey, fontSize:12)),
         
                  Divider(),

                  Row(children: [
                  SizedBox(height: 20.0,),
                  GestureDetector(
                   child: recommended.Photo!.isNotEmpty
                ? SizedBox(
                    height: 50,
                    width: 50,
                    child: 
                    Image.memory(
                      Base64Decoder().convert(recommended.Photo!),
                     fit: BoxFit.cover,
                      gaplessPlayback: true,
                    ),
                  )
                :SizedBox(
                  height: 50,
                    width: 50,
                 child: Image(
                      image: AssetImage('assets/images/news.jpg'),
                ),
                ),
                onTap:(){
              Navigator.push(context, MaterialPageRoute(builder: (context)=>ArticleDetailScreen(item: recommended, tag: recommended.Title)
              )
              );
          }
          ),
        SizedBox(
          width: 5.0,
        ),
        Expanded(
          
          child: Column(
       
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
               
            children: [
              Text(recommended.Title,
              style: TextStyle(fontSize: 18.0),),
              SizedBox(height: 5.0,),
            ],
          ),
        )
    ]
    ),
                    ],
                    
                  ),
                  )
                ],
              ),
              ),
              Padding(padding: EdgeInsets.only(top:12.0),
                child: IconButton(
                  onPressed: (){
                    if (mounted) {
                      Navigator.push(context,MaterialPageRoute(builder: (context)=>Home()));
                      }
                  },
                  icon: Icon(
                    Icons.arrow_back,
                    color: Colors.white,
                  ),
                  ),
              )
          ],
          
        ),
      
      
      
      ) ,

    )
    
    );
    
  }
   Future<void> likeArticle(int articleId) async {
    var article = await APIService.likeArticle('Article/ArticleLike',articleId);
    APIService.likedArticles.add(articleId);
  } 
    Future<void> unlikeArticle(int articleId) async {
    var article = await APIService.likeArticle('Article/ArticleUnlike',articleId);
     APIService.likedArticles.remove(articleId);
  } 
   Future<bool> onLikeButtonTapped(bool isLiked ) async{
    if(!isLiked){
      await likeArticle(widget.item.Id);
    }
    else {
      await unlikeArticle(widget.item.Id);
    }
     
    return !isLiked;
  }

   void Recommended(int id)async  {

if (!mounted) {
  return;
}
    var article = await APIService.GetById('Recommendation', id);
    if(article!=null){
        setState(() {
          recommended = Article.fromJson(article);
        });
     
    }
  
  }
}
