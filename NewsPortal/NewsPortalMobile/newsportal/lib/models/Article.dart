import 'dart:convert';
import 'dart:io' as Io;
import 'package:flutter/cupertino.dart';
import 'package:newsportal/models/Category.dart';

class Article {
  final int Id;
  final String Title;
  final String Content;
  final int Likes;
  final String? Photo;
  final String Author;
  final DateTime Date;
  final int CategoryId;

  Article({
    required this.Id,
    required this.Title,
    required this.Content,
    required this.Likes,
    required this.Photo,
    required this.Author,
    required this.Date,
    required this.CategoryId

  });

  factory Article.fromJson(Map<String, dynamic> json) {
    return Article(
      Id: json["id"],
      Title: json['title'],
      Content: json['content'],
      Likes: json['likes'],
      Photo: json['photo'].toString(),
      Author: json['userFirstName']+' '+json['userLastName'],
      Date: DateTime.parse(json['createOn']),
      CategoryId: json['categoryId']

    );
  }

  Map<String, dynamic> toJson() => {
        "id": Id,
        "title": Title,
        "content": Content,
        "likes": Likes,
        "photo": Photo,
        "author": Author,
        "createOn": Date,
        "categoryId": CategoryId,


      };
      
}
