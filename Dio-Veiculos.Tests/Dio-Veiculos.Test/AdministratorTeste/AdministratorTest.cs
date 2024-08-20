using Dio_Veiculos.API.Domain.Models;

namespace Dio_Veiculos.Test.AdministratorTeste
{
    public class AdministratorTest
    {
        [Fact]
        public void TestarPropriedadesDoModel()
        {
            //Arrange
            var adm = new Administrator
            {
                //Act
                Id = 1,
                Name = "Administrador",
                Email = "Administrador@gmail.com",
                Passworld = "12345678",
                Perfil = Perfil.Admin
            };

            //Assert

            Assert.Equal(1, adm.Id);
            Assert.Equal("Administrador", adm.Name);
            Assert.Equal("Administrador@gmail.com", adm.Email);
            Assert.Equal("12345678", adm.Passworld);
            Assert.Equal(Perfil.Admin, adm.Perfil);
        }
    }
}