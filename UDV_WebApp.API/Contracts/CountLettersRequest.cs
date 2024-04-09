namespace UDV_WebApp.API.Contracts
{
    public record CountLettersRequest(
        string AccessToken,
        long PageId,
        ulong PostsCount);
}
