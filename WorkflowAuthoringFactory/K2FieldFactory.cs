using System;
using System.Collections.Generic;
using System.Text;
using SourceCode.Workflow.Authoring;
using SourceCode.Workflow.Design;

namespace SourceCode.Workflow.Authoring.Sample.Factory
{
    public sealed class K2FieldFactory
    {
        public static K2Field CreateK2Field(DataField dataField)
        {
            return new K2Field(new DataFieldPart(dataField));
        }
        public static K2Field CreateK2Field(XmlField xmlField)
        {
            return new K2Field(new XmlFieldPart(xmlField));
        }
        public static K2Field CreateK2Field(string value)
        {
            return CreateK2Field<string>(value);
        }
        public static K2Field CreateK2Field(bool value)
        {
            return CreateK2Field<bool>(value);
        }
        public static K2Field CreateK2Field(DateTime value)
        {
            return CreateK2Field<DateTime>(value);
        }
        public static K2Field CreateK2Field(decimal value)
        {
            return CreateK2Field<decimal>(value);
        }
        public static K2Field CreateK2Field(double value)
        {
            return CreateK2Field<double>(value);
        }
        public static K2Field CreateK2Field(int value)
        {
            return CreateK2Field<int>(value);
        }
        public static K2Field CreateK2Field(long value)
        {
            return CreateK2Field<long>(value);
        }
        public static K2Field CreateK2Field(short value)
        {
            return CreateK2Field<short>(value);
        }

        public static K2Field CreateK2Field(Type valueType)
        {
            K2Field field = new K2Field();
            field.ValueType = valueType;
            return field;
        }
        public static K2Field CreateK2Field(Type valueType, params K2FieldPart[] fieldParts)
        {
            K2Field field = new K2Field(fieldParts);
            field.ValueType = valueType;
            return field;
        }

        public static K2Field CreateK2FieldFormat(string format, params object[] args)
        {
            K2Field field = new K2Field();
            field.ValueType = typeof(string);

            if (args.Length == 0)
            {
                field.Value = format;
                return field;
            }

            int state = 0;

            StringBuilder buffer = new StringBuilder();

            foreach (char c in format)
            {
                switch (c)
                {
                    case '{':
                        if (state != 0)
                            throw new FormatException("Input string was not in a correct format.");
                        state = 1;
                        break;
                    case '}':
                        if (state != 2)
                            throw new FormatException("Input string was not in a correct format.");                            
                        state = 3;
                        break;
                }

                switch (state)
                {
                    case 0: // normal
                        buffer.Append(c);
                        break;
                    case 1: // begin indexer
                        if (buffer.Length > 0)
                        {
                            if (field.Parts.Count > 0 && field.Parts[field.Parts.Count - 1] is ValueTypePart)
                            {
                                field.Parts[field.Parts.Count - 1].Value = string.Concat(field.Parts[field.Parts.Count - 1].Value, buffer.ToString());
                            }
                            else
                            {
                                field.Parts.Add(new ValueTypePart(buffer.ToString()));
                            }
                        }
                        buffer = new StringBuilder();
                        state = 2;
                        break;
                    case 2: // inside indexer
                        buffer.Append(c);
                        break;
                    case 3: // end indexer
                        int idx = int.Parse(buffer.ToString());

                        if (args[idx] == null)
                        {
                            throw new InvalidOperationException("One of the arguments have a null value.");
                        }

                        K2FieldPart partToAdd = null;

                        if (args[idx].GetType().IsValueType)
                        {
                            partToAdd = new ValueTypePart(args[idx].ToString());
                        }
                        else if (args[idx] is K2FieldPart)
                        {
                            partToAdd = args[idx] as K2FieldPart;
                        }
                        else if (args[idx] is string)
                        {
                            partToAdd = new ValueTypePart(args[idx] as string);
                        }
                        else
                        {
                            throw new InvalidOperationException("One of the arguments have is an unsupported type.");
                        }

                        if (field.Parts.Count >= 1 && partToAdd is ValueTypePart)
                        {
                            // If the previous field part is also a value type part
                            // merge the values
                            if (field.Parts[field.Parts.Count - 1] is ValueTypePart)
                            {
                                field.Parts[field.Parts.Count - 1].Value = string.Concat(field.Parts[field.Parts.Count - 1].Value, partToAdd.Value);
                            }
                        }
                        else
                        {
                            field.Parts.Add(partToAdd);
                        }

                        buffer = new StringBuilder();
                        state = 0;
                        break;
                }
            }

            // process last part of the buffer
            if (buffer.Length > 0)
            {
                if (field.Parts.Count == 0)
                {
                    field.Parts.Add(new ValueTypePart(buffer.ToString()));
                }
                else if (field.Parts[field.Parts.Count - 1] is ValueTypePart)
                {
                    field.Parts[field.Parts.Count - 1].Value = string.Concat(field.Parts[field.Parts.Count - 1].Value, buffer.ToString());
                }
                else
                {
                    field.Parts.Add(new ValueTypePart(buffer.ToString()));
                }
            }

            return field;
        }

        private static ValueTypePart CreateValueTypePart(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (!value.GetType().IsValueType)
                throw new InvalidOperationException("Value type expected.");

            ValueTypePart fieldPart = new ValueTypePart();
            fieldPart.Value = value;
            fieldPart.ValueType = value.GetType();
            return fieldPart;
        }

        private static K2Field CreateK2Field<TValueType>(object value)
        {
            ValueTypePart fieldPart = new ValueTypePart();
            fieldPart.Value = value;
            fieldPart.ValueType = typeof(TValueType);

            return CreateK2Field<TValueType>(fieldPart);
        }
        private static K2Field CreateK2Field<TValueType>(K2FieldPart fieldPart)
        {
            K2Field field = new K2Field(fieldPart);
            field.ValueType = typeof(TValueType);
            return field;
        }

    }
}
