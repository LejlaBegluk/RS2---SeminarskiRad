import 'dart:convert';

class ArticlePayment {
  final double Amount;
  final String TansactionNumber;
  final DateTime TransactionDate;
  final int? UserId;
  final int? ArticleId;
  ArticlePayment({
    required this.Amount,
    required this.TansactionNumber,
    required this.TransactionDate,
    required this.UserId,
    required this.ArticleId

  });

  factory ArticlePayment.fromJson(Map<String, dynamic> json) {
    return ArticlePayment(
      Amount: json['amount'],
      TansactionNumber: json['tansactionNumber'],
      UserId: json['userId'],
      TransactionDate: DateTime.parse(json['transactionDate']),
      ArticleId: json['articleId'],

    );
  }

  Map<String, dynamic> toJson() => {
        "amount": Amount,
        "tansactionNumber": TansactionNumber,
        "userId": UserId,
        "transactionDate": TransactionDate.toString(),
       'articleId':ArticleId
      };
}
