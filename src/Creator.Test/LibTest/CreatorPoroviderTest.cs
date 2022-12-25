using Creator.Lib;
using NUnit.Framework;

namespace Creator.Test.LibTest
{
    [TestFixture]
    internal class CreatorPoroviderTest
    {
        [Test]
        public void GetCsharpCodeTest()
        {
            ICreatorPorovider creatorPorovider = new CreatorPorovider(@"~/Code/");
            Task.Factory.StartNew(() =>
            {
                creatorPorovider.GetCsharpCode("Service", "Creator.Test.LibTest", "Test", null);
            });
        }
    }
}
