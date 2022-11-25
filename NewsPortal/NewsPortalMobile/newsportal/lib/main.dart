import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:newsportal/pages/home.dart';
import 'package:newsportal/pages/login.dart';
import 'package:newsportal/pages/registration.dart';


void main() {
  Stripe.publishableKey =
     "pk_test_51M5bAiByli9BoYmU1U6QqBnoVi2hmvUiqWjlKW2HpyQJr16Uh233UwQnwYjM2E9VBi6FtQZ9MKzetimlG1UMqukl00medsSww2";
  runApp(MyApp());
}
class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
       theme: ThemeData(
       appBarTheme: AppBarTheme(
     color: Colors.grey,
  )),
      debugShowCheckedModeBanner: false,
      home: Home(),
      routes: {
        'Home': (context) => Home(),
        'Register': (context) => Register(),
        'Login': (context) => Login(),
      },
    );
  }
}

