using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Aegis;



namespace RPGGame.Common.Excel
{
    public class ExcelLoader : IDisposable
    {
        private String _filename;
        private SpreadsheetDocument _workbook;

        private readonly Int32 _indexFieldName, _indexDataType, _indexDataRow;
        private readonly Int32 _sheetCount;


        public Int32 RowIndex_FieldName { get { return _indexFieldName; } }
        public Int32 RowIndex_DataType { get { return _indexDataType; } }
        public Int32 RowIndex_DataRow { get { return _indexDataRow; } }
        public Int32 SheetCount { get { return _sheetCount; } }

        internal SpreadsheetDocument Workbook { get { return _workbook; } }





        public ExcelLoader(String filename, Int32 fieldNameIndex = 2, Int32 dataTypeIndex = 3, Int32 dataRowStartIndex = 4)
        {
            _filename = filename;
            _indexFieldName = fieldNameIndex;
            _indexDataType = dataTypeIndex;
            _indexDataRow = dataRowStartIndex;
            _workbook = SpreadsheetDocument.Open(_filename, false);


            Sheets sheets = _workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
            _sheetCount = (sheets == null ? 0 : sheets.Count());
        }


        public ExcelSheet GetSheet(String sheetName)
        {
            Sheets sheets = _workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
            foreach (Sheet sheet in sheets)
            {
                if (sheet.Name.Value.ToLower() == sheetName.ToLower())
                    return new ExcelSheet(this, sheet);
            }

            throw new AegisException("'{0}' is not exists in '{1}'", sheetName, _filename);
        }


        public IEnumerable<ExcelSheet> GetSheets()
        {
            Sheets sheets = _workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
            foreach (Sheet sheet in sheets)
                yield return new ExcelSheet(this, sheet);
        }


        public void Dispose()
        {
            _workbook.Close();
            _workbook = null;
        }
    }


    public struct FieldInfo
    {
        private String _name;
        private DataType _type;


        public String Name
        {
            get { return _name; }
            internal set { _name = value; }
        }
        public DataType DataType
        {
            get { return _type; }
            internal set { _type = value; }
        }


        public FieldInfo(String name, DataType type)
        {
            _name = name;
            _type = type;
        }
    }


    public struct CellValue
    {
        private FieldInfo _field;
        private dynamic _value;


        public FieldInfo FieldInfo { get { return _field; } }
        public dynamic Value { get { return _value; } }


        internal CellValue(FieldInfo field, dynamic value)
        {
            _field = field;
            _value = value;
        }
    }
}
