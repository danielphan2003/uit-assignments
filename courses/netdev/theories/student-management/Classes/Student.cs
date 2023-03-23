using System;

namespace student_management
{
    public class Student
    {
        public virtual string Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime Birth { get; set; }

        public virtual string Address { get; set; }
    }
}
