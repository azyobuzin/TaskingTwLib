using System.IO;
using System.Threading.Tasks;
using Azyobuzi.TaskingTwLib.OAuth;

namespace Azyobuzi.TaskingTwLib
{
    /// <summary>
    /// TwitterAPIを呼び出します。
    /// </summary>
    public static class TwitterApiExecutor
    {
        /// <summary>
        /// TwitterAPIを呼び出します。
        /// </summary>
        /// <typeparam name="T">APIからの戻り値の型</typeparam>
        /// <param name="apiMethod">呼び出すAPI</param>
        /// <param name="token">OAuthトークン</param>
        /// <returns>実行中のタスク</returns>
        public static Task<T> CallApi<T>(this ITwitterApi<T> apiMethod, Token token)
        {
            return Task.Factory.StartNew(() =>
            {
                var req = RequestGenerator.GenerateTwitterApiRequest(
                    apiMethod.RequestUri,
                    apiMethod.MethodType,
                    token,
                    DefaultSetting.Proxy,
                    DefaultSetting.Timeout,
                    DefaultSetting.UserAgent,
                    apiMethod.ContentType,
                    apiMethod.Parameters,
                    apiMethod.Verifier,
                    apiMethod.Callback);

                using (var res = req.GetResponse())
                {
                    //TODO:RateLimit読み取り

                    using (var sr = new StreamReader(res.GetResponseStream()))
                    {
                        return apiMethod.Parse(sr.ReadToEnd(), token);
                    }
                }
            });
        }
    }
}
