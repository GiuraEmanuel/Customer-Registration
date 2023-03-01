﻿namespace Custom_Registration.CodeFirst
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Number} {Street}\n{City}, {Country}\n{PostCode}";
        }
    }
}
