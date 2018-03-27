using StudentCreator.Models;
using System;
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
            new object[] {new Student (Guid.NewGuid(),1,"Carlos","Sanchez Romero","54545454F")
            },
            new object[] {new Student (Guid.NewGuid(),2,"Carlos2","Sanchez2","64646464G")
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
