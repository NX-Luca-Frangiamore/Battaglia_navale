namespace Battaglia_navale
{
    interface INave
    {
         bool shoot(int x,int y);
         bool shoot();
         bool checkHitted(int x, int y);

         (int, int) getAssolutPosition(int x,int y);/// <summary>x,y assoluti;ritorno x,y relati, alla posizione della nave</summary>
        (int, int) getAssolutPosition(Parts part);
         
    }
    class Nave : INave
    {
        private Dictionary<string, Parts> body;/// <summary>permette di assemblare la nave, id="x,y"; x,y sono posizione assoluti</summary>
        public int x;
        public int y;
        private Manager manager;
        
        public Nave(TypeBody t,int x,int y,Manager manager)
        {
          
            this.manager = manager;
            body=Type.getBody(t);
            this.x = x; this.y = y;

        }
        public Dictionary<string, Parts> getBody() { return body; }
        public Nave(Manager manager, TypeBody t = TypeBody.Lunga)
        {
            this.manager = manager;
            Console.WriteLine("inserisci posizione");
            int xin = Int32.Parse(Console.ReadLine());
            Console.WriteLine("inserisci posizione");
            int yin= Int32.Parse(Console.ReadLine());
            body = Type.getBody(t);
            this.x = xin; this.y = yin;

        }
        public (int, int) getAssolutPosition(int x, int y)
        {
            return (this.x+x,this.y+y);
        }
        public (int, int) getAssolutPosition(Parts part) { return getAssolutPosition(part.x, part.y); }

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
            (int x,int y)= (this.x - xr, this.y - yr);
             if (body.ContainsKey(x + "," + y)) return true;
          
            
            return false;
        }
        private bool checkPart(Nave nave) { return false; }
       
    }

}