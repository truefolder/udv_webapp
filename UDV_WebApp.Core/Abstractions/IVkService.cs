using VkNet;

namespace UDV_WebApp.Core.Abstractions
{
    public interface IVkService
    {
        VkApi GetVkApi(string accessToken);

        Task<IEnumerable<string>> GetPostsAsync(string accessToken, long pageId, ulong postsCount);
    }
}
