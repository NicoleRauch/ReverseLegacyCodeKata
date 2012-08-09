using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;

namespace TriviaTest
{
    [TestClass]
    public class GameRunnerTest
    {
        private StringBuilder _output;
        TextWriter textWriter;

        [TestInitialize]
        public void SetUp()
        {
            _output = new StringBuilder();
            textWriter = new StringWriter(_output);
            Console.SetOut(textWriter);
        }

        [TestMethod]
        public void Main_Run_CompareWithOriginal()
        {
            string expected = File.ReadAllText("master.txt");

            GameRunner.main(null);
            
            Assert.AreEqual(expected, _output.ToString());
        }

        [TestMethod]
        public void Main_CreateNewMaster_WritesNewMasterTxt()
        {
            GameRunner.main(null);

            File.WriteAllText("newMaster.txt", textWriter.ToString());
        }
    }
}
