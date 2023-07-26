
namespace Battaglia_navale
{
    interface INave
    {
        public bool shoot(int x,int y);
        public bool move(int x, int y);
        public bool checkParts(int x,int y);
    }
    record class Parts
    {
        public int x;
        public int y;
    }
    class Nave : INave
    {
        public Dictionary<string, Parts> body;
        public int x;
        public int y;
        private Manger manger;

    }

}