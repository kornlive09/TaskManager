using DB.Model;
using DB.Repository;

namespace BL.Helpers
{
    public class InitDb
    {
        IBl _bl;

        public InitDb()
        {
            this._bl = new Bl(new UnitOfWork());
            this._bl.Add(null, "Первая задача");
            //this.FillingList();
            this._bl.Dispose();
        }

        //private void FillingList(params int[] branch)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        this._bl.Add((long?)null, "Задача - " + i.ToString());

        //        for (int k = 0; k < 3; k++)
        //        {
        //            this._bl.Add(, "Задача - " + i.ToString() + " _ " + k.ToString());
        //        }

        //    }
        //}

    }
}
