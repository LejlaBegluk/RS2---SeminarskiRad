// ignore_for_file: empty_constructor_bodies, non_constant_identifier_names, library_private_types_in_public_api

import 'package:flutter/material.dart';
import 'package:newsportal/models/PollResult.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';
import 'package:syncfusion_flutter_charts/charts.dart';

import '../services/APIService.dart';

class PollResultScreen extends StatefulWidget {
final int Id;
final String Question;
   const PollResultScreen({Key? key, required this.Id,required this.Question}) : super(key: key);

  @override
  _PollResultScreenState createState() => _PollResultScreenState();
}

  class _PollResultScreenState extends State<PollResultScreen> with SingleTickerProviderStateMixin{
      List<PollResult> dataList = []; // list of api data

     @override
  void initState(){
    getList();
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
          title: const Text('Poll results'),
          backgroundColor: Colors.grey,
        ),
            body: SfCircularChart(
              title: ChartTitle(text:widget.Question),
              legend: Legend(isVisible: true,overflowMode: LegendItemOverflowMode.wrap),
              series: <CircularSeries>[
                PieSeries<PollResult,String>(
                  dataSource: dataList,
                  xValueMapper: (PollResult data,_)=>data.Text,
                  yValueMapper: (PollResult data,_)=>data.Counter,
                  dataLabelSettings: const DataLabelSettings(isVisible: true),

                )
              ],
              )
        );
    }



    void getList() async {
    var list= APIService.getPollResults('PollAnswer/Results',widget.Id);
    var jsonList =await list;
  
for (var i = 0; i < jsonList!.length; i++) {
                setState(() {
                  dataList.add(
                    PollResult(
                     Text: jsonList[i]["text"],
                     Counter: jsonList[i]["counter"],
                   ),

                 );
                

            
            });
          }
           
      } 
  }
        
  
    

