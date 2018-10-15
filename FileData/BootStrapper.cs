using System;
using System.IO;
using ThirdPartyTools;

namespace FileData
{
    /// <summary>
    /// Class BootStrapper accepts parameter and interact with FileData Core Logic/service based on rule defined.
    /// </summary>
    public class BootStrapper
    {
        private string functionToPerform = string.Empty;
        private string filePath = string.Empty;

        /// <summary>
        /// Constructor for BootStratper class - Getting and Initialize FunctionalityToPerform and FilePath only once.
        /// </summary>
        /// <param name="args">Commond line arguments passed.</param>
        public BootStrapper(string[] args)
        {
            // I considered here for restricion of 2 parameter however it could be greater than 2 as well.
            if (args.Length != 2)
            {
                throw new ArgumentException("Invalid argument length supplied");
            }

            //// For Flexibilty case is factored to make it lowercase.
            this.functionToPerform = FunctionalityTypeRequested(args[0].ToLower());
            this.filePath = ValidateFileName(args[1]);
        }

        /// <summary>
        /// Process file for Data : Version OR Size.
        /// </summary>
        /// <returns></returns>
        public string ProcessFile()
        {
            try
            {
                var fileDetails = new FileDetails();
                var result = string.Empty;
                if (functionToPerform == "version")
                {
                    result = "Version : " + fileDetails.Version(filePath);
                }
                else if (functionToPerform == "size")
                {
                    result = "Size :" + (fileDetails.Size(filePath)).ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                //// Log details in file.
                throw new Exception(string.Format("Error occurs during operation {0} for file {1} @ {2} || Error Details : {3}", functionToPerform, filePath, DateTime.Now.ToString("dd-MMM-yyyy HH:MM:SS"), ex.Message));
            }
        }



        /// <summary>
        /// Functionality requested - Can be used Enum if more methods and to avoid human error instead of hard code like below.
        /// </summary>
        /// <param name="functionParameter"></param>
        /// <returns>version OR Size.</returns>
        private string FunctionalityTypeRequested(string functionParameter)
        {
            switch (functionParameter)
            {
                case "-v":
                case "--v":
                case "/v":
                case "--version":
                    return "version";
                case "-s":
                case "--s":
                case "/s":
                case "--size":
                    return "size";
                default:
                    throw new ArgumentException(string.Format("Incorrect function type requested [{0}]", functionParameter));
            }
        }

        /// <summary>
        /// Verify if filepath supplied have filename.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ValidateFileName(string filePath)
        {
            if (string.IsNullOrWhiteSpace(Path.GetFileName(filePath)))
            {
                throw new ArgumentException(string.Format("Invalid filename:{0}", filePath));
            }
            Console.WriteLine(string.Format("File Name :{0}", filePath));
            return filePath;
        }
    }

}
