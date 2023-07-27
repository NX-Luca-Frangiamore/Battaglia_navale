using Battaglia_navale;
namespace Test.Integration
{
    public class TestCampo
    {
        [Fact]
        public void aggiuntaNaveInCampo()
        {
            Manager.xMappa = 3;
            Manager.yMappa = 3;
            Campo campo= new Campo();
            campo.Add(new Nave(TypeBody.Quadrata, 0, 0, null));
            Assert.Equal(campo.printCaselle(), "False False False \nTrue True False \nTrue True False \n");
           
        }
        [Fact]
        public void affondareNave()
        {
            Manager.xMappa = 3;
            Manager.yMappa = 3;
            Campo campo = new Campo();
            campo.Add(new Nave(TypeBody.Quadrata, 0, 0, null));

            campo.hit(0, 0);
            Assert.Equal(campo.printCaselle(), "False False False \nFalse False False \nFalse False False \n");

        }
        [Fact]
        public void mancareNave()
        {
            Manager.xMappa = 3;
            Manager.yMappa = 3;
            Campo campo = new Campo();
            campo.Add(new Nave(TypeBody.Quadrata, 0, 0, null));

            campo.hit(2,2);
            Assert.Equal(campo.printCaselle(), "False False False \nTrue True False \nTrue True False \n");

        }
    }
}
