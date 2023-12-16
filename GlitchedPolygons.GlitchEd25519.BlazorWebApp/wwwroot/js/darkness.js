
function UserHasDarkMode() 
{
    if (window.matchMedia('(prefers-color-scheme: dark)').matches) 
    {
        return true;
    }

    return false;
}