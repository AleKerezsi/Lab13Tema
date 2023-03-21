using Lab13Tema;
using Lab13Tema.Exceptii;
using NUnit.Framework;
using System;


namespace Lab13TemaTests
{
    [TestFixture]
    public class BancaTest
    {

        [Test]
        public void CreeazaCont_CreazaContNouCorect()
        {
            //Arrange
            Banca banca = new Banca("BancaTest");

            // Act
            Guid contId = banca.CreeazaCont();

            // Assert
            Assert.IsTrue(banca.ConturiCurente.ContainsKey(contId));
        }

        [Test]
        public void EmiteCard_AruncaContInexistentException_CandNuExistaContul()
        {
            //Arrange
            Banca banca = new Banca("BancaTest");

            // Arrange
            Guid contId = Guid.NewGuid();

            // Act and Assert
            Assert.Throws<ContInexistentException>(() => banca.EmiteCard(contId));
        }

        [Test]
        public void EmiteCard_AruncaLimitaCarduriEmiseException_CandExistaDejaDouaCarduriGeneratePentruUnCont()
        {
            //Arrange
            Banca banca = new Banca("BancaTest");

            // Arrange
            Guid contId = banca.CreeazaCont();
            banca.EmiteCard(contId);
            banca.EmiteCard(contId);

            // Act and Assert
            Assert.Throws<LimitaCarduriEmiseException>(() => banca.EmiteCard(contId));
        }

        [Test]
        public void EmiteCard_CreeazaCorectUnCardNou_CandNuExistaNiciunCardEmisDeja()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            Guid contId = banca.CreeazaCont();

            // Act
            Guid cardId = banca.EmiteCard(contId);

            // Assert
            Assert.IsTrue(banca.CarduriEmise.ContainsKey(contId));
            Assert.AreEqual(1, banca.CarduriEmise[contId]);
            Assert.AreEqual(contId, cardId);
        }

        [Test]
        public void EmiteCard_CresteNumaruLDeCarduriEmise_CandExistaDejaUnCardEmis()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            Guid contId = banca.CreeazaCont();
            banca.EmiteCard(contId);

            // Act
            Guid cardId = banca.EmiteCard(contId);

            // Assert
            Assert.IsTrue(banca.CarduriEmise.ContainsKey(contId));
            Assert.AreEqual(2, banca.CarduriEmise[contId]);
            Assert.AreEqual(contId, cardId);
        }

        [Test]
        public void DepuneNumerarInCont_AruncaContInexistentException_CandNuExistaContul()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            Guid contId = Guid.NewGuid();

            // Act and Assert
            Assert.Throws<ContInexistentException>(() => banca.DepuneNumerarInCont(contId, 100));
        }

        [Test]
        public void DepuneNumerarInCont_AdaugaCorectBaniInContulSelectat()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            Guid contId = banca.CreeazaCont();

            // Act
            banca.DepuneNumerarInCont(contId, 100);

            // Assert
            Assert.AreEqual(100, banca.ConturiCurente[contId].Sold);
        }

        [Test]
        public void Plateste_AruncaContInexistentException_CandNuExistaContul()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            Guid contId = Guid.NewGuid();

            // Act and Assert
            Assert.Throws<ContInexistentException>(() => banca.Plateste(contId, 100));
        }

        [Test]
        public void Plateste_ExtrageBaniCorectDinContulAles()
        {
            // Arrange
            Banca banca = new Banca("BancaTest");
            Guid contId = banca.CreeazaCont();
            banca.DepuneNumerarInCont(contId, 100);

            // Act
            banca.Plateste(contId, 50);

            // Assert
            Assert.AreEqual(50, banca.ConturiCurente[contId].Sold);
            
        }
    }
}
