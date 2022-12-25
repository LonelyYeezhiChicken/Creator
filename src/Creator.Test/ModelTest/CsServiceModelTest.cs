using Creator.Model.Template.CSharp;
using NUnit.Framework;

namespace Creator.Test.ModelTest
{
    [TestFixture]
    internal class CsServiceModelTest
    {
        [Test]
        public void GetTest()
        {
            CsService csService = new(@"Creator.Model.Template.CSharp", "Test");
            string actual = csService.Get();

            string expected = @"namespace Creator.Model.Template.CSharp
{
 internal interface ITest
    {
       
    }


internal class TestService : ITest
    {
       
    }
}";
            Console.WriteLine(actual);

            Assert.AreEqual(actual, expected);
        }

    }
}
