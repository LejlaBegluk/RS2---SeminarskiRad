// ignore_for_file: deprecated_member_use, must_be_immutable, prefer_final_fields, non_constant_identifier_names
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart' hide Card;
import 'package:newsportal/models/PaidArticleStatus.dart';
import 'package:newsportal/models/ArticlePayment.dart';
import 'package:newsportal/pages/paid_article_list.dart';
import 'package:newsportal/services/APIService.dart';
import '../models/PaidArticle.dart';
import 'package:http/http.dart' as http;
  class PaidArticleForm extends StatelessWidget {
  final String tag;
  final PaidArticle item;
  final int Amount=300;
   Map<String, dynamic>? paymentIntentData;
   GlobalKey<ScaffoldState> _scaffoldKey = GlobalKey<ScaffoldState>();
  PaidArticleForm({Key? key,required this.item,required this.tag}) : super(key: key);
  @override
  Widget build(BuildContext context) {
     //return Center(child: CircularProgressIndicator());
    return  Scaffold(
        key: _scaffoldKey,
        appBar: AppBar(
          title: const Text('Paid article'),
          backgroundColor: Colors.grey,
        ),
      body: 
      
      Container(
       // crossAxisAlignment: CrossAxisAlignment.center,
        margin: const EdgeInsets.only(top:50),
       child: Column(children: [  Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: Text("Status: ${item.PaidArticleStatusName}"),
                              ), 
                                 Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: TextFormField(
                                   enabled: item.Id==0,
                                    keyboardType: TextInputType.multiline,
                                    maxLines: 2,
                                   controller: TextEditingController(text:item.Title),
                                   decoration: const InputDecoration( hintText: "Title content",  border: OutlineInputBorder()),
                                   validator: (value) {
                                     if(value!.isEmpty) {
                                      return 'Title can not be empty'; }
                                     return null;
                                  },
                                ),
                              ), 
                              Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: TextFormField(
                                   enabled: item.Id==0,
                                    keyboardType: TextInputType.multiline,
                                    maxLines: 8,
                                   controller: TextEditingController(text:item.Content),
                                   decoration: const InputDecoration( hintText: "Article content",  border: OutlineInputBorder()),
                                   validator: (value) {
                                     if(value!.isEmpty) {
                                      return 'Content can not be empty';
                                       }
                                     return null;
                                  },
                                ),
                              ), 
                               const Padding(
                                padding: EdgeInsets.all(8.0),
                                child: Text("*Article can be payed only in status approved."),
                              ), 
                              Visibility(
                                visible: item.PaidArticleStatusId==PaidArticleStatus.approved.index,
                          child:
                        ElevatedButton(
                          onPressed: () async {
                            await makePayment(double.parse(Amount.toString())).then((String value){
                            Navigator.push(context, MaterialPageRoute(builder: (context)=>const PaidArticleListScreen()));
                            });

                          },
                          
                          style: ElevatedButton.styleFrom(
                              primary: const Color.fromARGB(200, 239, 108, 0),
                              minimumSize: const Size.fromHeight(50)),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            // ignore: prefer_const_literals_to_create_immutables
                            children: [
                              const Text("Proceed to payment",
                                  style: TextStyle(fontSize: 20)),
                              const Icon(
                                Icons.arrow_forward_rounded,
                                size: 30,
                              )
                            ],
                          ))),
                           
            ],
            
         )
    ),
   
          );
  
  }
   Future<String> makePayment(double iznos) async {
    try {
      paymentIntentData =
          await createPaymentIntent((iznos).round().toString(), 'bam');
      await Stripe.instance
          .initPaymentSheet(
              paymentSheetParameters: SetupPaymentSheetParameters(
                  paymentIntentClientSecret:
                  paymentIntentData!['client_secret'],
                  applePay: true,
                  googlePay: true,
                  testEnv: true,
                  style: ThemeMode.dark,
                  merchantCountryCode: 'BIH',
                  merchantDisplayName: 'News'))
          .then((value) {});

      await insertPayment(iznos, paymentIntentData!['id']);

      ///now finally display payment sheeet
      displayPaymentSheet();
    } catch (e, s) {
      print('exception:$e$s');
    
    }
    return "success";
  }
   createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
          Uri.parse('https://api.stripe.com/v1/payment_intents'),
          body: body,
          headers: {
            'Authorization':
                'Bearer sk_test_51M5bAiByli9BoYmU5nKYa5e88IkwhgQm8hw8GCfa3tEFVnYv4xNIuOCjfZNgWX2PsPno3m4b5SowbpR4I2L0UpCm00R6np3nij',
            'Content-Type': 'application/x-www-form-urlencoded'
          });
      return jsonDecode(response.body);
    } catch (err) {
      print('err charging user: ${err.toString()}');
    }
  }

  insertPayment(double amount, String tansactionNumber) async {
    var request = ArticlePayment(
      UserId: APIService.UserId,
      Amount: amount,
      TansactionNumber: tansactionNumber,
      TransactionDate: DateTime.now(),
      ArticleId: item.Id
    );

     APIService.post("ArticlePayment", json.encode(request.toJson()));
  }

  displayPaymentSheet() async {
 try {
      await Stripe.instance
          .presentPaymentSheet(
              parameters: PresentPaymentSheetParameters(
        clientSecret: paymentIntentData!['client_secret'],
        confirmPayment: true,
      ))
          .onError((error, stackTrace) {
        print('Exception/DISPLAYPAYMENTSHEET==> $error $stackTrace');
      });

    } catch (e) {
      print('$e');
    }
  }
}