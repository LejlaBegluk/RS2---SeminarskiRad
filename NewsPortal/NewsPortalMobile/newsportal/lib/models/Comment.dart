import 'dart:convert';

class Comment {
  final int? Id;
  final String Content;
  final int ArticleId;
  final int UserId;
  final String? Username;
  final DateTime? CreateOn;
  final String? Photo;
  Comment({
    this.Id,
    required this.Content,
    this.Username,
    this.CreateOn,
    required this.ArticleId,
    required this.UserId,
     this.Photo,

  });

  factory Comment.fromJson(Map<String, dynamic> json) {
    return Comment(
      Id: json["id"],
      ArticleId: json['articleId'],
      Content: json['content'],
      Username: json['userUsername'],
      CreateOn: DateTime.parse(json['createOn']),
      UserId: json['userId'],
      Photo: '',

    );
  }

  Map<String, dynamic> toJson() => {
        "id": Id,
        "articleId": ArticleId,
        "content": Content,
       // "userUsername": Username,
        //"createOn": CreateOn,
        "userId": UserId,
      //  "photo": Photo,

      };
}
