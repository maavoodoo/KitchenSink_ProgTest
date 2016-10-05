using Starcounter;

namespace KitchenSink
{
    [Database]
    public class SortableList
    {
        public int ListNo;
        public int PersonCount;
        public QueryResultRows<Person> Persons
        {
            get
            {
                /*
                *  Was thinking of adding ORDER BY Position but im not sure that is the proper way to do things.
                */ 
                return Db.SQL<Person>("SELECT r FROM Person r WHERE r.SortableList=?", this);
            }
        }

        public SortableList()
        {
            PersonCount = 1;
            new Person()
            {
                SortableList = this,
                Position = PersonCount
            };
        }
    }

    [Database]
    public class Person
    {
        public SortableList SortableList;
        public string Name;
        public int Position;
        
    }
}