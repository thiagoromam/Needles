using Needles.Attributes;

namespace Needles.Tests.Types
{
    public class Product
    {
        public readonly int Number;
        public readonly ProductData Data;
        public readonly int Number2;
        public readonly string Name;

        public Product([Manual]int number, ProductData data, [Manual]int number2, [Manual]string name)
        {
            Number = number;
            Data = data;
            Number2 = number2;
            Name = name;
        }
    }
}