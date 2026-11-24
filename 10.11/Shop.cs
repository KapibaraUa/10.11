using System;

namespace GarbageCollectionHw
{
    public class Shop : IDisposable
    {
        private string _name = String.Empty;
        private string _address = String.Empty;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _name = value;
                else
                    throw new ArgumentException("Shop name cannot be empty");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _address = value;
                else
                    throw new ArgumentException("Shop address cannot be empty");
            }
        }

        public ShopType Type { get; set; }

        public Shop()
        {
            _name = "Default Shop";
            _address = "Unknown";
            Type = ShopType.Grocery;
        }

        public Shop(string name, string address, ShopType type)
        {
            Name = name;
            Address = address;
            Type = type;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Shop: {Name}, Address: {Address}, Type: {Type}");
        }

        public override string ToString()
        {
            return $"Shop: {Name} ({Type}), Address: {Address}";
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose called for shop: {Name}");
        }

        ~Shop()
        {
            Console.WriteLine($"Finalizer called for shop: {Name}");
        }
    }
}