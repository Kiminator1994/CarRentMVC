<Query Kind="Program" />


    void Main() {
        var Students = new Student[] {
            new Student {Name = "John", Id = 2009001, Subject = "Computing"},
            new Student {Name = "Ann", Id = 2009002, Subject = "Mathematics"},
            new Student {Name = "Sue", Id = 2009003, Subject = "Computing"},
            new Student {Name = "Bob", Id = 2009004, Subject = "Mathematics"}
        };



        var Markings = new Marking[] {
            new Marking {StudentId = 2009001, Course = "Programming", Mark = 3},
            new Marking {StudentId = 2009001, Course = "Databases", Mark = 2},
            new Marking {StudentId = 2009001, Course = "Computer Graphics", Mark = 1},
            new Marking {StudentId = 2009002, Course = "Organic Chemistry", Mark = 1}
        };


		var sequences = new[] {1, 2, 3};
		
		var q = from s in sequences 
		        from w in s //.Split(',')
			    select w;
				
				
		var allwords = sequences.Select(s => s.Split(','));
Console.WriteLine(q);

            var q1 =
                from s in Students
                from m in Markings
                where s.Id == m.StudentId
                select s.Name + ", " + m.Course + ", " + m.Mark;
				 
		Console.WriteLine(q);

          
    }


class Student {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }

}

class Marking {
    public int StudentId { get; set; }
    public string Course { get; set; }
    public int Mark { get; set; }
}