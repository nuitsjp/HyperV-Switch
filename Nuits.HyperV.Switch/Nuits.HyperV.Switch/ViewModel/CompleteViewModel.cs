using GalaSoft.MvvmLight.Command;
using Nuits.HyperV.Switch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nuits.HyperV.Switch.ViewModel
{
    public class CompleteViewModel
    {
        /// <summary>
        /// 完了メッセージ
        /// </summary>
        public string CompletedMessage { get; } = Properties.Resources.CompletedMessage;
        /// <summary>
        /// アプリケーションを終了し、Windowsを再起動するコマンド
        /// </summary>
        public ICommand CloseAndRestartCommand { get; private set; }
        /// <summary>
        /// アプリケーション終了コマンド
        /// </summary>
        public ICommand CloseCommand { get; private set; }
        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        public CompleteViewModel()
        {
            CloseAndRestartCommand = new RelayCommand(() => CloseAndRestart());
            CloseCommand = new RelayCommand(() => App.Current.Shutdown());
        }

        /// <summary>
        /// アプリケーションを終了し、Windowsを再起動する
        /// </summary>
        private void CloseAndRestart()
        {
            WmiService.Instance.RebootSystem();
            App.Current.Shutdown();
        }
    }
}
