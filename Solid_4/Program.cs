using System;

namespace Solid_4
{
    /*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/


// Порушено ISP (The Interface Segregation Principle)

    interface IItem
    {
        void SetPrice(double price);
    }

    interface IDiscountItem
    {
        void ApplyDiscount(String discount);
    }

    interface IPromocodeItem
    {
        void ApplyPromocode(String promocode);
    }

    interface IColorItem
    {
        void SetColor(byte color);
    }

    interface ISizeItem
    {
        void SetSize(byte size);
    }


    class Book : IItem, IDiscountItem, IPromocodeItem
    {
        public void SetPrice(double price) { }
        public void ApplyDiscount(String discount) { }
        public void ApplyPromocode(String promocode) { }
    }

    class OuterWear : IItem, IDiscountItem, IPromocodeItem, IColorItem, ISizeItem
    {
        public void SetPrice(double price) { }
        public void ApplyDiscount(String discount) { }
        public void ApplyPromocode(String promocode) { }
        public void SetColor(byte color) { }
        public void SetSize(byte size) { }
    }


    class Program
    {
        static void Main()
        {
            Console.ReadKey();
        }
    }
}