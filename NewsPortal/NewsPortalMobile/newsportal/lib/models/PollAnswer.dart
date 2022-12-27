// ignore_for_file: non_constant_identifier_names, file_names
class PollAnswer {
  final int Id;
  final String Text;
  final int PollId;
  final int Counter;

  PollAnswer({
    required this.Id,
    required this.Text,
    required this.PollId,
    required this.Counter,

  });

  factory PollAnswer.fromJson(Map<String, dynamic> json) {
    return PollAnswer(
      Id: json["id"],
      Text: json['text'],
      PollId: json['pollId'],
      Counter: json['counter'],

    );
  }

  Map<String, dynamic> toJson() => {
        "id": Id,
        "text": Text,
        "pollId": PollId,
        "counter": Counter,

     };

  }

