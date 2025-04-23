using System;
using System.Collections.Generic;
using System.Timers;

namespace E1
{
    public class DuplicateNumberDetector
    {
        public event Action<int> DuplicateNumberAdded;
        Dictionary<int ,int> intList = new Dictionary<int, int>();
        public void AddNumber(int n)
        {
            if (intList.ContainsKey(n))
            {
                intList[n]++;
                DuplicateNumberAdded?.Invoke(intList[n]);
            }
            else intList[n] = 1;
        }
    }
}