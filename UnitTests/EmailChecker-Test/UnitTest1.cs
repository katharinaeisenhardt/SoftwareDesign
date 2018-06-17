using System;
using Xunit;

namespace EmailChecker_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string mailaddress = "irgendwas@web.de";
            bool result = Program.IsEmailAdress(mailaddress);
            Assert.True(result, "Expected " + mailaddress + " to be a valid email address.");
        }
        [Fact]
        public void Test2()
        {
            string mailaddress = "@web.de";
            bool result = Program.IsEmailAdress(mailaddress);
            Assert.False(result, "Expected " + mailaddress + " to be an invalid email address.");
        }
        [Fact]
        public void Test3()
        {
            string mailaddress = "test@eins.zwei.de";
            bool result = Program.IsEmailAdress(mailaddress);
            Assert.True(result, "Expected " + mailaddress + " to be a valid email address.");
        }
        [Fact]
        public void Test4()
        {
            string mailaddress = "a.b@eins.zwei.de";
            bool result = Program.IsEmailAdress(mailaddress);
            Assert.True(result, "Expected " + mailaddress + " to be a valid email address.");
        }
        [Fact]
        public void Test5()
        {
            string mailaddress = "a@.";
            bool result = Program.IsEmailAdress(mailaddress);
            Assert.False(result, "Expected " + mailaddress + " to be an invalid email address.");
        }
    }
}
