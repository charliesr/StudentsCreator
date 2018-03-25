using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Helpers.Text
{
    public class SerializerJson : IParserFactory
    {
        public IParser CreateParser()
        {
            return new JsonParser();
        }
    }
}
