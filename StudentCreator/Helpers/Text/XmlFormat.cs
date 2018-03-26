using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Helpers.Text
{
    class XmlFormat : IFormat
    {
        public IParser CreateParser()
        {
            return new XmlParser(); 
        }
    }
}
