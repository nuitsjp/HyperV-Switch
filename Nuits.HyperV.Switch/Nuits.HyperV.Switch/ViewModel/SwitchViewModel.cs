using GalaSoft.MvvmLight;
using Nuits.HyperV.Switch.Model;
using Reactive.Bindings;
using System;
using System.Reactive.Linq;
using System.Windows;
using Nuits.HyperV.Switch.Messaging;

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
        private readonly HyperVisorLaunchType _defaultLaunchType;

        /// <summary>
        /// 現在画面にて設定されているHyperVisorLaunchType
        /// </summary>
        public ReactiveProperty<HyperVisorLaunchType> LaunchType { get; }

        /// <summary>
        /// HyperVisorLaunchTypeの更新コマンド
        /// </summary>
        public ReactiveCommand UpdateCommand { get; }

        /// <summary>
        /// Cancelコマンド
        /// </summary>
        public ReactiveCommand CancelCommand { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        public SwitchViewModel(HyperVisorLaunchType defaultLaunchType)
        {
            _defaultLaunchType = defaultLaunchType;
            // 選択中のHyperVisorLaunchTypeの状態を表すプロパティ
            LaunchType = new ReactiveProperty<HyperVisorLaunchType>(defaultLaunchType);

            // HyperVisorLaunchTypeを更新するコマンド
            // HyperVisorLaunchTypeを現在値が変更された場合に実行可能とする
            UpdateCommand = LaunchType.Select(s => s != _defaultLaunchType).ToReactiveCommand();
            UpdateCommand.Subscribe(_ =>
            {
                MessengerInstance.Send(new NavigationMessage(NavigationDestination.ProcessPage, new UpdateViewModel(LaunchType.Value)));
            });

            CancelCommand = new ReactiveCommand();
            CancelCommand.Subscribe(_ => Application.Current.MainWindow?.Close());
        }
        #endregion
    }
}
