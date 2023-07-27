
using Newtonsoft.Json;

namespace Test.Unit
{
    public class TestTypeNave
    {
        [Fact]
        public void ottenimentoBodyNave()
        {
            Dictionary<string, Parts> body = Type.getBody(TypeBody.Lunga);
            Dictionary<string, Parts> bodyTest = new Dictionary<string, Parts>();
            bodyTest["0,0"] = new Parts(0, 0);
            bodyTest["0,1"] = new Parts(0, 1);
            bodyTest["0,2"] = new Parts(0, 2);
            Assert.Equal(JsonConvert.SerializeObject(body), JsonConvert.SerializeObject(bodyTest));


            body = Type.getBody(TypeBody.Larga);
            bodyTest = new Dictionary<string, Parts>();
            bodyTest["0,0"] = new Parts(0, 0);
            bodyTest["1,0"] = new Parts(1, 0);
            bodyTest["2,0"] = new Parts(2, 0);
            Assert.Equal(JsonConvert.SerializeObject(body), JsonConvert.SerializeObject(bodyTest));

        }
    }
}