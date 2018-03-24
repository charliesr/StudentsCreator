using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator
{
    public class SerializerJson : BaseSerializerFactory
    {
        public override BaseParser CreateParser()
        {
            return new JsonParser();
        }


    }
}
