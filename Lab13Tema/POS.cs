using Lab13Tema.Exceptii;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13Tema
{
    public class POS
    {
        private readonly Banca banca;
        public POS(Banca banca)
        {
            this.banca = banca;
        }

        public void Plateste(int suma, Card card)
        {
            card.IntroduCard();
            Guid idCont = card.GetCardData();
            banca.Plateste(idCont, suma);
          
            card.ExtrageCard();
        }
    }
}
