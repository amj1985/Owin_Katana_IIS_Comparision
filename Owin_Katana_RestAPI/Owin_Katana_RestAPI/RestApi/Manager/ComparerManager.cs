using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Manager
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
        public void Update(long averageInMiliseconds)
        {
            Counter.Total++;
        }
        public void Initialize()
        {
            Counter = new Counter();
            _averages = new List<long>();
        }
    }
}
