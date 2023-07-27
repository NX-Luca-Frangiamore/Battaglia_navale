using Battaglia_navale;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

game g = new game();
g.start(1);
g.loop();




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
            m.addNave(campo);
         }
    }
    public void loop()
    {
        Console.Write(m.printMappa());
        if (!m.loop())
            return;
        this.loop();
    }
}
