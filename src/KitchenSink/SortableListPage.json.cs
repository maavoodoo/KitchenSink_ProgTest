using Starcounter;

namespace KitchenSink
{
    partial class SortableListPage : Page, IBound<SortableList>
    {
        protected override void OnData()
        {
            base.OnData();
        }
        /*
        *  AddPerson, Save and Cancel Handlers are all functions from the Invoice demo with slight changes.
        */
        void Handle(Input.AddPerson action)
        {
            Data.PersonCount += 1;
            new Person()
            {
                SortableList = Data,
                Position = Data.PersonCount
            };
        }

        void Handle(Input.Save action)
        {
            bool isUnsavedList = (ListNo == 0);
            if (isUnsavedList)
            {
                ListNo = (int)Db.SQL<long>(
                  "SELECT max(i.ListNo) FROM SortableList i").First + 1;
            }
            Transaction.Commit();
        }

        void Handle(Input.Cancel action)
        {
            bool isUnsavedList = (ListNo == 0);
            Transaction.Rollback();
            if (isUnsavedList)
            {
                Data = new SortableList();
            }
        }

        /*
         * Not the prettiest reset button as it clears all lists not just the active one,
         * but it was cleaner for me to work with.
        */ 
        void Handle(Input.ResetData action)
        {
            Db.SlowSQL("DELETE FROM Person");
            Db.SlowSQL("DELETE FROM SortableList");
            Data = new SortableList();
        }
        
    }
}