using System;
using System.Data;

namespace Types
{
   public struct ParmStruct
    {
    public string Name;
    public object Value;
    public int Size;
    public SqlDbType DataType;
    public ParameterDirection Direction;

        public ParmStruct(string name, object value, SqlDbType dataType, ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            Name = name;
            Value = value;
            Size = size;
            DataType = dataType;
            Direction = direction;
        }
    }
}
