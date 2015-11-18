using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Aegis;



namespace RPGGame.Common.Excel
{
    public enum DataType
    {
        Int,
        Double,
        DateTime,
        String
    }



    public class ExcelSheet
    {
        private ExcelLoader _parent;
        private Sheet _sheet;
        private SharedStringTablePart _sstp;
        private IEnumerator<Row> _iter;
        private FieldInfo[] _fields;
        private UInt32 _maxRowIndex;
        private Int32 _rowCount;


        public ExcelLoader ExcelLoader { get { return _parent; } }
        public UInt32 MaxRowIndex { get { return _maxRowIndex; } }
        public Int32 RowCount { get { return _rowCount; } }
        public String Name { get { return _sheet.Name; } }
        public FieldInfo[] Fields { get { return _fields; } }
        public Row CurrentRow { get { return _iter.Current; } }





        internal ExcelSheet(ExcelLoader parent, Sheet sheet)
        {
            _parent = parent;
            _sheet = sheet;
        }


        public ExcelSheet Load()
        {
            WorkbookPart wbp = _parent.Workbook.WorkbookPart;
            WorksheetPart wsp = (WorksheetPart)wbp.GetPartById(_sheet.Id.Value);
            SheetData sheetData = wsp.Worksheet.GetFirstChild<SheetData>();


            _iter = sheetData.Elements<Row>().GetEnumerator();
            _sstp = wbp.GetPartsOfType<SharedStringTablePart>().First();
            _rowCount = sheetData.Elements<Row>().Count();
            _maxRowIndex = sheetData.Elements<Row>().Max(v => v.RowIndex.Value);


            //  Field 정보
            if (_parent.RowIndex_FieldName >= 0)
            {
                Row row;
                Int32 idx;


                //  Field name
                idx = 0;
                row = sheetData.Elements<Row>().Where(v => v.RowIndex == _parent.RowIndex_FieldName).FirstOrDefault();
                if (row == null)
                    throw new AegisException("FieldName index is {0}, but {1} has no {0} row index.", _parent.RowIndex_FieldName, _sheet.Name);
                _fields = new FieldInfo[row.LongCount()];


                foreach (Cell cell in row.Elements<Cell>())
                {
                    _fields[idx] = new FieldInfo();
                    _fields[idx].Name = GetTextInCell(cell);
                    ++idx;
                }


                //  Field data type
                idx = 0;
                row = sheetData.Elements<Row>().Where(v => v.RowIndex == _parent.RowIndex_DataType).First();
                foreach (Cell cell in row.Elements<Cell>())
                {
                    String text = GetTextInCell(cell).ToLower();

                    if (text == "int" || text == "integer")
                        _fields[idx++].DataType = DataType.Int;

                    else if (text == "double")
                        _fields[idx++].DataType = DataType.Double;

                    else if (text == "datetime")
                        _fields[idx++].DataType = DataType.DateTime;

                    else if (text == "string")
                        _fields[idx++].DataType = DataType.String;

                    else
                        throw new AegisException("Invalid field type at {0}.{1}", _sheet.Name, cell.CellReference);
                }
            }

            return this;
        }


        private String GetTextInCell(Cell cell)
        {
            String text = "";
            String cellRef = cell.CellReference;


            //  Cell의 Text 값 얻어오기
            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
            {
                Int32 ssid = Int32.Parse(cell.CellValue.Text);
                text = _sstp.SharedStringTable.ChildElements[ssid].InnerText;
            }
            else if (cell.CellValue != null)
                text = cell.CellValue.Text;

            return text;
        }


        public FieldInfo GetFieldInfo(Int32 index)
        {
            if (_fields == null || _fields.Count() <= index)
                throw new AegisException("Field index out of range.");

            return _fields[index];
        }


        public IEnumerable<FieldInfo> GetFields()
        {
            if (_fields == null)
                throw new AegisException("'{0}' sheet has no fields.", _sheet.Name);

            foreach (FieldInfo info in _fields)
                yield return info;
        }


