using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator.Models
{
    public class Student
    {
        public Guid GUID { get; set; }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public Student()
        {
            GUID = Guid.NewGuid();
        }
        public Student(Guid guid)
        {
            GUID = guid;
        }
        public Student(Guid guid, int id, string nombre, string apellidos, string dni)
        {
            GUID = guid;
            ID = id;
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni;
        }
        public override bool Equals(object obj)
        {
            var castObject = obj as Student;
            return ID == castObject.ID && Nombre == castObject.Nombre && Apellidos == castObject.Apellidos && DNI == castObject.DNI && GUID == castObject.GUID;
        }

        public override int GetHashCode()
        {
            var hashCode = 287315274;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            hashCode = hashCode * -1521134295 + GUID.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Concat(GUID, ",",ID, ",", Nombre, ",", Apellidos, ",", DNI);
        }
    }
}
