namespace ReflectionExample
{
    [Permissions(RoleName = "Admin")]
    class Phone
    {
        private decimal _price;

        public decimal Price => _price;
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public Currency Currency { get; private set; }

        public Phone(decimal price)
        {
            _price = price;
            Currency = Currency.USD;
        }

        [Permissions("User")]
        public override string ToString()
        {
            return $"{Manufacturer} {Model}";
        }

        private decimal ConvertCurrency(Currency currency)
        {
            switch (currency)
            {
                case Currency.UAH:
                    return _price * 28.83m;
                case Currency.BTC:
                    return _price * 12000m;
                default:
                    return _price;
            }
        }
    }
}
