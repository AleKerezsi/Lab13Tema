using Lab13Tema.Exceptii;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13Tema
{
    public class ContBancar
    {
        public Guid Id { get; }

        public int Sold { get; set; }

        public ContBancar()
        {
            Id = Guid.NewGuid();
        }

        public void DepuneNumerar(int numerar)
        {
            Sold = Sold + numerar;
        }

        public void ExtrageNumerar(int numerar)
        {
            if (Sold < numerar) throw new NumerarIndisponibilException("Numerarul nu este disponibil in cont");
            Sold = Sold - numerar;
        }

    }
}
