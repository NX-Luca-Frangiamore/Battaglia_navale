using Battaglia_navale;
using System.Security.Cryptography.X509Certificates;

game g = new game();
g.start(5);





class game
{

    Manager m = new Manager(10, 10);
    public void start(int nNavi)
    {
        start(nNavi,0);
        start(nNavi, 1);
    }
    private void start(int nNavi, int campo) { 
         for(int i = 0; i < nNavi; i++)
         {
            m.addNave(0);
         }
    }
    public void loop()
    {
        m.loop();
        m.printMappa();
        this.loop();
    }
}
