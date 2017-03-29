using DigitalHolo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHolo.Repositories
{
    public interface IInterferogramRepository
    {
        byte[] ConvertInterferogramToByte(List<List<Complex>> interferogram);
    }
}
