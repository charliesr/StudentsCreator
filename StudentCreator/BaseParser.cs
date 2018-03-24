using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator
{
    public abstract class BaseParser
    {
        public abstract void Append(string filename, Student student);
    }
}
