
namespace Battaglia_navale
{
    interface INave
    {
         bool shoot(int x,int y);
         bool shoot();
         bool checkHitted(int x, int y);
         bool move(int x, int y);
         (int, int) getAssolutPosition(int x,int y);//con x,y relativi
         (int, int) getAssolutPosition(Parts part);
         
    }
    class Nave : INave
    {
        private Dictionary<string, Parts> body;//permette di assemblare la nave, id="x,y"; x,y sono relativi
        public int x;
        public int y;
        private Manager manager;
        public Nave(TypeBody t)
        {
            body=Type.getBody(t);
        }
        public (int, int) getAssolutPosition(int x, int y) //con x,y relativi
        {
            return (this.x+x,this.y+y);
        }
        public (int, int) getAssolutPosition(Parts part) { return getAssolutPosition(part.x, part.y); }//con x,y relativi

        public bool shoot(int x, int y)
        {
            return manager.shoot(x,y); 
        }
        public bool shoot()
        {
            int x, y;
            Console.WriteLine("inserisci coordinata x");
            x= Int32.Parse(Console.ReadLine());
            Console.WriteLine("inserisci coordinata y");
            y = Int32.Parse(Console.ReadLine());
            return shoot(x, y);
        }
        public bool checkHitted(int xr, int yr)
        {
            (int x, int y) = getAssolutPosition(xr, yr);
            if (body.ContainsKey(x + "," + y)) return true;
            return false;
        }
        private bool checkPart(Parts part)
        {//controllo che le posizioni delle parti siano valide
            (int x, int y) = getAssolutPosition(part);
            if(x<0 || x> manager.xMappa )    
                return false;
            if (y < 0 || y > manager.yMappa)
                return false;
            //!devo verificare che le parti non si sovrappongono
            return true;
        }

        public bool move(int x, int y)
        {
            foreach(var part in body)
            {
                if (checkPart(part.Value) == false)
                    return false;
            }
            this.x=x; this.y=y; 
            return true;
        } 



    }

}