using System.IO;

namespace StudentCreator
{
    public class TxtParser : BaseParser
    {
        public override void Append(string filename, Student student)
        {
            filename += ".txt";
            var content = string.Concat(student.ID + "," + student.Nombre + "," + student.Apellidos + "," + student.DNI + ",");
            File.AppendAllText(filename, content);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();  
        }
    }
}