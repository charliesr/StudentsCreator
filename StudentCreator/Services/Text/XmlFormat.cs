using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Services.Text
{
    public class XmlFormat : IFormat
    {
        public IParser CreateParser()
        {
            return new XmlParser(); 
        }
    }
}
