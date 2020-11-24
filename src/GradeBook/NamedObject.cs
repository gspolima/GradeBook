using System;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject()
        {
        }
        
        public NamedObject(string name)
        {
            Name = name;
        }

        private string name;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (MatchStringPattern(value))
                {
                    name = value;
                }
            }
        }
        
        public bool MatchStringPattern(string value)
        {
            if (IsNullOrEmpty(value) || IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Empty values are not valid for this field");
            }
            else if (CanConvertToDouble(value))
            {
                throw new FormatException($"Numeric values are not valid for this field");
            }
            else
            {
                return true;
            }
        }

        public bool IsNullOrEmpty(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool IsNullOrWhiteSpace(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool CanConvertToDouble(string value)
        {
            if (Double.TryParse(value, out double output))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}