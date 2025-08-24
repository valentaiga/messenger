using System.Security.Cryptography;
using Messenger.Web.Api.Models;
using Messenger.Web.Api.Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Messenger.Web.Api;

public static class IdentityController
{
    public static IEndpointRouteBuilder AddIdentityEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("identity");

        group.MapPost("/login", Login).AllowAnonymous();
        group.MapPost("/register", RegisterUser).AllowAnonymous();
        group.MapPost("/refresh", Refresh).AllowAnonymous();
        group.MapPost("/reset-password", ResetPassword).AllowAnonymous();

        group.MapPut("/email", ChangeEmail);
        group.MapPost("/password", ChangePassword);
        group.MapPut("/profile", UpdateProfile);

        return endpoints;
    }

    private static async Task<IResult> Login(LoginRequest request)
    {
        var result = new LoginResponse
        {
            AccessToken = RandomNumberGenerator.GetHexString(32),
            RefreshToken = RandomNumberGenerator.GetHexString(32),
            DueDate = DateTime.Now + TimeSpan.FromDays(7),
        };
        return Results.Ok(result);
    }

    private static async Task<IResult> RegisterUser(RegisterUserRequest request)
    {
        var result = new RegisterUserResponse
        {

        };
        return Results.Ok(result);
    }

    private static async Task<IResult> Refresh(LoginRequest request)
    {
        var result = new LoginResponse
        {
            AccessToken = RandomNumberGenerator.GetHexString(32),
            RefreshToken = RandomNumberGenerator.GetHexString(32),
            DueDate = DateTime.Now + TimeSpan.FromDays(7),
        };
        return Results.Ok(result);
    }

    private static async Task<IResult> ResetPassword(ResetPasswordRequest request)
    {
        var result = new SuccessResponse(true);
        return Results.Ok(result);
    }

    private static async Task<IResult> ChangeEmail(ChangeEmailRequest request)
    {
        var result = new SuccessResponse(true);
        return Results.Ok(result);
    }

    private static async Task<IResult> ChangePassword(ChangePasswordRequest request)
    {
        var result = new SuccessResponse(true);
        return Results.Ok(result);
    }

    private static async Task<IResult> UpdateProfile(UpdateProfileRequest request)
    {
        var result = new SuccessResponse(true);
        return Results.Ok(result);
    }
}
