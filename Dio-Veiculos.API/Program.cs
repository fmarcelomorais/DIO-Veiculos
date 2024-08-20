using Dio_Veiculos.API.Application.DTOs;
using Dio_Veiculos.API.Application.Interfaces;
using Dio_Veiculos.API.Domain.Models;
using Dio_Veiculos.API.IoC;
using Dio_Veiculos.API.Token;
using Dio_Veiculos.API.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationJwt(builder.Configuration);    

builder.Services.AddDependencyInjection();

var app = builder.Build();




#region Login
app.MapPost("/login", async (Login login, IAdministratorService service, TokenService tokenService) =>
{
    var administrator = await service.Search(login);
    
    if(administrator is { Email : null, Passworld: null }) 
        return Results.Unauthorized();
    return Results.Ok(tokenService.Generate(administrator));

}).AllowAnonymous();
#endregion

#region Administrator
app.MapGet("/administrators/{id}", async ([FromRoute] int id, IAdministratorService service) =>
{
    var administrator = await service.GetAdministratorById(id);
    if (administrator == null) return Results.BadRequest();
    return Results.Json(administrator);
})
    .RequireAuthorization()
    .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

app.MapGet("/administrators", async (IAdministratorService service) =>
{
    var administratos = await service.GetAdministrators();
    return Results.Ok(administratos);

})
    .RequireAuthorization()
    .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

app.MapPost("/administrators", async (AdministratorDto login, IAdministratorService service) =>
{

    var create = await service.CreateAdministrator(new AdministratorDto
    {
        Name = login.Name,
        Email = login.Email,
        Passworld = login.Passworld,
        Perfil = login.Perfil
    });

    if (create) return Results.Json(create);
    return Results.BadRequest();
})
    .RequireAuthorization()
    .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });
#endregion

#region Veiculo
app.MapGet("/vehicles", async (IVeiculoService service) =>
{
    return Results.Ok(await service.GetAll());
}).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,User" }); 

app.MapGet("/vehicles/{id}", async ([FromRoute]int id, IVeiculoService service) =>
{
     return Results.Json(await service.GetById(id));
}).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,User" }); 

app.MapPost("/vehicles", async (VeiculoDto veiculoDto, IVeiculoService service) =>
{
    Validation validator = new Validation();
    var veiculo = await service.SearchForPlaca(veiculoDto.Placa);
    if (string.IsNullOrEmpty(veiculoDto.Placa)) 
        validator.ListErrors.Add(new Errors { ErrorMensage = "A placa é obrigatória para cadastrar o veículo" });
    if (veiculo.Placa is not null) 
        validator.ListErrors.Add(new Errors { ErrorMensage = "Existe um veiculo cadastrado com a placa informada." });
    
    if(validator.ListErrors.Count > 0) 
        return Results.Json(validator.ListErrors);

    var result = await service.Create(veiculoDto);
    if (result) return Results.Created(string.Empty, result);
    return Results.BadRequest(new Errors { ErrorMensage = "Erro ao salvar Veiculo." });
})
    .RequireAuthorization()
    .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

app.MapPut("/vehicles/{id}", async ([FromRoute]int id, VeiculoDto veiculoDto, IVeiculoService service) =>
{
    if(id != veiculoDto.Id) return Results.BadRequest();
    var result = await service.Update(id, veiculoDto);
    if (result) return Results.Created(string.Empty, result);
    return Results.BadRequest();
})
    .RequireAuthorization()
    .RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });
#endregion

app.MapGet("/", () => "Hello World");

app.UseAuthentication();
app.UseAuthorization();



app.Run();
