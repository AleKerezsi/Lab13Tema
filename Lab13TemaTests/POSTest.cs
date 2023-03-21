using Lab13Tema;
using Lab13Tema.Exceptii;
using NUnit.Framework;


namespace Lab13TemaTests
{
    [TestFixture]
    public class POSTest
    {

        [Test]
        public void Plateste_AruncaNumerarIndisponibilException_CandNuExistaSoldSuficient()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            POS pos = new POS(banca);
            var idCont = banca.CreeazaCont();
            var idCard1 = banca.EmiteCard(idCont);
            Card card = new Card(idCard1);
            banca.DepuneNumerarInCont(idCont,500);

            // Act and Assert
            Assert.Throws<NumerarIndisponibilException>(() => pos.Plateste(700,card));
        }

        [Test]
        public void Plateste_ExtrageBaniDonCont_CandExistaSoldSuficient()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            POS pos = new POS(banca);
            var idCont = banca.CreeazaCont();
            var idCard1 = banca.EmiteCard(idCont);
            Card card = new Card(idCard1);
            banca.DepuneNumerarInCont(idCont, 1500);

            // Act
            pos.Plateste(700, card);

            // Assert
            Assert.AreEqual(banca.ConturiCurente[idCont].Sold, 800);
        }

    }
}
