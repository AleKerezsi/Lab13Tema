using Lab13Tema;
using Lab13Tema.Exceptii;
using NUnit.Framework;

namespace Lab13TemaTests
{
    [TestFixture]
    public class ContBancarTest
    {
        [Test]
        public void DepuneNumerar_AdaugaBaniInContCorect()
        {
            // Arrange
            ContBancar cont = new ContBancar();

            // Act
            cont.DepuneNumerar(100);

            // Assert
            Assert.AreEqual(100, cont.Sold);
        }

        [Test]
        public void ExtrageNumerar_AruncaNumerarIndisponibilException_CandNuExistaSoldSuficient()
        {
            // Arrange
            ContBancar cont = new ContBancar();

            // Act and Assert
            Assert.Throws<NumerarIndisponibilException>(() => cont.ExtrageNumerar(100));
        }

        [Test]
        public void ExtrageNumerar_ExtrageBaniDonCont_CandExistaSoldSuficient()
        {
            // Arrange
            ContBancar cont = new ContBancar();
            cont.DepuneNumerar(100);

            // Act
            cont.ExtrageNumerar(50);

            // Assert
            Assert.AreEqual(50, cont.Sold);
        }
    }
}
