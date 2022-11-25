// ignore_for_file: unused_import, unnecessary_import, prefer_final_fields

import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:newsportal/models/Article.dart';
import 'package:newsportal/models/Poll.dart';
import 'package:newsportal/pages/article_detail.dart';
import 'package:newsportal/pages/poll_detail.dart';
import 'package:newsportal/services/APIService.dart';
import 'package:newsportal/utils/util.dart';
import 'package:newsportal/widgets/master_screen.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';
import 'package:provider/provider.dart';

import '../models/PollAnswer.dart';

/*import '../../model/product.dart';
import '../../providers/cart_provider.dart';
import '../../widgets/eprodaja_drawer.dart';*/

class PollListScreen extends StatefulWidget {
  const PollListScreen({Key? key}) : super(key: key);

  @override
  _PollListScreenState createState() => _PollListScreenState();
}

class _PollListScreenState extends State<PollListScreen> with SingleTickerProviderStateMixin{
final DateFormat formatter = DateFormat('dd.MM.yyyy');


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
        body: bodyWidget());

  }
    Widget bodyWidget() {
    return FutureBuilder<List<Poll>>(
      future: getList(),
      builder: (BuildContext context, AsyncSnapshot<List<Poll>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ListView(
              children: snapshot.data!.map((e) => PollWidget(e)).toList(),
            );
          }
        }
      },
    );
  }
   Future<List<Poll>> getList() async {

    var polls = await APIService.Get('Poll',null);
    return polls!.map((i) => Poll.fromJson(i)).toList();
  } 

  Widget PollWidget(item) {
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
              Text(item.Question,
              style: TextStyle(fontSize: 18.0),),
              SizedBox(height: 5.0,),
              Row(
                children: [
               
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

          Navigator.push(context, MaterialPageRoute(builder: (context)=>PollDetailScreen(poll: item)));
          }
);
}
}



