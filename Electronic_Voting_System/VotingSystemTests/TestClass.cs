// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Electronic_Voting_System;

namespace VotingSystemTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestSaveXML()
        {
            ElectionManagementSystem sys = new ElectionManagementSystem();
            Assert.IsTrue(sys.Register("leUsername", "contrasena", "daEmail", "05/24/1970", 123456789, "Frank", "Pullman"));
            Assert.IsTrue(sys.Register("otherUser", "contrasena", "daEmail", "07/30/1830", 123456789, "Bob", "Pullman"));
            Assert.IsTrue(sys.StartNewElection("05/08/2021", "05/10/2021"));
            sys.SetMinWinPercentage(75);
            sys.AddCandidate("Jane Doe", "Fiesta");
            sys.AddCandidate("Henry Joe", "Any-and-all");
            sys.SaveXML();
        }

        [Test]
        public void TestSaveXML(ref ElectionManagementSystem sys)
        {
            sys = new ElectionManagementSystem();
            Assert.IsTrue(sys.Register("leUsername", "contrasena", "daEmail", "05/24/1970", 123456789, "Frank", "Pullman"));
            Assert.IsTrue(sys.Register("otherUser", "contrasena", "daEmail", "07/30/1830", 123456789, "Bob", "Pullman"));
            Assert.IsTrue(sys.StartNewElection("05/08/2021", "05/10/2021"));
            sys.SetMinWinPercentage(75);
            sys.AddCandidate("Jane Doe", "Fiesta");
            sys.AddCandidate("Henry Joe", "Any-and-all");
            sys.SaveXML();
        }

        [Test]
        public void TestLoadXML()
        {
            ElectionManagementSystem sys = new ElectionManagementSystem();
            this.TestSaveXML(ref sys);
            sys = new ElectionManagementSystem();
            sys.LoadXML();
        }
    }
}
