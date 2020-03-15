using HangMan.BLL;
using HangMan.BLL.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanTest
{
    [TestFixture]
    public class HangmanTest
    {
        GameManager hangman;

        [SetUp]
        public void SetUp()
        {
            hangman = GameManagerFactory.Create();// new StaticChoice();
        }

        [Test]
        public void TestGetChoice()
        {
            Assert.AreEqual("Word", hangman._guessWord);
        }
    }
}
