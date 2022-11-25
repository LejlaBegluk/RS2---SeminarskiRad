import 'package:flutter/material.dart';
import 'package:newsportal/models/User.dart';
import 'package:newsportal/services/APIService.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

User? result;

Future<void> GetData() async {
  result = await APIService.prijava();
}

class _LoginState extends State<Login> {
  var usernameController = new TextEditingController();
  var passwordController = new TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Padding(
          padding: EdgeInsets.all(10),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              const SizedBox(
                height: 30,
                width: 100,
                child: FittedBox(child: Icon(Icons.newspaper)),
              ),
              const SizedBox(height: 10),
              TextField(
                  controller: usernameController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(20)),
                      hintText: 'Username')),
              const SizedBox(
                height: 20,
              ),
              TextField(
                  obscureText: true,
                  controller: passwordController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(20)),
                      hintText: 'Password')),
              const SizedBox(
                height: 20,
              ),
              Container(
                height: 50,
                width: 250,
                decoration: BoxDecoration(
                    color: Colors.blueGrey, borderRadius: BorderRadius.circular(20)),
                child: TextButton(
                  onPressed: () async {
                    APIService.username = usernameController.text;
                    APIService.password = passwordController.text;
                    await GetData();
                    if (result != null) {
                      print(result);
                      APIService.UserId = result!.UserId;
                      Navigator.of(context).pushReplacementNamed('Home');
                    }
                    else{
                      ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
                        content: SizedBox(
                            height: 20, child: Center(child: Text("Incorrect username or password."))),
                        backgroundColor: Colors.red,
                      ));
                    }
                  },
                  child: Text('Login',
                      style: TextStyle(color: Colors.white, fontSize: 20)),
                ),
              ),
              const SizedBox(
                height: 10,
              ),
              GestureDetector(
                child: const Text('Register',
                    textAlign: TextAlign.center,
                    style: TextStyle(
                        color: Colors.blue,
                        fontSize: 17,
                        decoration: TextDecoration.underline)),
                onTap: () async {
                  Navigator.of(context).pushReplacementNamed('Register');
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
