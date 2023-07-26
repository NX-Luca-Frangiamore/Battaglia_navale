using Battaglia_navale;

namespace Battaglia_navale
{
    class Manager
    {
        public class turno
        {
            private int i;
            public int go()
            {
                i = (i == 0) ? 1 : 0;
                return i;
            }
            public int get() { return i; }
        }
        public readonly int xMappa,yMappa;//dimensione mappa
        private Campo[] campi=new Campo[2];
        public turno t;
        public Manager(int xMappa,int yMappa) {
            this.xMappa = xMappa;
            this.yMappa = yMappa;
        }
        public void loop()
        {
            campi[t.get()].loop();
            t.go();//alterno i due campi
        }
        public bool shoot(int x,int y)
        {
            return campi[t.get()].hit(x,y);
        }

    }
    class Campo
    {
        public List<Nave> flotta;
       
        public bool hit(int x, int y) {
            
            foreach(Nave n in flotta)
            {
                if (n.checkHitted(x, y))
                    return true;
                   
            }
            return false;
        }
        public void loop()
        {
            foreach (Nave n in flotta)
            {
                n.shoot();
            }
        }
    }
    
}
