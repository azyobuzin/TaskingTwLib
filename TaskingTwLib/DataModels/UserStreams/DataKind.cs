namespace Azyobuzi.TaskingTwLib.DataModels.UserStreams
{
    /// <summary>
    /// UserStreamで流れてきたデータの種類
    /// </summary>
    public enum DataKind
    {
        /// <summary>
        /// 不明
        /// </summary>
        Unknown,

        /// <summary>
        /// フォローしているアカウントのID
        /// </summary>
        Friends,

        /// <summary>
        /// ツイート
        /// </summary>
        Status
    }
}
