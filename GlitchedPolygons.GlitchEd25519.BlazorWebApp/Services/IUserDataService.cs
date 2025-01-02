using GlitchedPolygons.GlitchEd25519.BlazorWebApp.Models;

namespace GlitchedPolygons.GlitchEd25519.BlazorWebApp.Services;

public interface IUserDataService
{
    ValueTask<string> GetUserDataPlaintext();
    ValueTask SetUserDataPlaintext(string userDataPlaintext);

    ValueTask<UserData> GetUserData();
    ValueTask SetUserData(UserData userData);
}