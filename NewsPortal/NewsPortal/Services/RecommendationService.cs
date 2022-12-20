using AutoMapper;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.EntityFrameworkCore;

namespace NewsPortal.WebAPI.Services
{
    public class RecommendationService : CRUDService<MArticle, RecommendationArticleSearchRequest, Article, RecommendationArticleUpsertRequest, RecommendationArticleUpsertRequest>
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
     
    public RecommendationService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        static MLContext mlContext = null;
        static object isLocked = new object();
        static ITransformer model = null;

        public override MArticle GetById(int ID)
        {

            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = _context.Categories.Include("Articles").ToList();

                    var data = new List<ArticleEntry>();
                    foreach (var x in tmpData)
                    {
                        if (x.Articles.Count > 1)
                        {
                            var distinctItemId = x.Articles.Select(y => y.Id).ToList();
                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.Articles.Where(z => z.Id != y);

                                foreach (var z in relatedItems)
                            {
                                data.Add(new ArticleEntry()
                                {
                                    ArticleID = (uint)y,
                                    CoArticleID = (uint)z.Id,
                                });
                            }
                            });

                        }

                    }
                        var traindata = mlContext.Data.LoadFromEnumerable(data);

                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ArticleEntry.ArticleID);
                    options.MatrixRowIndexColumnName = nameof(ArticleEntry.CoArticleID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;


                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }

            }


            List<Article> allItems = new List<Article>();

            for (int i = 0; i < 10000; i++)
            {
                var tmp = _context.Articles.Where(x => x.Id != ID);
                allItems.AddRange(tmp);
            }


            var predictionResult = new List<Tuple<Article, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ArticleEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new ArticleEntry()
                {
                    ArticleID = (uint)ID,
                    CoArticleID = (uint)item.Id
                });

                predictionResult.Add(new Tuple<Article, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).FirstOrDefault();

            return _mapper.Map<MArticle>(finalResult);
        }
        public class Copurchase_prediction
        {
            public float Score { get; set; }
        }

        public class ArticleEntry
        {
            [KeyType(count: 10)]
            public uint ArticleID { get; set; }

            [KeyType(count: 10)]
            public uint CoArticleID { get; set; }

            public float Label { get; set; }
        }
    }
}