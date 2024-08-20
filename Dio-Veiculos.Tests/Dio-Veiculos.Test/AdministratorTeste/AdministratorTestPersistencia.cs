using Dio_Veiculos.API.Domain.Models;
using Dio_Veiculos.API.Infraestructure.Context;
using Dio_Veiculos.API.Infraestructure.Repositories;
using Dio_Veiculos.Test.Contexto;

namespace Dio_Veiculos.Test.AdministratorTeste
{
    public class AdministratorTestPersistencia
    {
        
        [Fact]
        public async void TestarSalvarAdministrador()
        {
            var context = new TestContext();
            //Arrange
            var adm = new Administrator("Usuario", "Usuario@gmail.com", "12345678", Perfil.User);
           
            //Assert
            await context.Administrators.AddAsync(adm);
            var ok = await context.SaveChangesAsync();

            Assert.Equal(1, ok);
            

        }
    }
}