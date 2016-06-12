using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuits.HyperV.Switch.Messaging;
using Reactive.Bindings;
using Nuits.HyperV.Switch.Model;

namespace Nuits.HyperV.Switch.ViewModel
{
    /// <summary>
    /// アプリケーション初期化ViewModel
    /// </summary>
    public class InitializeViewModel : ProcessViewModel
    {
        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        public InitializeViewModel() :base(Properties.Resources.InitializeMessage)
        {
        }

        /// <summary>
        /// Hyper-Vの設定値を取得する
        /// </summary>
        /// <returns></returns>
        protected override async Task<NavigationMessage> Process()
        {
            var launchType = await WmiService.Instance.GetHyperVisorLaunchType();
            if (launchType == HyperVisorLaunchType.None)
            {
                // Hyper-Vが未設定の場合、メッセージ画面を表示して終了する。
                return new NavigationMessage(
                    NavigationDestination.MessagePage, 
                    new MessageViewModel(
                        Properties.Resources.NotExistHyperVSettingMessage,
                        "close",
                        () => App.Current.Shutdown()));
            }
            else
            {
                return new NavigationMessage(NavigationDestination.SwitchPage, new SwitchViewModel(launchType));
            }
        }
    }
}
