using FluentValidation.AspNetCore;
using Shops.Application;
using Shops.Application.Exceptions;
using Shops.Application.Features.Commands.CurrentAccounts.CreateCurrAcc;
using Shops.Application.Features.Commands.Invoices.CreateInvoice;
using Shops.Infrastructure.Filters;
using Shops.Persistence;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>())
        .AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<CreateCurrentAccountValidator>(lifetime: ServiceLifetime.Singleton);    
            fv.RegisterValidatorsFromAssemblyContaining<CreateInvoiceValidator>(lifetime: ServiceLifetime.Singleton);    
        })
        .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);

    builder.Services.AddPersistence().AddAplication();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}