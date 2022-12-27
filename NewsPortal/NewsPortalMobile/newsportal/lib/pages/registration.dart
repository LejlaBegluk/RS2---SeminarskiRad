// ignore_for_file: library_private_types_in_public_api, non_constant_identifier_names, use_build_context_synchronously

import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:newsportal/models/Registration.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';
import '../services/APIservice.dart';

class Register extends StatefulWidget {
  const Register({Key? key}) : super(key: key);

  @override
  _RegisterState createState() => _RegisterState();
}

class _RegisterState extends State<Register> {
  TextEditingController imeController = TextEditingController();
  TextEditingController prezimeController = TextEditingController();
  TextEditingController datumRodjenjaController = TextEditingController();
  TextEditingController emailController = TextEditingController();
  TextEditingController telefonController = TextEditingController();
  TextEditingController korisnickoImeController = TextEditingController();
  TextEditingController lozinkaController = TextEditingController();
  TextEditingController lozinkaPotvrdaController = TextEditingController();
final _formKey = GlobalKey<FormState>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
       drawer:const MenuDrawer(),
        appBar: AppBar(
          title: const Text('Registration'),
          backgroundColor: Colors.grey,
        ),
      body: bodyWidget());
  }

  Widget bodyWidget() {
    return FutureBuilder<Registration>(
      builder: (BuildContext context, AsyncSnapshot<Registration> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return RegistracijeWidget(snapshot.data);
          }
        }
      },
    );
  }

  Widget RegistracijeWidget(registracija) {
    return Scaffold(
      body: SingleChildScrollView(
          child: 
                   Form(
                    key: _formKey,
        child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
          const Text(
            'Registration',
            style: TextStyle(fontSize: 30, color: Colors.black),
          ),
          const SizedBox(height: 50),
      
          TextFormField(
                validator: (value) {
             return value == null || value.isEmpty ? "Required" : null;
              },

              controller: imeController,
             decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Firstname",
          label: const Text("Firstname"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
              ),
          const SizedBox(
            height: 10,
          ),
          TextFormField(
              validator: (value) {
             return value == null || value.isEmpty ? "Required" : null;
              },
              controller: prezimeController,
              decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Lastname",
          label: const Text("Lastname"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),),
          const SizedBox(
            height: 10,
          ),
          TextFormField(
              validator: (value) {
             return value == null || value.isEmpty ? "Required" : null;
              },
            controller: datumRodjenjaController,
          decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Birthdate",
          label: const Text("Birthdate"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
            readOnly: true,
            onTap: () async {
              DateTime? pickedDate = await showDatePicker(
                  context: context,
                  initialDate: DateTime.now(),
                  firstDate: DateTime(1900),
                  lastDate: DateTime(2101));

              if (pickedDate != null) {
                String formattedDate =
                    DateFormat('yyyy-MM-dd').format(pickedDate);

                setState(() {
                  datumRodjenjaController.text = formattedDate;
                });
              }
            },
          ),
          const SizedBox(
            height: 10,
          ),
          TextFormField ( 
            validator: (value) {
            if (value == null || value.isEmpty) {
                      return 'Required';
                    }
                    if (!RegExp(r'^[^@]+@[^@]+\.[^@]+').hasMatch(value)) {
                      return "Invalid email, use similar format: mail@email.com";
                    }
                    return null;
                  },
                
              controller: emailController,
            decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Email",
          label: const Text("Email"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              controller: telefonController,
               decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Phone",
          label: const Text("Phone"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              controller: korisnickoImeController,
              decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Username",
          label: const Text("Username"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              obscureText: true,
              controller: lozinkaController,
              decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Password",
          label: const Text("Password"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              obscureText: true,
              controller: lozinkaPotvrdaController,
               decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Confirm password",
          label: const Text("Confirm password"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0)))),
          const SizedBox(
            height: 10,
          ),
          Container(
              padding: const EdgeInsets.all(5),
              height: 50,
              width: 120,
              decoration: BoxDecoration(
                  color: const Color.fromARGB(255, 96, 125, 139),
                  borderRadius: BorderRadius.circular(8)),
              child: TextButton(
                  onPressed: () async {
                    if (_formKey.currentState!.validate()) {
                    var date = datumRodjenjaController.text;
                              DateTime formatedDate =
                                  DateFormat('yyyy-MM-dd').parse(date);
                    var request = Registration(
                        FirstName: imeController.text,
                        LastName: prezimeController.text,
                        Email: emailController.text,
                        Phone: telefonController.text,
                        BirthDate: formatedDate.toString(),
                        Username: korisnickoImeController.text,
                        Password: lozinkaController.text,
                        PasswordConfirmation: lozinkaPotvrdaController.text);

                    var result = await APIService.post(
                        "User/Register", json.encode(request.toJson()));

                    if (result != null) {
                      setState(() {
                        ScaffoldMessenger.of(context)
                            .showSnackBar(const SnackBar(
                          content: SizedBox(
                              height: 20,
                              child: Center(child: Text("Success."))),
                          backgroundColor: Color.fromARGB(255, 96, 125, 139),
                        ));
                      });
                      Navigator.of(context).pushReplacementNamed('Login');
                    }
                  }},
                  child: const Text('Save',
                      textAlign: TextAlign.center,
                      style: TextStyle(color: Colors.white, fontSize: 16)))),
        ]),
      )
      ),
    );
  }
}