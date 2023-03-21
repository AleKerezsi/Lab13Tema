using Lab13Tema.Exceptii;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13Tema
{
    public class Banca
    {
        public string Nume { get; set; }
        public Dictionary<Guid, ContBancar> ConturiCurente { get; set;} = new Dictionary<Guid, ContBancar>();
        public Dictionary<Guid, int> CarduriEmise { get; set; } = new Dictionary<Guid, int>();

        public Banca(string nume)
        {
            Nume = nume;
        }

        public Guid CreeazaCont()
        {
            ContBancar cont = new ContBancar();
            ConturiCurente[cont.Id] = cont;
            return cont.Id;
        }

        public Guid EmiteCard(Guid idCont)
        {
            if (!ConturiCurente.ContainsKey(idCont)) throw new ContInexistentException("Contul nu exista");

            if (CarduriEmise.ContainsKey(idCont) && CarduriEmise[idCont] >= 2) throw new LimitaCarduriEmiseException($"Au fost emise deja 2 carduri pentru contul cu id-ul {idCont}");

            if (!CarduriEmise.ContainsKey(idCont))
            {
                CarduriEmise.Add(idCont, 1);
            }
            else
            {
                CarduriEmise[idCont]++;
            }

            return idCont;
            
        }

        public void DepuneNumerarInCont(Guid idCont, int numerar)
        {
            if (!ConturiCurente.ContainsKey(idCont)) throw new ContInexistentException("Contul nu exista");
            ConturiCurente[idCont].DepuneNumerar(numerar);
        }

        public void Plateste(Guid idCont, int numerar)
        {
            if (!ConturiCurente.ContainsKey(idCont)) throw new ContInexistentException("Contul nu exista");
            Console.WriteLine($"Se plateste suma de {numerar} din contul cu id {idCont.ToString()}");
            ConturiCurente[idCont].ExtrageNumerar(numerar);
        }

    }
 
}
