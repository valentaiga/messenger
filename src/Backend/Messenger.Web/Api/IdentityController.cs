using System.Security.Cryptography;
using Messenger.Identity.App.Grpc.Contracts;
using Messenger.Identity.App.Grpc.Contracts.Models;
using Messenger.Web.Api.Models;
using Messenger.Web.Api.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Web.Api;

public static class IdentityController
{
    public static IEndpointRouteBuilder AddIdentityEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup("identity");

        // todo: swagger docs for development
        group.MapPost("/login", Login).AllowAnonymous();
        group.MapPost("/register", RegisterUser).AllowAnonymous();
        group.MapPost("/refresh", Refresh).AllowAnonymous();
        group.MapPost("/reset-password", ResetPassword).AllowAnonymous();

        group.MapPut("/email", ChangeEmail);
        group.MapPost("/password", ChangePassword);
        group.MapPut("/profile", UpdateProfile);

        routeBuilder.MapGet("/", async (IIdentityApp identityApp) =>
        {
            var grpcResult = await identityApp.AuthenticateUser(
                new AuthenticateUserRequest()
                {
                    Email = string.Empty,
                    Password = string.Empty,
                });
            return Results.Ok(new LoginResponse
            {
                AccessToken = grpcResult.AccessToken,
                RefreshToken = grpcResult.RefreshToken,
                DueDate = grpcResult.DueDate,
            });
        }).AllowAnonymous();

        return routeBuilder;
    }

    private static async Task<IResult> Login(IIdentityApp identityApp, LoginRequest request)
    {
        // todo: use mapper? or its fine?
        // todo: efficiently handle errors through gRPC
        // todo: use Polly for grpc calls
        var grpcResult = await identityApp.AuthenticateUser(new AuthenticateUserRequest
        {
            Email = request.Email,
            Password = request.Password
        });
        return Results.Ok(new LoginResponse
        {
            AccessToken = grpcResult.AccessToken,
            RefreshToken = grpcResult.RefreshToken,
            DueDate = grpcResult.DueDate,
        });
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
