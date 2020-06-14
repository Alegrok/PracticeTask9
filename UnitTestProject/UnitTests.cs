using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PracticeTask9.Program;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod01()
        {
            uint size = 5;
            BiList biList = BiList.MakeList(size);
            int count = BiList.GetCount(biList);
            Assert.AreEqual(size, (uint) count);
        }

        [TestMethod]
        public void TestMethod02()
        {
            uint size = 10;
            BiList biList = BiList.MakeList(size);
            int count = BiList.GetCountRecurent(biList);
            Assert.AreEqual(size, (uint) count);
        }
    }
}
