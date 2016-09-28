namespace Nuits.HyperV.Switch.Messaging
{
    /// <summary>
    /// 画面の遷移先を表す
    /// </summary>
    public enum NavigationDestination
    {
        /// <summary>
        /// メッセージ画面
        /// </summary>
        MessagePage,
        /// <summary>
        /// 処理中画面
        /// </summary>
        ProcessPage,
        /// <summary>
        /// 設定変更画面
        /// </summary>
        SwitchPage,
        /// <summary>
        /// 完了画面
        /// </summary>
        CompletePage
    }
}
