#region Namespaces
using AKQATask.Controllers;
using AKQATask.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Web.Http;
#endregion

#region Main Code
namespace AKQATask.Tests
{
    [TestClass]
    public class UnitTest
    {
        #region Declarations
        public const string RESULT_MESSAGE = "ONE HUNDRED AND TWENTY-THREE DOLLERS AND FOURTY-FIVE CENTS";
        public const string DEFAULT_VALUE = "123.45";
        public const string NAME_PARAMETER = "John Smith";
        public const string NAME_VALUE = "123.45";
        #endregion

        #region Methods
        /// <summary>
        /// Test for constant value returned from 123.45
        /// Result will be passed if the value = "ONE HUNDRED TWENTY THREE DOLLERS AND FOUR FIVE CENTS ONLY"
        /// </summary>
        [TestMethod]
        public void ConvertToWordTestForSpecificValue()
        {
            var controller = new ResultAPIController();
            var model = new TaskModel() { Name = NAME_PARAMETER, Value = NAME_VALUE };
            var result = controller.ConvertToWord(model) as TaskModel;
            Assert.AreEqual(RESULT_MESSAGE, result.ResultText);
        }

        /// <summary>
        /// Check if the passed number and converted text is not as per expected result
        /// </summary>
        [TestMethod]
        public void ConvertToWordTestForNotGetingExpectedResult()
        {
            var controller = new ResultAPIController();
            var model = new TaskModel() { Name = NAME_PARAMETER, Value = NAME_VALUE };
            var result = controller.ConvertToWord(model) as TaskModel;
            Assert.AreNotEqual(DEFAULT_VALUE, result.ResultText);
        }       
        #endregion 
    }
}
#endregion