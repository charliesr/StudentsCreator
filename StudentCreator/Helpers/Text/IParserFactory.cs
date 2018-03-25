using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Helpers.Text
{
    public interface IParserFactory
    {
        IParser CreateParser();
    }
}
