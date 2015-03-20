namespace HomeworkOOP_DefiningClassesTwo
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
    AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]

    public class VersionAttribute : Attribute
    {
        private string name;
        private string version;
        private Type typeEnum;

        public Type TypeEnum
        {
            get { return typeEnum; }
            set { typeEnum = value; }
        }

        //constructor
        public VersionAttribute(Type typeEnum, string name, string version)
        {
            this.TypeEnum = typeEnum;
            this.Name = name;
            this.Version = version;
        }

        //properties
        public string Version
        {
            get { return this.version; }
            private set { this.version = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public enum Type
        {
            Enum,
            Class,
            Struct,
            Method,
            Interface
        }
    }
}
