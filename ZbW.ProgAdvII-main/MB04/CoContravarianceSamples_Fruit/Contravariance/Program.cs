// See https://aka.ms/new-console-template for more information

using Contravariance;


FirstExample();
//SimpleExample();
//SortingWithInterface();
//SortingWithDelegate();

void FirstExample() {
    var appleAction = new MyAction<Apple>(a => Console.WriteLine($"Weight of Apple: {a.Weight}"));
    PerformAppleAction(appleAction);

    var bananaAction = new MyAction<Banana>(b => Console.WriteLine($"Weight of Banana: {b.Weight}"));
    PerformAppleAction(bananaAction);

    var fruitAction = new MyAction<Fruit>(f => Console.WriteLine($"Weight of Fruit: {f.Weight}"));
    PerformAppleAction(fruitAction);
}

void PerformAppleAction(MyAction<Apple> zebraAction) {
    var apple = new Apple { Weight = 600 };
    zebraAction(apple);
}


void SimpleExample() {
    ICovariant<Apple> covariantApples = new Covariant<Apple>();

    ICovariant<Fruit> covariantFruit = covariantApples;

    IContravariant<Fruit> contravariantFruit = new Contravariant<Fruit>();

    IContravariant<Apple> contravariantApples = contravariantFruit;
}



void FirstSample()
{
    BagOfFruits fruits = new BagOfApples();
    fruits.Add(new Apple { Name = "Granny Smith", Weight = 80, ForEating = true });
    fruits.Add(new Banana { Name = "Blue Java", Weight = 60});

    Console.WriteLine(fruits.Get(0));
    Console.WriteLine(fruits.Get(1));
}

void SortingWithInterface() {
    var apples = new List<Apple> {
        new Apple { Name = "Granny Smith", Weight = 80, ForEating = true },
        new Apple { Name = "Arthur Turner", Weight = 70, ForEating = false },
        new Apple { Name = "Honeygold", Weight = 80, ForEating = true },
        new Apple { Name = "Kerry Pippin", Weight = 82, ForEating = true },
        new Apple { Name = "Newton Wonder", Weight = 75, ForEating = false }
    };

    foreach (var apple in apples)
        Console.WriteLine(apple);

    Console.WriteLine();

    apples.Sort(new FruitComparer());


    foreach (var apple in apples)
        Console.WriteLine(apple);

    Console.WriteLine();
    Console.WriteLine();

    var bananas = new List<Banana> {
        new Banana { Name = "Blue Java", Weight = 108 },
        new Banana { Name = "Cavendish", Weight = 103 },
        new Banana { Name = "Gros Michel", Weight = 105 },
        new Banana { Name = "Baby", Weight = 78 }
    };

    foreach (var banana in bananas)
        Console.WriteLine(banana);

    Console.WriteLine();

    bananas.Sort(new FruitComparer());


    foreach (var banana in bananas)
        Console.WriteLine(banana);

}

void SortingWithDelegate()
{
    var apples = new List<Apple>
    {
        new Apple {Name = "Granny Smith", Weight = 80, ForEating = true },
        new Apple {Name = "Arthur Turner", Weight = 70, ForEating = false },
        new Apple {Name = "Honeygold", Weight = 80, ForEating = true },
        new Apple {Name = "Kerry Pippin", Weight = 82, ForEating = true },
        new Apple {Name = "Newton Wonder", Weight = 75, ForEating = false }
    };

    foreach (var apple in apples)
        Console.WriteLine(apple);

    Console.WriteLine();

    SortingDelegate<Fruit> sorter = (l, r) => (int)(l.Weight - r.Weight);

    apples.Sort((l, r) => sorter(l,r));

    foreach (var apple in apples)
        Console.WriteLine(apple);
}

public interface MyEnumerable<out T> {
    T GetElementAt(int index);

    //void AddElement(T element);
}