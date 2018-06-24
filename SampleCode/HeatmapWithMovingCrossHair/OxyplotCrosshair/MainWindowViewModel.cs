using System;

namespace OxyplotCrosshair
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            MinX = 0;
            MinY = 0;
            MaxX = 1;
            MaxY = 1;

            MyData = GenerateHeatMap();
        }
        public double[,] MyData { get; set; }

        public int MinX { get; set; }
        public int MinY { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        /// <summary>
        /// Generates the heat map data.
        /// </summary>
        /// <returns>
        /// The heat map data array.
        /// </returns>
        private double[,] GenerateHeatMap()
        {
            const int rows = 11;
            const int cols = 11;
            var result = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result[i, j] = Math.Sin(4 * Math.PI * i / rows) * Math.Sqrt(200 * Math.PI * j / cols);
                }
            }

            return result;
        }
    }
}