import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:newsportal/pages/home.dart';
import 'package:newsportal/pages/login.dart';
import 'package:newsportal/pages/registration.dart';


void main() {
  Stripe.publishableKey =
     "pk_test_51M5bAiByli9BoYmU1U6QqBnoVi2hmvUiqWjlKW2HpyQJr16Uh233UwQnwYjM2E9VBi6FtQZ9MKzetimlG1UMqukl00medsSww2";
  runApp(const MyApp());
}
class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
       theme: ThemeData(
       appBarTheme: const AppBarTheme(
     color: Colors.grey,
  )),
      debugShowCheckedModeBanner: false,
      home: const Home(),
      routes: {
        'Home': (context) => const Home(),
        'Register': (context) => const Register(),
        'Login': (context) => const Login(),
      },
    );
  }
}

