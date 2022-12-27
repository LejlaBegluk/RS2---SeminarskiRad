// ignore_for_file: empty_constructor_bodies, deprecated_member_use, library_private_types_in_public_api, non_constant_identifier_names


import 'package:flutter/material.dart';
import 'package:newsportal/models/Poll.dart';
import 'package:newsportal/models/PollAnswer.dart';
import 'package:newsportal/pages/poll_result_screen.dart';
 import 'package:newsportal/services/APIService.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';
//import 'package:flutter_polls/flutter_polls.dart';

class PollDetailScreen extends StatefulWidget {
    final Poll poll;
   const PollDetailScreen({Key? key, required this.poll}) : super(key: key);

  @override
  _PollDetailScreenState createState() => _PollDetailScreenState();
}

  class _PollDetailScreenState extends State<PollDetailScreen> with SingleTickerProviderStateMixin{
     late int? groupValue = 0;
     Map<String, dynamic>? dataMap;
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
       drawer:const MenuDrawer(),
       appBar: AppBar(
          title: const Text('Poll'),
          backgroundColor: Colors.grey,
        ),
    body: Container( 
            padding: const EdgeInsets.all(20),
            child: 
          Column(
            children: [
                Text(widget.poll.Question, style: const TextStyle( 
                    fontSize: 18
                ),),

                const Divider(),
      Expanded(
      child:bodyWidget()
      ),
         Padding(
                      padding: const EdgeInsets.all(0.0),
                        child: ElevatedButton(
                            style: ElevatedButton.styleFrom(
                                    primary:  Colors.blueGrey),
                          child: const Text("Save"),
                            onPressed: () {
                            if (groupValue!=0) {
                                 vote();
                                 Navigator.push(context, MaterialPageRoute(builder: (context)=>PollResultScreen(Id: widget.poll.Id,Question: widget.poll.Question, )));

                                    }
                                  },
                                ),
                              ),    ]
     )
     )
     );
    
    

  }
  Widget bodyWidget() {
   return FutureBuilder<List<PollAnswer>>(
      future: getList(),
      builder: (BuildContext context, AsyncSnapshot<List<PollAnswer>> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return 
            ListView(
              children: snapshot.data!.map((e) => PollAnswerWidget(e)).toList(),
            );
          }
        }
      },
    );
  }
   Future<List<PollAnswer>> getList() async {

    var polls = await APIService.getPollAnswers('PollAnswer',widget.poll.Id);
    return polls!.map((i) => PollAnswer.fromJson(i)).toList();
  }
   Widget PollAnswerWidget(PollAnswer item) {
    return 
    GestureDetector(
      child:Card(
    elevation: 2.0,
    margin: const EdgeInsets.only(bottom: 20.0),
    child: Padding(padding: const EdgeInsets.all(8.0),
   
    child: Row(children: [  
        
        Expanded(
          
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
           RadioListTile(
          title: Text(item.Text),
          value: item.Id, 
          groupValue: groupValue, 
          onChanged: (value){
            setState(() {
                groupValue =item.Id;
            }
            
            );})
            ],
          ),
          
        ),                    
    ]
    ),
    ),
  
  
  ),
  onTap:(){

     //     Navigator.push(context, MaterialPageRoute(builder: (context)=>PollDetailScreen(poll: item)));
          }
);
}
  
  
  vote() async {
    await APIService.vote("PollAnswer/Vote",groupValue! );

  }
}