        public Boolean NextRow()
        {
            if (_iter.Current == null)
            {
                //  Enumerator를 DataRowIndex까지 이동
                while (_iter.Current == null || _iter.Current.RowIndex != _parent.RowIndex_DataRow)
                {
                    if (_iter.MoveNext() == false)
                        return false;
                }

                return true;
            }

            return _iter.MoveNext();
        }


        public CellValue GetCellValue(String fieldName)
        {
            if (_fields == null)
                throw new AegisException("'{0}' sheet has no field information.", _sheet.Name);


            //  필드 위치 찾기
            Int32 fieldIdx = 0;
            foreach (FieldInfo fieldInfo in _fields)
            {
                if (StringComparer.OrdinalIgnoreCase.Equals(fieldInfo.Name, fieldName) == true)
                    break;
                ++fieldIdx;
            }

            if (fieldIdx >= _fields.Count())
                throw new AegisException("There is no field name('{0}') in '{1}' sheet.", fieldName, _sheet.Name);

            if (fieldIdx >= _iter.Current.Elements<Cell>().Count())
                throw new AegisException("Out of cell index({0}) at '{1}' {2} row", fieldIdx, _sheet.Name, _iter.Current.RowIndex);


            Cell cell = _iter.Current.Elements<Cell>().Where(v => GetColumnIndex(v) == fieldIdx).FirstOrDefault();

            return GetCellValue(cell, _fields[fieldIdx]);
        }


        public IEnumerable<CellValue> GetCellValues()
        {
            Int32 idx = 0;


            if (_fields == null)
                throw new AegisException("'{0}' sheet has no field information.", _sheet.Name);

            foreach (Cell cell in _iter.Current.Elements<Cell>())
                yield return GetCellValue(cell, _fields[idx++]);
        }


        private CellValue GetCellValue(Cell cell, FieldInfo fieldInfo)
        {
            String text = GetTextInCell(cell);


            if (text == "")
            {
                if (fieldInfo.DataType == DataType.Int)
                    return new CellValue(fieldInfo, (Int32)0);

                if (fieldInfo.DataType == DataType.Double)
                    return new CellValue(fieldInfo, (Double)0);

                return new CellValue(fieldInfo, null);
            }

            else if (fieldInfo.DataType == DataType.DateTime)
            {
                DateTime value;
                Double dblValue;

                if (DateTime.TryParse(text, out value) == true)
                    return new CellValue(fieldInfo, value);

                else if (Double.TryParse(text, out dblValue) == true)
                    return new CellValue(fieldInfo, DateTime.FromOADate(dblValue));

                else
                    throw new AegisException("Invalid data at {0}.{1}", _sheet.Name, cell.CellReference);
            }

            else if (fieldInfo.DataType == DataType.Int)
            {
                Int32 value;
                if (Int32.TryParse(text, out value) == true)
                    return new CellValue(fieldInfo, value);

                else
                    throw new AegisException("Invalid data at {0}.{1}", _sheet.Name, cell.CellReference);
            }

            else if (fieldInfo.DataType == DataType.Double)
            {
                Double value;
                if (Double.TryParse(text, out value) == true)
                    return new CellValue(fieldInfo, value);

                else
                    throw new AegisException("Invalid data at {0}.{1}", _sheet.Name, cell.CellReference);
            }

            else
                return new CellValue(fieldInfo, text);
        }


        private Int32 GetColumnIndex(Cell cell)
        {
            Int32 startIdx = cell.CellReference.Value.IndexOfAny("0123456789".ToCharArray());
            String column = cell.CellReference.Value.Substring(0, startIdx);


            //  26진수 -> 10진수
            {
                Int32 dec = 0;
                Int32 powVal = column.Length - 1;

                foreach (char c in column)
                    dec += (c - 'A' + 1) * (Int32)Math.Pow(26, powVal--);

                return dec - 1;
            }
        }
    }
}
