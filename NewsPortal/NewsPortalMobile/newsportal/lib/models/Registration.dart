class Registration {
  String FirstName;
  String LastName;
  String Email;
  String Phone;
  String BirthDate;
  String Username;
  String Password;
  String PasswordConfirmation;

  Registration(
      {required this.FirstName,
      required this.LastName,
      required this.Email,
      required this.Phone,
      required this.BirthDate,
      required this.Username,
      required this.Password,
      required this.PasswordConfirmation});

  factory Registration.fromJson(Map<String, dynamic> json) {
    return Registration(
        FirstName: json["firstName"],
        LastName: json["lastName"],
        Email: json["email"],
        Phone: json["phone"],
        BirthDate: json["birthDate"],
        Username: json["username"],
        Password: json["password"],
        PasswordConfirmation: json["passwordConfirmation"]);
  }

  Map<String, dynamic> toJson() => {
        "firstName": FirstName,
        "lastName": LastName,
        "email": Email,
        "phone": Phone,
        "birthDate": BirthDate,
        "username": Username,
        "password": Password,
        "passwordConfirmation": PasswordConfirmation
      };
}