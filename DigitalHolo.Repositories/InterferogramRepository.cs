using System;
using System.Collections.Generic;
using DigitalHolo.Entities;

namespace DigitalHolo.Repositories
{
    public class InterferogramRepository : IInterferogramRepository
    {
        public byte[] ConvertInterferogramToByte(List<List<Complex>> interferogram)
        {
            var result = new List<double>();
            double max = 0;

            foreach (var row in interferogram)
            {
                foreach (var pixel in row)
                {
                    var absValue = Math.Sqrt(Math.Pow(pixel.Real, 2) - Math.Pow(pixel.Imagine, 2));
                    if (absValue > max)
                    {
                        max = absValue;
                    }

                    result.Add(absValue);
                }
            }

            List<byte> res = result.ConvertAll(e => (byte)(e*(Math.Pow(2, 24)-1)/max));

            return res.ToArray();
        }
    }
}
