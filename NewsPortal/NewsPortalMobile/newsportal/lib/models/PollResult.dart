import 'dart:convert';

class PollResult {
  final String Text;
  final int Counter;

  PollResult({
    required this.Text,
    required this.Counter,

  });

  factory PollResult.fromJson(Map<String, dynamic> json) {
    return PollResult(
      Text: json['text'],
      Counter: json['counter'],

    );
  }

  Map<String, dynamic> toJson() => {
        "text": Text,
        "counter": Counter,

     };

  }

