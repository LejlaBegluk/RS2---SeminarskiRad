import 'dart:convert';
import 'dart:ffi';

class PaidArticle {
  final int Id;
  final bool Active;
  final String Content;
  final int? UserId;
  final String Title;
  String? PaidArticleStatusName;
  final DateTime CreateOn;
  final int? PaidArticleStatusId;

  PaidArticle({
    required this.Id,
    required this.Active,
    required this.Content,
    required this.UserId,
    required this.Title,
    this.PaidArticleStatusName,
    required this.CreateOn,
    required this.PaidArticleStatusId,

  });

  factory PaidArticle.fromJson(Map<String, dynamic> json) {
    return PaidArticle(
      Id: json["id"],
      Active: json['active'],
      Content: json['content'],
      UserId: json['userId'],
      Title: json['title'],
      PaidArticleStatusName: json['paidArticleStatusName'],
      CreateOn: DateTime.parse(json['createOn']),
      PaidArticleStatusId: json['paidArticleStatusId'],

    );
  }

  Map<String, dynamic> toJson() => {
        "id": Id,
        "active": Active,
        "content": Content,
        "userId": UserId,
        "title": Title,
        "paidArticleStatusName": PaidArticleStatusName,
        "paidArticleStatusId": PaidArticleStatusId,
        "createOn": CreateOn.toString(),


     };
}
