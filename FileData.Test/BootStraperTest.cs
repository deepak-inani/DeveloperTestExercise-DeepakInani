using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileData.Test
{
    [TestClass]
    public class BootStraperTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BootStraper_Constructor_WithoutArgument()
        {
            string[] args = { };
            BootStrapper bootStraper = new BootStrapper(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BootStraper_Constructor_WithOneArgumentVersion()
        {
            string[] args = { "--v" };
            BootStrapper bootStraper = new BootStrapper(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BootStraper_Constructor_WithOneArgumentFileName()
        {
            string[] args = { "c:\file.Text" };
            BootStrapper bootStraper = new BootStrapper(args);
        }

        [TestMethod]
        public void BootStraper_Constructor_WithTwoArgumentOperationAndFileName()
        {
            string[] args = { "-v", @"c:\test.txt" };
            BootStrapper bootStraper = new BootStrapper(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BootStraper_Constructor_WithValidOperationAndInvalidFileName()
        {
            string[] args = { "-t", @"c:\test.txt" };
            BootStrapper bootStraper = new BootStrapper(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BootStraper_Constructor_WithInValidOperationAndvalidFileName()
        {
            string[] args = { "-s", @"c:\" };
            BootStrapper bootStraper = new BootStrapper(args);
        }

        /// <summary>
        /// Version Parameter: -v.
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetVersion_1()
        {
            string[] args = { "-v", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Version"));
        }

        /// <summary>
        /// Version Parameter: --v.
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetVersion_2()
        {
            string[] args = { "--v", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Version"));
        }

        /// <summary>
        /// Version Parameter - /v.
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetVersion_3()
        {
            string[] args = { "/v", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Version"));
        }

        /// <summary>
        /// Version paramter :  --version.
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetVersion_4()
        {
            string[] args = { "--version", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Version"));
        }

        /// <summary>
        /// Size Parameter : -s
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetSize_1()
        {
            string[] args = { "-s", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Size"));
        }


        /// <summary>
        /// Size Parameter : --s.
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetSize_2()
        {
            string[] args = { "--s", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Size"));
        }

        /// <summary>
        /// Size Parameter : /s.
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetSize_3()
        {
            string[] args = { "/s", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Size"));
        }

        /// <summary>
        /// Size parameter : --size.
        /// </summary>
        [TestMethod]
        public void BootStrapper_ProcessFile_GetSize_4()
        {
            string[] args = { "-s", @"c:\test.txt" };
            BootStrapper bootStrapper = new BootStrapper(args);
            Assert.IsNotNull(bootStrapper.ProcessFile());
            Assert.IsTrue(bootStrapper.ProcessFile().Contains("Size"));
        }

    }
}
