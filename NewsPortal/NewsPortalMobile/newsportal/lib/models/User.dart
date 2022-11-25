import 'dart:convert';

class User {
  final int UserId;
  final String FirstName;
  final String LastName;
  final String Username;

  User({
    required this.UserId,
    required this.FirstName,
    required this.LastName,
    required this.Username,
  });

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
      UserId: json["id"],
      FirstName: json['firstName'],
      LastName: json['lastName'],
      Username: json['username'],
    );
  }

  Map<String, dynamic> toJson() => {
        "id": UserId,
        "firstName": FirstName,
        "lastName": LastName,
        "username": Username,
      };
}
