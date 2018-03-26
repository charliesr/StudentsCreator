using StudentCreator.Models;
using System.Collections;
using System.Collections.Generic;

namespace StudentCreatorXUnitTests
{
    /* Generamos un enumerabvle para que actue con el Theory del XUnit. Ha de ser así porque no se le peude pasar en InLine valores de clase como new 
    la clase a saco */
    public class StudentDataGenerator : IEnumerable<object[]>
    {
        
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"student", new Student {
                ID = 1,
                Nombre = "Carlos",
                Apellidos = "Sanchez Romero",
                DNI = "54545454F"
                }
            },
            new object[] {"student", new Student {
                ID = 2,
                Nombre = "Carlos2",
                Apellidos = "Sanchez2",
                DNI = "64646464G"
                }
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
