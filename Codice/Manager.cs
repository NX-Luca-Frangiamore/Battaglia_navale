namespace Battaglia_navale.Battaglia_navale
{
    interface IManager
    {



    }
    interface Campo
    {
        public Nave get(int x, int y);//cerca una nave con posizione x,y
        public void hit(int x, int y);//cerca ed in caso affonda nave

    }
}
