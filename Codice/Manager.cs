using Battaglia_navale;

namespace Battaglia_navale
{
    class Manager
    {
        public readonly int xMappa,yMappa;//dimensione mappa
        private Campo[] campi=new Campo[2];
        int t = 0;
        public Manager(int xMappa,int yMappa) {
            this.xMappa = xMappa;
            this.yMappa = yMappa;
        }
        public void loop()
        {
            campi[t].loop();
            t = (t == 0) ? 1 : 0;//alterno i due campi
        }
        public bool shoot(int x,int y)
        {
            return campi[t].hit(x,y);
        }

    }
    interface ICampo
    {
        bool hit(int x, int y);//cerco e colpisco una nave in posizione x,y
                                         

    }
    class Campo:ICampo
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
