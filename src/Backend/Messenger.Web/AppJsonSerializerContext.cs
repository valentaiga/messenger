using System.Text.Json.Serialization;
using Messenger.Web.Api.Models;
using Messenger.Web.Api.Models.Identity;

namespace Messenger.Web;

[JsonSerializable(typeof(ChangeEmailRequest))]
[JsonSerializable(typeof(ChangePasswordRequest))]
[JsonSerializable(typeof(LoginRequest))]
[JsonSerializable(typeof(LoginResponse))]
[JsonSerializable(typeof(RegisterUserRequest))]
[JsonSerializable(typeof(RegisterUserResponse))]
[JsonSerializable(typeof(ResetPasswordRequest))]
[JsonSerializable(typeof(UpdateProfileRequest))]
[JsonSerializable(typeof(ApiError))]
[JsonSerializable(typeof(SuccessResponse))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
