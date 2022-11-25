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
       drawer:MenuDrawer(),
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
              decoration: const InputDecoration(hintText: 'Ime',
              contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
             
              ),
              ),
          const SizedBox(
            height: 10,
          ),
          TextFormField(
              validator: (value) {
             return value == null || value.isEmpty ? "Required" : null;
              },
              controller: prezimeController,
              decoration: const InputDecoration(hintText: 'Prezime',contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0))),
          const SizedBox(
            height: 10,
          ),
          TextFormField(
              validator: (value) {
             return value == null || value.isEmpty ? "Required" : null;
              },
            controller: datumRodjenjaController,
            decoration: const InputDecoration(hintText: 'Datum rođenja',contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0)),
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
              decoration: const InputDecoration(hintText: 'E-mail',contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              controller: telefonController,
              decoration: const InputDecoration(hintText: 'Telefon',contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              controller: korisnickoImeController,
              decoration: const InputDecoration(hintText: 'Korisničko ime',contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              obscureText: true,
              controller: lozinkaController,
              decoration: const InputDecoration(hintText: 'Password',contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0))),
          const SizedBox(
            height: 10,
          ),
          TextField(
              obscureText: true,
              controller: lozinkaPotvrdaController,
              decoration: const InputDecoration(hintText: 'Password potvrda',contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0))),
          const SizedBox(
            height: 10,
          ),
          Container(
              padding: const EdgeInsets.all(5),
              height: 50,
              width: 120,
              decoration: BoxDecoration(
                  color: Color.fromARGB(255, 96, 125, 139),
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