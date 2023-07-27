using Battaglia_navale;

namespace Battaglia_navale
{
    class Manager
    {
        private class turno
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
        public static int xMappa,yMappa;//dimensione mappa
        private Campo[] campi=new Campo[2];
        private turno t;
        private static void setDimentionMapp(int xMappa, int yMappa) { 
            (Manager.xMappa, Manager.yMappa) = (xMappa, yMappa); 
        }
     
        public Manager(int xMappa,int yMappa) {
            Manager.setDimentionMapp(xMappa, yMappa);
            campi[0] = new Campo();
            campi[1] = new Campo(); 
            t=new turno();  
        }
        public void loop()
        {
            Console.WriteLine($"tocca al campo {t.get()}");
            campi[t.get()].loop();
            
            t.go();//alterno i due campi
            if (campi[t.get()].flotta.Count <= 0)
            {
                
                Console.Write($"fine, a perso il campo {t.get()}");
                return;
            }
        }
        public bool shoot(int x,int y)
        {
            return campi[t.prevision()].hit(x,y);
        }
        public void addNave(TypeBody t,int x,int y,int iC) { 
            Nave n=new Nave(t,x,y, this);
            if(!campi[iC].Add(n))Console.Write("non puoi inserire la nave");
        }
        public void addNave(int iC)
        {
            Nave n = new Nave(this);
            if (!campi[iC].Add(n)) Console.Write("non puoi inserire la nave");

        }
        public void printMappa()
        {
            campi[0].printCaselle();

            Console.WriteLine("---------");
            campi[1].printCaselle();

        }

    }
    class Campo
    {
        public List<Nave> flotta;
        private Nave[,]? caselle=new Nave[Manager.xMappa,Manager.yMappa]; //tipo nave in modo da poter semplicaficare la ricerca nelle caselle, per sparo
        public Campo()
        {
            flotta=new List<Nave> ();
            
        }
        public bool Add(Nave n) { ///<summary>aggiungo la nave nelle caselle, controllando se è possibile</summary>

            foreach (KeyValuePair<string, Parts> p in n.getBody())
            {
                (int x, int y) = n.getAssolutPosition(p.Value);//trasformo le coordinate relative delle singole parti della nave in coordinate assolute
                if (caselle[x,y] != null) return false;
               
            }
            modificaCaselle(n);
            
            flotta.Add(n);
            return true;
        }
        private void modificaCaselle(Nave n)
        {
            foreach (KeyValuePair<string, Parts> p in n.getBody())
            {
                (int x, int y) = n.getAssolutPosition(p.Value);//trasformo le coordinate relative delle singole parti della nave in coordinate assolute
                caselle[x,y] = n;
            }
        }
        public bool hit(int x, int y) {
            if (caselle[x, y] != null){

                var tNave = caselle[x, y];
                
                foreach (KeyValuePair<string, Parts> p in tNave.getBody())
                {
 
                    (int xA, int yA) = tNave.getAssolutPosition(p.Value);//trasformo le coordinate relative delle singole parti della nave in coordinate assolute
                    caselle[xA, yA] = null;
                }

                flotta.Remove(tNave);
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
        public void printCaselle()
        {
            for (int y = Manager.yMappa-1; y >=0; y--)
            {
                for (int x = 0; x < Manager.xMappa; x++)
                    Console.Write((caselle[x, y]!=null)+" ");
                Console.WriteLine();
            }
        }
    }
    
}
