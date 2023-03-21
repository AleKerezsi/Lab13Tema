using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13Tema
{
    public class Card
    {
        private readonly Guid Id;
        public Card(Guid id)
        {
            Id = id;
        }

        public void IntroduCard() 
        {
            Console.WriteLine("Cardul este introdus");
        }

        public Guid GetCardData() 
        {
            return Id;
        }

        public void ExtrageCard()
        {
            Console.WriteLine("Cardul este extras");
        }
    }
}
