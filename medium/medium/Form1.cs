using System.Collections;

namespace medium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdButton_Click(object sender, EventArgs e)
        {
            DB db = new DB(4);

            db.persons[0] = new Person(2);
            db.persons[1] = new Person(6);
            db.persons[2] = new Person(3);
            db.persons[3] = new Person(10);
            Array.Sort(db.persons);


            Medium m = new DVD("Something");
            db.Add(m);
            DVD d = new DVD("John Wick");
            
            m = d;
            db.Add(m);
            CD c = new CD("Green Day");
            d = c;
            db.Add(d);

            for (int i = 0; i < 3; i++)
            {
                txtbox.Text += db.Medias[i].Title + "\r\n";
            }

            txtbox.Text += m.Ausgeben();
            
        }
    }
}