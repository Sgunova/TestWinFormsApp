using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWinFormsApp.Core.Interfaces
{
    public interface IReader<T>
    {
        public List<T> ReadData();
    }
}
