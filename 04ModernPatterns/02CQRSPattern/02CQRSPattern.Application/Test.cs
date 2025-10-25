namespace _02CQRSPattern.Application;

internal class MyAuthorizeAttribute : Attribute
{
    private string _role;
    public MyAuthorizeAttribute(string role)
    {
        _role = role;
    }
}
