/*
  This file is part of  https://github.com/aiten/Framework.

  Copyright (c) Herbert Aitenbichler

  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
  to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
  and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
  WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/

namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class CsvImport<T> : CsvImportBase where T : new()
    {
        public class ColumnMapping
        {
            public string       ColumnName { get; set; }
            public PropertyInfo MapTo      { get; set; }
            public bool         Ignore     { get; set; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            public Func<string, object?>  GetValue    { get; set; }
            public Func<object?, object?> AdjustValue { get; set; }
            public Action<T, string>      SetValue    { get; set; }

#pragma warning restore CS8632

            public bool IsConfigured => Ignore || MapTo != null || SetValue != null;
            public bool IsMapped     => !Ignore && MapTo != null;
            public bool IsSetValue   => !Ignore && SetValue != null;
        }

        public ICollection<string>         IgnoreColumns { get; set; }
        public IDictionary<string, string> MapColumns    { get; set; }

        public IList<T> Read(string[] csvLines)
        {
            var lines = ReadStringMatrixFromCsv(csvLines, false);
            return MapTo(lines);
        }

        public IList<T> Read(string fileName)
        {
            var lines = ReadStringMatrixFromCsv(fileName, false);
            return MapTo(lines);
        }

        public async Task<IList<T>> ReadAsync(string fileName)
        {
            var lines = await ReadStringMatrixFromCsvAsync(fileName, false);
            return MapTo(lines);
        }

        public IList<T> MapTo(IList<IList<string>> lines)
        {
            // first line is columnLineHeader!!!!

            var mapping = GetPropertyMapping(lines[0]);
            CheckPropertyMapping(mapping);

            var list  = new List<T>();
            var first = true;

            foreach (var line in lines)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    list.Add(Map(line, mapping));
                }
            }

            return list;
        }

        private void CheckPropertyMapping(ColumnMapping[] mapping)
        {
            var notConfigured = mapping.Where(m => !m.IsConfigured).ToList();
            if (notConfigured.Any())
            {
                var columnList = string.Join(", ", notConfigured.Select(m => m.ColumnName));
                throw new ArgumentException($"Column cannot be mapped: {columnList}");
            }

            var notCanWrite = mapping.Where(x => x.IsMapped && !x.MapTo.CanWrite).ToList();
            if (notCanWrite.Any())
            {
                var columnList = string.Join(", ", notCanWrite.Select(m => m.ColumnName));
                throw new ArgumentException($"Column is readonly: {columnList}");
            }
        }

        protected virtual ColumnMapping[] GetPropertyMapping(IList<string> columnNames)
        {
            return columnNames
                .Select(GetColumnMapping)
                .ToArray();
        }

        public Action<ColumnMapping> ConfigureColumnMapping { get; set; }

        protected virtual ColumnMapping GetColumnMapping(string columnName)
        {
            var ignoreColumn = IgnoreColumns?.Contains(columnName, StringComparer.InvariantCultureIgnoreCase) ?? false;
            var mapToColumn  = (MapColumns?.ContainsKey(columnName) ?? false) ? MapColumns[columnName] : columnName;

            var columnMapping = new ColumnMapping
            {
                ColumnName = columnName,
                Ignore     = ignoreColumn,
                MapTo      = ignoreColumn ? null : GetPropertyInfo(mapToColumn),
            };

            ConfigureColumnMapping?.Invoke(columnMapping);
            return columnMapping;
        }

        public static PropertyInfo GetPropertyInfo(string columnName)
        {
            return typeof(T).GetProperty(columnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }

        private T Map(IList<string> line, ColumnMapping[] mapping)
        {
            var newT = new T();

            var idx = 0;
            foreach (var column in line)
            {
                AssignProperty(newT, column, mapping[idx++]);
            }

            return newT;
        }

#pragma warning disable 8632
        private object? GetValue(string valueAsString, Type type)
#pragma warning restore 8632
        {
            if (type.IsGenericType && type.Name.StartsWith(@"Nullable"))
            {
                if (string.IsNullOrEmpty(valueAsString))
                {
                    return null;
                }

                type = type.GenericTypeArguments[0];
            }

            if (type == typeof(string))
            {
                return ExcelString(valueAsString);
            }
            else if (type == typeof(int))
            {
                return ExcelInt(valueAsString);
            }
            else if (type == typeof(long))
            {
                return ExcelLong(valueAsString);
            }
            else if (type == typeof(short))
            {
                return ExcelShort(valueAsString);
            }
            else if (type == typeof(uint))
            {
                return ExcelUInt(valueAsString);
            }
            else if (type == typeof(ulong))
            {
                return ExcelULong(valueAsString);
            }
            else if (type == typeof(ushort))
            {
                return ExcelUShort(valueAsString);
            }
            else if (type == typeof(decimal))
            {
                return ExcelDecimal(valueAsString);
            }
            else if (type == typeof(byte))
            {
                return ExcelByte(valueAsString);
            }
            else if (type == typeof(bool))
            {
                return ExcelBool(valueAsString);
            }
            else if (type == typeof(DateTime))
            {
                return ExcelDateOrDateTime(valueAsString);
            }
            else if (type == typeof(TimeSpan))
            {
                return ExcelTimeSpan(valueAsString);
            }
            else if (type == typeof(double))
            {
                return ExcelDouble(valueAsString);
            }
            else if (type.IsEnum)
            {
                return ExcelEnum(type, valueAsString);
            }
            else if (type == typeof(byte[]))
            {
                return ExcelImage(valueAsString);
            }

            throw new NotImplementedException();
        }

        private void AssignProperty(object obj, string valueAsString, ColumnMapping mapping)
        {
            if (mapping.IsSetValue)
            {
                mapping.SetValue((T)obj, valueAsString);
            }
            else if (mapping.IsMapped)
            {
                var mapTo = mapping.MapTo;
#pragma warning disable 8632
                object? val = mapping.GetValue != null
                    ? mapping.GetValue(valueAsString)
                    : GetValue(valueAsString, mapTo.PropertyType);
#pragma warning restore 8632

                if (mapping.AdjustValue != null)
                {
                    val = mapping.AdjustValue(val);
                }

                mapTo.SetValue(obj, val);
            }
        }
    }
}