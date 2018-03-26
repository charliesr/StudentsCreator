using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Services.Text
{
    public class TxtFormat : IFormat
    {
        public IParser CreateParser()
        {
            return new TxtParser();
        }
    }
}
