using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MFCcontrol
{
    class SShtLoad
    {
        private const string sheetName = "Sheet1";
        private List<string[]> tableLoad = new List<string[]>();
        private List<string[]> tableLoadDigOut = new List<string[]>();

        public bool[] LoadMFCstate(string fileName)
        {
            bool[] returnArray = new bool[Properties.Settings.Default.MFCcontrol_numMFCs];

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that Sheet object
                // to retrieve a reference to the appropriate worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part, and then use its Worksheet property to get 
                // a reference to the cell whose address matches the address you've supplied:
                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                int numCols = Properties.Settings.Default.MFCcontrol_numMFCs + 1;

                string[] currentRow = new string[numCols];

                currentRow = XLGetRowMFC(numCols, 1.ToString(), wsPart);

                for (int i = 1; i <= Properties.Settings.Default.MFCcontrol_numMFCs; i++)
                {
                    if (Convert.ToDouble(currentRow[i]) > 0)
                        returnArray[i - 1] = true;
                    else
                        returnArray[i - 1] = false;
                }
            }

            return returnArray;

        }

        public int[] LoadMFCmaxFlows(string fileName)
        {
            int[] returnArray = new int[Properties.Settings.Default.MFCcontrol_numMFCs];

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that Sheet object
                // to retrieve a reference to the appropriate worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part, and then use its Worksheet property to get 
                // a reference to the cell whose address matches the address you've supplied:
                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                int numCols = Properties.Settings.Default.MFCcontrol_numMFCs + 1;

                string[] currentRow = new string[numCols];

                currentRow = XLGetRowMFC(numCols, 2.ToString(), wsPart);

                for (int i = 1; i <= Properties.Settings.Default.MFCcontrol_numMFCs; i++)
                {
                    returnArray[i - 1] = Convert.ToInt32(currentRow[i]);
                }
            }

            return returnArray;

        }

        // returns numSwitchMatrixRows x numSwitchMatrix sized List containing states in device scan spreadsheet
        public List<string[]> LoadDeviceList(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that Sheet object
                // to retrieve a reference to the appropriate worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part, and then use its Worksheet property to get 
                // a reference to the cell whose address matches the address you've supplied:
                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                int numCols = 34;
                
                //start at this row in the spreadsheet file
                int rowIterator = 2;

                string[] currentRow = new string[numCols];

                for (int i = 1; i <= 4; i++)
                {
                    currentRow = XLGetDeviceRow(numCols, rowIterator.ToString(), wsPart);

                    tableLoad.Add(currentRow);
                    rowIterator += 3;
                }
            }

            return tableLoad;

            }
        
        
        
        public List<string[]> LoadMfc(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that Sheet object
                // to retrieve a reference to the appropriate worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part, and then use its Worksheet property to get 
                // a reference to the cell whose address matches the address you've supplied:
                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                int numCols = Properties.Settings.Default.MFCcontrol_numMFCs + 1;
                
                //start at this row in the spreadsheet file
                int rowIterator = 4;

                string[] currentRow = new string[numCols];

                while (true)
                {
                    currentRow = XLGetRowMFC(numCols, rowIterator.ToString(), wsPart);

                    // stop loading spreadsheet once you hit -1 in the first column of a row
                    if (Convert.ToDouble(currentRow[0]) < 0)
                    {
                        break;
                    }

                    tableLoad.Add(currentRow);
                    rowIterator++;
                }
            }

            return tableLoad;
        }

        public List<string[]> LoadDigOut(string fileName, int numRows)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that Sheet object
                // to retrieve a reference to the appropriate worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part, and then use its Worksheet property to get 
                // a reference to the cell whose address matches the address you've supplied:
                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                int numCols = Properties.Settings.Default.DigitalOutputNumLines;

                //start at this row in the spreadsheet file
                int rowIterator = 4;

                string[] currentRow = new string[numCols];

                for (int i = 0; i < numRows; i++)
                {
                    currentRow = XLGetRowDigOut(numCols, rowIterator.ToString(), wsPart);

                    // stop loading spreadsheet once you hit -1 in the first column of a row

                    tableLoadDigOut.Add(currentRow);
                    rowIterator++;
                }
            }

            return tableLoadDigOut;
        }

        public static string[] XLGetRowDigOut(int numCols, string sSheetRowNum, WorksheetPart wsPart)
        {
            string[] returnList = new string[numCols];
            int returnListIterator = 0;

            for (char c = 'J'; c <= 'Q'; c++)
            {
                returnList[returnListIterator] = XLGetCellValue(wsPart, c + sSheetRowNum);
                returnListIterator++;
            }

            return returnList;
        }



        public static string[] XLGetRowMFC(int numCols, string sSheetRowNum, WorksheetPart wsPart)
        {
            string[] returnList = new string[numCols];
            int returnListIterator = 0;

            for (char c = 'A'; c <= 'I'; c++)
            {
                returnList[returnListIterator] = XLGetCellValue(wsPart, c + sSheetRowNum);
                returnListIterator++;
            }

            return returnList;
        }

        public static string[] XLGetDeviceRow(int numCols, string sSheetRowNum, WorksheetPart wsPart)
        {
            string[] returnList = new string[numCols];
            int returnListIterator = 0;

            for (char c = 'B'; c <= 'Z'; c++)
            {
                returnList[returnListIterator] = XLGetCellValue(wsPart, c + sSheetRowNum);
                returnListIterator++;
            }
            for (char c = 'A'; c <= 'I'; c++)
            {
                returnList[returnListIterator] = XLGetCellValue(wsPart, "A" + c + sSheetRowNum);
                returnListIterator++;
            }

            return returnList;
        }



        // XLGetCellValue returns a string containing the cell value at certain cell (addressName)
        // This function does not work on cells that contain strings

        public static string XLGetCellValue(WorksheetPart wsPart, string addressName)
        {
            string value = null;


            Cell theCell = wsPart.Worksheet.Descendants<Cell>().
              Where(c => c.CellReference == addressName).FirstOrDefault();

            // If the cell doesn't exist, return an empty string:
            if ((theCell != null) && (theCell.CellValue != null) )
            {
                //value = theCell.InnerText;

                /*  To retrieve just the value */
                value = theCell.CellValue.InnerText;


                // If the cell represents an integer number, you're done. 
                // For dates, this code returns the serialized value that 
                // represents the date. The code handles strings and booleans
                // individually. For shared strings, the code looks up the corresponding
                // value in the shared string table. For booleans, the code converts 
                // the value into t he words TRUE or FALSE.
                if (theCell.DataType != null)
                {
                    switch (theCell.DataType.Value)
                    {
                        //case CellValues.SharedString:
                        //    // For shared strings, look up the value in the shared strings table.
                        //    var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                        //    // If the shared string table is missing, something's wrong.
                        //    // Just return the index that you found in the cell.
                        //    // Otherwise, look up the correct text in the table.
                        //    if (stringTable != null)
                        //    {
                        //        value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                        //    }
                        //    break;

                        case CellValues.Boolean:
                            switch (value)
                            {
                                case "0":
                                    value = "FALSE";
                                    break;
                                default:
                                    value = "TRUE";
                                    break;
                            }
                            break;
                    }
                }
            }

            return value;
        }




    }
}
