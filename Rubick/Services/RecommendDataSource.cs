using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using RubickReptile;

namespace Rubick.Services
{
    public class RecommendDataSource
    {
        IList<Item> source;
        IList<Item> Source;

        DataSourceAnalysisInterface _ArchdailyAnalysis;
        DataSourceAnalysisInterface _GoooodAnalysis;
        DataSourceAnalysisInterface _ikukuAnalysis;
        DataSourceAnalysisInterface _ArchgosAnalysis;
        //int Pages = 0;
        public RecommendDataSource()
        {
            Source = new List<Item>();
            _ArchdailyAnalysis = new ArchdailyAnalysis();
            _GoooodAnalysis = new GoooodAnalysis();
            _ikukuAnalysis = new ikukuAnalysis();
            _ArchgosAnalysis = new ArchgosAnalysis();

        }
        public async Task<IEnumerable<Item>> GetItemsAsync(int page)
        {

            //await Task.Delay(2000);


            //if (DataSource.Source.Count == 0)
            //{
            //    DataSource.Pages += 1;
            //    DataSource.Source.Clear();
            //    if (DataSource.Archdailys == true)
            //    {
            //        _ArchdailyAnalysis.Source.Clear();
            //        _ArchdailyAnalysis.Load(DataSource.Pages);

            //    }
            //    if (DataSource.Goooods == true)
            //    {
            //        _GoooodAnalysis.Source.Clear();
            //        _GoooodAnalysis.Load(DataSource.Pages);
            //    }
            //    if (DataSource.Ikukus == true)
            //    {
            //        _ikukuAnalysis.Source.Clear();
            //        _ikukuAnalysis.Load(DataSource.Pages);
            //    }
            //    if (DataSource.Archgos == true)
            //    {
            //        _ArchgosAnalysis.Source.Clear();
            //        _ArchgosAnalysis.Load(DataSource.Pages);
            //    }

            //    var ru1 = _ArchdailyAnalysis.Source.Union(_GoooodAnalysis.Source).Union(_ikukuAnalysis.Source).Union(_ArchgosAnalysis.Source).ToList<CardsItem>();
            //    var ru2 = RandomSort<Item>(ru1);


            //    DataSource.Source = ru1.ToList();

            //}


            //if (DataSource.Source.Count < 11)
            //{
            //    for (int i = DataSource.Source.Count - 1; i >= 0; i--)
            //    {
            //        DataSource.Source[i].Group = page;
            //        //DataSource.Source[i].Title = DataSource.Source[i].Title + "qqq" + DataSource.Source.Count.ToString();
            //        Source.Add(DataSource.Source[i]);
            //        DataSource.Source.Remove(DataSource.Source[i]);
            //    }
            //}
            //else
            //{
            //    for (int i = 9; i >= 0; i--)
            //    {
            //        DataSource.Source[i].Group = page;
            //        Source.Add(DataSource.Source[i]);
            //        //DataSource.Source[i].Title = DataSource.Source[i].Title + "sss" + DataSource.Source.Count.ToString();
            //        DataSource.Source.Remove(DataSource.Source[i]);
            //    }

            //}


            
            return Source.AsEnumerable();


        }
        private IList<T> RandomSort<T>(IList<T> list)
        {
            var random = new Random();
            var newList = new List<T>();
            foreach (var item in list)
            {
                newList.Insert(random.Next(newList.Count), item);
            }
            return newList;
        }

    }
}
