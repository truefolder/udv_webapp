using System.Collections.Generic;
using System.Threading.Tasks;
using UDV_WebApp.Core.Abstractions;
using VkNet;
using VkNet.Model;

namespace UDV_WebApp.Application.Services
{
    public class VkService : IVkService
    {
        public VkService()
        {
        }

        /// <summary>
        /// Получает объект VkApi, авторизованный с помощью <paramref name="accessToken"/>
        /// </summary>
        /// <param name="accessToken">VK access token</param>
        /// <returns></returns>
        public VkApi GetVkApi(string accessToken)
        {
            var vkApi = new VkApi();

            vkApi.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });

            return vkApi;
        }

        /// <summary>
        /// Получает 5 последних постов со страницы <paramref name="pageId"/>
        /// </summary>
        /// <param name="accessToken">VK access token</param>
        /// <param name="pageId">ID страницы</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetPostsAsync(string accessToken, long pageId)
        {
            var posts = await GetVkApi(accessToken).Wall.GetAsync(new WallGetParams
            {
                OwnerId = pageId,
                Count = 5
            });

            return posts.WallPosts.Select(post => post.Text);
        }
    }
}