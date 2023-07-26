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
            public int prevision() { return (i == 0) ? 1 : 0; }
        }
        public readonly int xMappa,yMappa;//dimensione mappa
        private Campo[] campi=new Campo[2];
        public turno t;
        public Manager(int xMappa,int yMappa) {
            this.xMappa = xMappa;
            this.yMappa = yMappa;
            campi[0] = new Campo();
            campi[1] = new Campo(); 
            t=new turno();  
        }
        public void loop()
        {
            Console.WriteLine($"turno {t.get()}");
            campi[t.get()].loop();
            t.go();//alterno i due campi
        }
        public bool shoot(int x,int y)
        {
            return campi[t.prevision()].hit(x,y);
        }
        public void addNave(TypeBody t,int x,int y,int iC) { 
            Nave n=new Nave(t,x,y, this);
            campi[iC].Add(n);
        }
        public void addNave(int iC)
        {
            Nave n = new Nave(this);
            campi[iC].Add(n);
        
        }

    }
    class Campo
    {
        public List<Nave> flotta;
        public Campo()
        {
            flotta=new List<Nave> ();
        }
        public void Add(Nave n) => flotta.Add(n);
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
                Console.WriteLine(n.shoot());
            }
        }
    }
    
}
