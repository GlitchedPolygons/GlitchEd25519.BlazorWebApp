using System.Text.Json;
using GlitchedPolygons.ExtensionMethods;
using GlitchedPolygons.GlitchEd25519.BlazorWebApp.Models;
using Microsoft.JSInterop;

namespace GlitchedPolygons.GlitchEd25519.BlazorWebApp.Services;

public class UserDataService(IJSRuntime js) : IUserDataService
{
    public ValueTask<string> GetUserDataPlaintext()
    {
        return js.InvokeAsync<string>(Constants.InteropFunctionNames.GET_LOCALSTORAGE_VALUE, Constants.LocalStorageIds.USER_DATA);
    }

    public ValueTask SetUserDataPlaintext(string userDataPlaintext)
    {
        if (userDataPlaintext.NullOrEmpty())
        {
            userDataPlaintext = "{}";
        }
        
        return js.InvokeVoidAsync(Constants.InteropFunctionNames.SET_LOCALSTORAGE_VALUE, Constants.LocalStorageIds.USER_DATA, userDataPlaintext);
    }

    public async ValueTask<UserData> GetUserData()
    {
        string plaintext = await GetUserDataPlaintext();

        if (plaintext.NullOrEmpty())
        {
            return UserData.Empty;
        }

        try
        {
            return JsonSerializer.Deserialize<UserData>(plaintext) ?? UserData.Empty;
        }
        catch
        {
            return UserData.Empty; 
        }
    }

    public ValueTask SetUserData(UserData userData)
    {
        return SetUserDataPlaintext(JsonSerializer.Serialize(userData));
    }
}