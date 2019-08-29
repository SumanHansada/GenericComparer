using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int[] Marks { get; set; }

        public override bool Equals(Object obj)
        {
            Student studentObj = obj as Student;
            if (studentObj == null)
                return false;
            else
                return Name.Equals(studentObj.Name) && Id.Equals(studentObj.Id) && Marks.SequenceEqual(studentObj.Marks);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode() + Marks.GetHashCode();
        }
    }
}
