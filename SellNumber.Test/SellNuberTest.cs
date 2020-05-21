using Microsoft.VisualStudio.TestTools.UnitTesting;
using SellNumber;

namespace SellNumber.Test
{
    [TestClass]
    public class SellNuberTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string number = "55555";

            SellNumberCls sellNumber = new SellNumberCls(number);
            Assert.Equals(number, sellNumber.GetSpell());
        }
    }
}
