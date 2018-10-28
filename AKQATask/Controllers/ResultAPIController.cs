#region Namespaces
using AKQATask.Models;
using System;
using System.Text.RegularExpressions;
using System.Web.Http;
#endregion

#region Main Code
namespace AKQATask.Controllers
{
    public class ResultAPIController : ApiController
    {
        #region Declarations
        public const string ERROR_COMMON = "<div style=\"background-color:red; color: white\">Entered Value is not Numeric. Pass number like \"123.45\"</div>";
        #endregion

        #region API Method
        /// <summary>
        /// This method will return the result of the converted string from the passed number
        /// </summary>
        /// Call will be /api/converttoword
        /// <returns>string</returns>
        [HttpPost]
        public TaskModel ConvertToWord(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResultText = ConvertToWords(model.Value).ToUpper();
            }
            else
            {
                model.ResultText = ERROR_COMMON;
            }
            return model;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Check the Value parameter is numeric or not
        /// </summary>
        /// <param name="numb"></param>
        /// <returns></returns>
        private static string CheckNumber(string numb)
        {
            bool isValid = Regex.IsMatch(numb, @"^\d+\.?\d*$");
            if (!isValid)
            {
                return ERROR_COMMON;
            }
            return string.Empty;
        }

        /// <summary>
        /// This function will convert number to words
        /// </summary>
        /// <param name="numb">pass the number entered in Value field</param>
        /// <returns>String of passed number</returns>
        private static string ConvertToWords(string numb)
        {
            var valid = CheckNumber(numb);
            if (!string.IsNullOrEmpty(valid))
                return valid;
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = string.Empty;
            try
            {
                andStr = "dollers";
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr += " and ";// just to separate whole numbers from points/cents  
                        endStr = "cents" + endStr;//Cents  
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }

        /// <summary>
        /// Convert Whole number without decimal section
        /// </summary>
        /// <param name="Number">pass the number entered in Value field</param>
        /// <returns>String of passed number</returns>
        private static string ConvertWholeNumber(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range

                            word = Ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = Tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        //if transalation is not done, continue...(Recursion comes in now!!)
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                //Get Rest of the number
                                var restnum = ConvertWholeNumber(Number.Substring(pos));

                                //If there is no rest number then do not add "and" else do add.
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + (string.IsNullOrEmpty(restnum) ? string.Empty : "and " + restnum);
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }                        
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        /// <summary>
        /// This function will retruns string with respect to Tens
        /// </summary>
        /// <param name="Number">pass the number for getting word in Tens </param>
        /// <returns>String of passed number</returns>
        private static String Tens(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = Tens(Number.Substring(0, 1) + "0") + "-" + Ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        /// <summary>
        /// This function will retruns string with respect to Ones
        /// </summary>
        /// <param name="Number">pass the number for getting word in Ones</param>
        /// <returns>String of passed number</returns>
        private static String Ones(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String ConvertDecimals(String number)
        {
            //Return Tens value like Fourty-Five for decimal fraction
            return Tens(number);
        }
        #endregion
    }
}
#endregion