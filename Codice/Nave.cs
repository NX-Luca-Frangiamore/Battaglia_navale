
namespace Battaglia_navale
{
    interface INave
    {
        public bool shoot(int x,int y);
        public bool hitted(int x, int y);
        public bool move(int x, int y);
        public (int, int) getAssolutPosition(int x,int y);//con x,y relativi
        public (int, int) getAssolutPosition(Parts);
        private bool checkParts(Parts);//controllo che le posizioni delle parti siano valide
    }
    record class Parts
    {
        public int x;
        public int y;
    }
    class Nave : INave
    {
        public Dictionary<string, Parts> body;//permette di assemblare la nave, id="x,y"; x,y sono relativi
        public int x;
        public int y;
        private Manger manger;
        public (int, int) getAssolutPosition(int x, int y) //con x,y relativi
        {
            return (this.x+x,this.y+y);
        }
        public bool hitted(int xr, int yr)
        {
            (int x, int y) = getAssolutPosition(xr, yr);
            if (body.ContainsKey(x + "," + y)) return true;
            return false;
        }
        public bool move(int x, int y)
        {
            foreach(var part in body)
            {
                if (checkPart(part) == false)
                    return false;
            }
            return true;
        }


    }

}