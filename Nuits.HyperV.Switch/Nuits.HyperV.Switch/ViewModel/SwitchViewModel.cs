using GalaSoft.MvvmLight;
using Nuits.HyperV.Switch.Model;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Nuits.HyperV.Switch.Messaging;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Nuits.HyperV.Switch.ViewModel
{
    /// <summary>
    /// 設定変更ViewModel
    /// </summary>
    public class SwitchViewModel : ViewModelBase
    {
        #region Field & Property
        /// <summary>
        /// 変更前のHyperVisorLaunchType
        /// </summary>
        private HyperVisorLaunchType defaultLaunchType;

        /// <summary>
        /// 現在画面にて設定されているHyperVisorLaunchType
        /// </summary>
        public ReactiveProperty<HyperVisorLaunchType> LaunchType { get; private set; }

        /// <summary>
        /// HyperVisorLaunchTypeの更新コマンド
        /// </summary>
        public ReactiveCommand UpdateCommand { get; private set; }

        #endregion

        #region Constructor
        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        /// <param name="wmiService"></param>
        public SwitchViewModel(HyperVisorLaunchType defaultLaunchType)
        {
            this.defaultLaunchType = defaultLaunchType;
            // 選択中のHyperVisorLaunchTypeの状態を表すプロパティ
            LaunchType = new ReactiveProperty<HyperVisorLaunchType>(defaultLaunchType);

            // HyperVisorLaunchTypeを更新するコマンド
            // HyperVisorLaunchTypeを現在値が変更された場合に実行可能とする
            UpdateCommand = LaunchType.Select(s => s != this.defaultLaunchType).ToReactiveCommand();
            UpdateCommand.Subscribe(_ =>
            {
                MessengerInstance.Send(new NavigationMessage(NavigationDestination.ProcessPage, new UpdateViewModel(LaunchType.Value)));
            });
        }
        #endregion
    }
}
