using System;

namespace FireMapper.Attributes
{
    public class FireCollectionAttribute : Attribute 
    {
        private readonly string collection;

        public FireCollectionAttribute(string collection)
        {
            this.collection = collection;
        }

        public string Collection{ get => collection; }
    }
}