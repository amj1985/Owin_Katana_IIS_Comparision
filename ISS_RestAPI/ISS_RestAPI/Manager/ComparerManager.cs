using ISS_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISS_RestAPI.Manager
{
    public class ComparerManager
    {
        private static Lazy<ComparerManager> _instance = new Lazy<ComparerManager>(() => new ComparerManager());
        public static ComparerManager Instance { get { return _instance.Value; } }
        public Counter Counter { get; private set; }
        private List<long> _averages;
        public ComparerManager()
        {
            Initialize();
        }
        public virtual void Update(long averageInMiliseconds)
        {
            Counter.Total++;
            _averages.Add(averageInMiliseconds);
        }
        public virtual void Initialize()
        {
            Counter = new Counter();
            _averages = new List<long>();
        }
    }
}