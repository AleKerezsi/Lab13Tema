using System;

namespace Lab13Tema
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Contul bancar
            Va avea un ID de tip Guid
            Va avea o metoda DepuneNumerar
            Va avea o metoda ExtrageNumerar
            • Va avea ca parametru suma ce se doreste a fi extrasa
            • In cazul in care suma nu este disponibila, contul bancar va arunca o exceptie
            • Va fi folosita la de Banca atunci cand vor fi efectuate plati
            Banca
            Va avea o lista de conturi curente indexate intr-un dictionar in functie de id-ul (Guid) acestora.
            Va avea o metoda „CreeazaCont” care
            • Va creea un nou cont bancar
            • Il va adauga in lista conturilor
            • Va returna id-ul contului
            Va avea o metoda „EmiteCard” care va primi ca parametru id-ul contului
            • In cazul in care contul nu exista va arunca o exceptie corespunzatoare
            • In cazul in care au fost emise deja 2 carduri pentru acel cont va arunca o exceptie.
            • Cardul emis va primi id-ul contului.
            Va avea o metoda „Plateste” care va primi 2 parametri: suma si id-ul contului.
            • In cazul in care contul nu exista va arunca o exceptie corespunzatoare
            Card-ul
            Va avea 3 metode:
             IntroduCard
             Va afisa pe ecran un mesaj
             GetCardData
             Returneaza id-ul contului
             ExtrageCard
             Va afisa pe ecran un mesaj
            POS-ul
            Va avea o metoda „Plateste” care:
            • va primi doi parametri: suma de plata si cardul
            • va chema pe rand metodele
            o introdu card
            o get card data
            o va incerca sa efectueze plata in banca
            o va extrage cardul
            • Se va asigura ca extragerea cardului a fost facuta si in situatia in care plata a esuat*/

            Banca banca = new Banca("Banca Transilvania");

            Guid idContBancar1 = banca.CreeazaCont();
            Guid idContBancar2 = banca.CreeazaCont();

            banca.DepuneNumerarInCont(idContBancar1, 1500);
            banca.DepuneNumerarInCont(idContBancar2, 3200);

            POS pos = new POS(banca);
            Guid idCard1 = banca.EmiteCard(idContBancar1);
            Guid idCard2 = banca.EmiteCard(idContBancar2);

            Card c1 = new Card(idCard1);
            Card c2 = new Card(idCard2);

            pos.Plateste(150, c1);
            pos.Plateste(50, c2);
            pos.Plateste(500, c1);

        }
    }
}
