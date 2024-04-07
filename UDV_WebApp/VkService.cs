using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;

public static class VkService
{
    private static VkApi _vkApi;

    public static void Initialize()
    {
        _vkApi = new VkApi();
        _vkApi.Authorize(new ApiAuthParams
        {
            AccessToken = "access-token"
        });
    }

    public static async Task<IEnumerable<string>> GetPostsAsync(long pageId)
    {
        var posts = await _vkApi.Wall.GetAsync(new WallGetParams
        {
            OwnerId = pageId,
            Count = 5
        });

        return posts.WallPosts.Select(post => post.Text);
    }

    public static async Task<Dictionary<char, int>> CountLettersAsync(long pageId)
    {
        var posts = await GetPostsAsync(pageId);

        var letters = new Dictionary<char, int>();
        foreach (var post in posts)
        {
            foreach (var letter in post.ToLower())
            {
                if (letters.ContainsKey(letter))
                    letters[letter]++;
                else
                    letters[letter] = 1;
            }
        }

        return letters.OrderBy(l => l.Key).ToDictionary();
    }
}