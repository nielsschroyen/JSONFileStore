using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONFileStore.Test
{
    [TestClass]
    public class ApiTests
    {
        private const string TempDir = @"c:\temp";

        [TestMethod]
        public void ReadComplexTest()
        {
            const string filename = "ReadComplexTest.txt";
            const string content = "{\"Members\":[{\"Age\":28,\"Name\":\"Niels Schroyen\"},{\"Age\":1,\"Name\":\"Lowie Schroyen\"},{\"Age\":28,\"Name\":\"Elke Vanheers\"}]}";
            FileHelper.Write(TempDir + @"\" + filename, content);
            var fileStore = new FileStore(TempDir, filename);

            var family = fileStore.Read<Familiy>();

            Assert.AreEqual(3, family.Members.Count);
            Assert.IsTrue(family.Members.Any(person => person.Name.Equals("Niels Schroyen", StringComparison.InvariantCulture)));
        }

        [TestMethod]
        public void ReadNoneExistingFileTest()
        {
            const string filename = "ReadNoneExistingFileTest.txt";
            var fileStore = new FileStore(TempDir, filename);

            var person = fileStore.Read<Person>();

            Assert.IsTrue(person == null);
        }

        [TestMethod]
        public void ReadSimpleTest()
        {
            const string filename = "ReadSimpleTest.txt";
            const string content = "{\"Age\":28,\"Name\":\"Niels Schroyen\"}";
            FileHelper.Write(TempDir + @"\" + filename, content);
            var fileStore = new FileStore(TempDir, filename);
            var person = fileStore.Read<Person>();
            Assert.AreEqual(28, person.Age);
            Assert.AreEqual("Niels Schroyen", person.Name);
        }

        [TestMethod]
        public void WriteComplexTest()
        {
            const string filename = "WriteComplexTest.txt";
            var niels = new Person
            {
                Age = 28,
                Name = "Niels Schroyen"
            };

            var lowie = new Person
            {
                Age = 1,
                Name = "Lowie Schroyen"
            };

            var elke = new Person
            {
                Age = 28,
                Name = "Elke Vanheers"
            };

            var family = new Familiy
            {
                Members = new List<Person> { niels, lowie, elke }
            };

            var fileStore = new FileStore(TempDir, filename);
            fileStore.Write(family);

            const string content = "{\"Members\":[{\"Age\":28,\"Name\":\"Niels Schroyen\"},{\"Age\":1,\"Name\":\"Lowie Schroyen\"},{\"Age\":28,\"Name\":\"Elke Vanheers\"}]}";

            Assert.AreEqual(content, FileHelper.Read(TempDir + @"\" + filename));
        }

        [TestMethod]
        public void WriteSimpleTest()
        {
            const string filename = "WriteSimpleTest.txt";
            var person = new Person
              {
                  Age = 28,
                  Name = "Niels Schroyen"
              };

            var fileStore = new FileStore(TempDir, filename);
            fileStore.Write(person);
            const string content = "{\"Age\":28,\"Name\":\"Niels Schroyen\"}";
            Assert.AreEqual(content, FileHelper.Read(TempDir + @"\" + filename));
        }
    }
}