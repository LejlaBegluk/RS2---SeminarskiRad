// ignore_for_file: non_constant_identifier_names, file_names

class Poll {
  final int Id;
  final String Question;
  final DateTime CreateOn;
  Poll({
    required this.Id,
    required this.Question,
    required this.CreateOn,
  });

  factory Poll.fromJson(Map<String, dynamic> json) {
    return Poll(
      Id: json["id"],
      Question: json['question'],
      CreateOn: DateTime.parse(json['createOn']),
    );
  }

  Map<String, dynamic> toJson() => {
        "id": Id,
        "question": Question,
        "createOn": CreateOn.toString(),
     };
}
