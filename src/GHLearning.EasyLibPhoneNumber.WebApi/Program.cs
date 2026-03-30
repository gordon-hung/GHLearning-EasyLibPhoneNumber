using Microsoft.AspNetCore.Mvc;

using PhoneNumbers;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("phone/Validate", ([FromQuery] string phone, [FromQuery] string defaultRegion = "TW") =>
{
    PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
    try
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(phone, nameof(phone));

        PhoneNumber numberProto = phoneUtil.Parse(phone, defaultRegion);

        return Results.Ok(new PhoneValidateResponse
        {
            E164 = phoneUtil.Format(numberProto, PhoneNumberFormat.E164),
            International = phoneUtil.Format(numberProto, PhoneNumberFormat.INTERNATIONAL),
            National = phoneUtil.Format(numberProto, PhoneNumberFormat.NATIONAL),
            RFC3966 = phoneUtil.Format(numberProto, PhoneNumberFormat.RFC3966)
        });
    }
    catch(ArgumentNullException ex)
    {
        return Results.BadRequest(new ErrorResponse
        {
            Message = ex.Message
        });
    }
    catch (NumberParseException ex)
    {
        return Results.BadRequest(new ErrorResponse
        {
            Message = ex.Message
        });
    }
})
.WithName("ValidatePhoneNumber")
.WithSummary("Validate phone number")
.WithDescription("Validate and format a phone number using Google's libphonenumber. Default region is TW.")
.Produces<PhoneValidateResponse>(StatusCodes.Status200OK)
.Produces<ErrorResponse>(StatusCodes.Status400BadRequest)
.WithTags("phone");

app.Run();

public class PhoneValidateResponse
{
    public string E164 { get; set; } = default!;
    public string International { get; set; } = default!;
    public string National { get; set; } = default!;
    public string RFC3966 { get; set; } = default!;
}

public class ErrorResponse
{
    public string Message { get; set; } = default!;
}
