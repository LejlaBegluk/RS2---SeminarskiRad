import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:newsportal/models/User.dart';
import 'package:newsportal/services/APIService.dart';
import 'package:newsportal/widgets/news_portal_drawer.dart';

class Profil extends StatefulWidget {
  @override
  _ProfilState createState() => _ProfilState();
}

class _ProfilState extends State<Profil> {
  final _validationKey = GlobalKey<FormState>();

  TextEditingController firstNameController = TextEditingController();
  TextEditingController lastNameController = TextEditingController();
  TextEditingController usernameController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer:MenuDrawer(),
        appBar: AppBar(
          title: Text('My profile'),
        ),
        body:   SingleChildScrollView( child:bodyWidget()));
  }

  Widget bodyWidget() {
    final txtIme = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? "Required" : null;
      },
      controller: firstNameController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Firstname",
          label: const Text("Firstname"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtPrezime = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? "Required" : null;
      },
      controller: lastNameController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Lastname",
          label: const Text("Lastname"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtUsername = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? "Required" : null;
      },
      controller: usernameController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Username",
          label: const Text("Username"),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    Widget ProfilWidget(korisnik) {
      firstNameController.text = korisnik.FirstName;
      lastNameController.text = korisnik.LastName;
      usernameController.text = korisnik.Username;
      return Center(
        child: Padding(
          padding: const EdgeInsets.all(20),
          child: Column(
            children: [
              const Icon(Icons.portrait, size: 80),
              const SizedBox(height: 25),
              Form(
                  key: _validationKey,
                  child: Column(
                    children: [
                      txtIme,
                      const SizedBox(height: 25),
                      txtPrezime,
                      const SizedBox(height: 25),
                      txtUsername,
                      const SizedBox(height: 25),
                      Container(
                        height: 50,
                        width: 250,
                        decoration: BoxDecoration(
                            color: Colors.blueGrey,
                            borderRadius: BorderRadius.circular(20)),
                        child: TextButton(
                          
                          onPressed: () async {
                            var request = User(
                                UserId: APIService.UserId!,
                                FirstName: firstNameController.text,
                                LastName: lastNameController.text,
                                Username: usernameController.text);

                            await APIService.post(
                                    "User/EditProfile",
                                    json.encode(request.toJson()))
                                .then((value) {
                              APIService.username =
                                  usernameController.text;
                              setState(() {
                                ScaffoldMessenger.of(context)
                                    .showSnackBar(const SnackBar(
                                  content: SizedBox(
                                      height: 20,
                                      child: Center(child: Text("Success"))),
                                  backgroundColor:
                                      Colors.blueGrey,
                                ));
                              });
                            });
                          },
                          child: const Text('Save',
                              style:
                                  TextStyle(color: Colors.white, fontSize: 20)),
                        ),
                      ),
                    ],
                  ))
            ],
          ),
        ),
      );
    }

    return FutureBuilder(
      future: getUser(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ProfilWidget(snapshot.data);
          }
        }
      },
    );
  }
}

Future<dynamic> getUser() async {
  var user = await APIService.GetById("User", APIService.UserId!);
  return User.fromJson(user);
}
