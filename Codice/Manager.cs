using Battaglia_navale;
namespace Battaglia_navale
{
    class Manager
    {
        public static int xMappa,yMappa;
        private Campo[] campi = new Campo();
        int t = 0;
       

    }
    interface ICampo
    {
        public void hit(int x, int y);//cerco e colpisco una nave in posizione x,y
                                         

    }
    class Campo:ICampo
    {
        public List<Nave> flotta;
       
        void ICampo.hit(int x, int y) {
            
            foreach(Nave n in flotta)
            {
                if (n.hit(x, y))
                    break;
            }
        }
       
    }
    
}
