using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PaxDrive.Enum
{
    public class Enumeration : Enumeration<string>
    {
        protected Enumeration(string name, string value) : base(name, value)
        {
        }
    }

    public class Enumeration<ValueType>
    {
        protected Enumeration(string name, ValueType value)
        {
            Name  = name;
            Value = value;
        }

        public string Name { get; }
        public ValueType Value { get; }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration<ValueType>
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>().ToList();
        }

        public bool Equals(Enumeration<ValueType>? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Value.ToString() == other.Value.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Enumeration<ValueType>) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Value);
        }

        public static T GetByValue<T>(object value) where T : Enumeration<ValueType>
        {
            return GetAll<T>().FirstOrDefault(x => x.Value.ToString() == value.ToString());
        }
    }
}