using PracticePanther.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        private List<Time> times;

        public List<Time> Times
        {
            get
            {
                return times;
            }
        }

        public static TimeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimeService();
                }

                return instance;
            }
        }
        private TimeService()
        {
            times = new List<Time> {
            
            };
        }

        public Time AddOrUpdate(Time t)
        {
            times.Add(t);
            return t;
        }
    }
}