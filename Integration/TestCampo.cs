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


        [Theory]
        [InlineData(TypeBody.Quadrata, 3, 0)]
        [InlineData(TypeBody.Lunga, 0, 2)]
        public void fuoriuscitaMappa(TypeBody t, int x, int y)
        {
            Manager.xMappa = 4;
            Manager.yMappa = 4;
            Campo campo = new Campo();

            Assert.False(campo.Add(new Nave(t, x, y, null)));
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
