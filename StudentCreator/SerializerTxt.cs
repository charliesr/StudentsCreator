using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator
{
    public class SerializerTxt : BaseSerializerFactory
    {
        public override BaseParser CreateParser()
        {
            return new TxtParser();
        }
    }
}
