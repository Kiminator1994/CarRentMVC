using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Linq.LambdaExpressions.AnonymousTypes {
    class Student {
        public string Name;
        public int Id;
        public string Subject { get; set; }

        public Student() {
        }

        public Student(string name) {
            Name = name;
        }
    }

    public class Examples {
        public void Test() {
            var a = new {Id = 1, Name = "John"};
            var b = new {a.Id, a.Name};

            var studentList = new List<Student>();
            studentList.Add(new Student { Subject = "aaa", Id = 1 });
            studentList.Add(new Student { Subject = "aaa", Id = 2 });
            studentList.Add(new Student { Subject = "aaa", Id = 3 });
            studentList.Add(new Student { Subject = "bbb", Id = 10 });
            studentList.Add(new Student { Subject = "bbb", Id = 11 });
            var groupList = studentList
                .GroupBy(s => s.Subject);
            foreach (var g in groupList) {

            }
            var q = studentList
                .GroupBy(s => s.Subject)
                .Select(grp => new {Subject = grp.Key, Count = grp.Count()});

        }


    }



    //[CompilerGenerated]
    //[DebuggerDisplay("{ Id = {Id}, Name = {Name} }", Type = "<Anonymous Type>")]
    //internal sealed class <>f__AnonymousType0<<Id>j__TPar, <Name>j__TPar>
    //{
    //    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    //    private readonly <Id>j__TPar <Id>i__Field;
    //    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    //    private readonly <Name>j__TPar <Name>i__Field;

    //    public <Id>j__TPar Id
    //    {
    //        get
    //        {
    //            return this.<Id>i__Field;
    //        }
    //    }
    //    public <Name>j__TPar Name
    //    {
    //        get
    //        {
    //            return this.<Name>i__Field;
    //        }
    //    }

    //    [DebuggerHidden]
    //    public <>f__AnonymousType0(<Id>j__TPar Id, <Name>j__TPar Name)
    //    {
    //        this.<Id>i__Field = Id;
    //        this.<Name>i__Field = Name;
    //    }

    //    [DebuggerHidden]
    //    public override bool Equals(object value)
    //    { /* ... */ return true; }

    //    [DebuggerHidden]
    //    public override int GetHashCode()
    //    { /* ... */ return 0; }

    //    [DebuggerHidden]
    //    public override string ToString()
    //    { /* ... */ }

    //}

}