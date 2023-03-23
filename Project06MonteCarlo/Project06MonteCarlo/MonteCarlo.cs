using System;
using System.Collections;
using System.Collections.Generic;

namespace Project06MonteCarlo
{
    public class MonteCarlo
    {
        private struct Task
        {
            public int BestCase;
            public int AverageCase;
            public int WorstCase;

            public Task(int bestCase, int averageCase, int worstCase)
            {
                this.BestCase = bestCase;
                this.AverageCase = averageCase;
                this.WorstCase = worstCase;
            }

            public int GetRandomEstimate()
            {
                Random random = new Random();
                int randomInt = random.Next(0, 3);
                int result = 0;
                switch (randomInt)
                {
                    case 0:
                        result = BestCase;
                        break;
                    case 1:
                        result = AverageCase;
                        break;
                    case 2:
                        result = WorstCase;
                        break;
                }

                return result;
            }
        }

        private static List<Task> tasks = new List<Task>();
        private const int ProbeCount = 10000;

        private static int[] _taskEstimateData = new int [ProbeCount];
        private static int _position = 0;
        
        private static int GetMin(List<int> intList)
        {
            var min = 0;
            for (var i = 0; i < intList.Count; i++)
            {
                if (intList[i] < min)
                    min = i;
            }

            int element = intList[min];
            intList.RemoveAt(min);
            return element;

        }
        
        
        // 2 Points
        public static void GetInputTasks()
        {
            Console.WriteLine("Enter tasks in following format: c1, c2, c3");
            Console.WriteLine("Where cx is cost");
            Console.WriteLine("Input exactly 3 tasks.");
            Console.WriteLine("Type END to finish entering tasks.");

            int i = 1;
            string input = "";
            while (!input.Equals("END"))
            {
                Console.Write("Task#" + i + " ");
                input = Console.ReadLine();
                if(input.Equals("END"))
                    break;
                string[] timesArr = input.Split(",");
                if (timesArr.Length != 3)
                {
                    Console.WriteLine("Please enter 3 tasks, input again.");
                    continue;
                }
                List<int> taskTimes = new List<int>();
                taskTimes.Add(Convert.ToInt32(timesArr[0]));
                taskTimes.Add(Convert.ToInt32(timesArr[1]));
                taskTimes.Add(Convert.ToInt32(timesArr[2]));

                int bestCase = GetMin(taskTimes);
                int averageCase = GetMin(taskTimes);
                int worstCase = GetMin(taskTimes);

                tasks.Add(new Task(bestCase, averageCase, worstCase));

                i++;
            }
        }
        
        
        
        private static Task CasesMonteCarlo()
        {
            
            int bestTotal = 0;
            foreach (var task in tasks)
            {
                bestTotal += task.BestCase;
            }
            
              
            int worstTotal = 0;
            foreach (var task in tasks)
            {
                worstTotal += task.WorstCase;
            }

            _taskEstimateData[0] = bestTotal;
            _position++;
            _taskEstimateData[ProbeCount - 1] = worstTotal;
            
            
            
            Random random = new Random();
            int randomTotalAvg = 0;

            for (int i = 0; i < ProbeCount; i++)
            {
                int randomPlanEstimate = 0;
                foreach (var task in tasks)
                {
                    randomPlanEstimate += task.GetRandomEstimate();
                }

                
                _taskEstimateData[_position] = randomPlanEstimate;
                if (_position + 1 != ProbeCount - 1)
                {
                    _position++;
                }
                
                randomTotalAvg += randomPlanEstimate;

            }
            randomTotalAvg /= ProbeCount;


            
          


            return new Task(bestTotal, randomTotalAvg, worstTotal);

        }

        private static double[] BucketIntervals(int binCount)
        {
            int max = _taskEstimateData[0];
            int min = _taskEstimateData[0];
            
            for (int i = 0; i < _taskEstimateData.Length; ++i)
            {
                if (_taskEstimateData[i] < min) min = _taskEstimateData[i];
                if (_taskEstimateData[i] > max) max = _taskEstimateData[i];
            }
            
            double width = (double) (max - min)/ binCount; // compute width
            double[] intervals = new double[binCount * 2]; // intervals
            intervals[0] = min;
            intervals[1] = min + width;
            
            for (int i = 2; i < intervals.Length - 1; i += 2)
            {
                intervals[i] = intervals[i - 1];
                intervals[i + 1] = intervals[i] + width;
            }
            
            intervals[0] = double.MinValue; // outliers
            intervals[intervals.Length - 1] = double.MaxValue;

            return intervals;
        }
        
        private static int Bin(double x, double[] intervals)
        {
            for (int i = 0; i < intervals.Length - 1; i += 2)
            {
                if (x >= intervals[i] && x < intervals[i + 1])
                    return i / 2;
            }
            return -1; // error
        }

        private static void DisplayProbablities(int binCount, double[] intervals)
        {
            int[] count = new int[binCount * 2];
            for (int i = 0; i < ProbeCount; i++)
            {
                for (int j = 0; j < ProbeCount; j++)
                {
                    if(i == j)
                        continue;
                    
                    int bin = Bin(_taskEstimateData[i], intervals);
                    if (bin != -1)
                    {
                        count[bin]++;
                    }
                }
            }

            for (int i = 0; i < count.Length; i+=2)
            {
                Console.WriteLine(intervals[i] + " days = " + count[i] * 100/ProbeCount);
            }
        }
        
        public static void Main(string[] args)
        {
            GetInputTasks();
            Task projectTasks = CasesMonteCarlo();
            Console.WriteLine("After probing 10000 random plans, the results are:");
            Console.WriteLine("Minimum = " + projectTasks.BestCase);
            Console.WriteLine("Maximum = " + projectTasks.WorstCase);
            Console.WriteLine("Average = " + projectTasks.AverageCase);
            
            // Bucketlama işlemi başarıyla çalışıyor, ancak probablity yazdırması hatalı. O yüzden şimdilik yorum satırına aldım.

            //double[] buckets = BucketIntervals(10);
            //DisplayProbablities(10, buckets);



        }
    }
}