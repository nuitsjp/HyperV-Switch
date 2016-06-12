using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Nuits.HyperV.Switch.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nuits.HyperV.Switch.ViewModel
{
    /// <summary>
    /// メイン画面ViewModel
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// アプリケーション初期化コマンド
        /// </summary>
        public ICommand InitializeCommand { get; private set; }

        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        public MainViewModel()
        {
            // 初期化ページへ画面遷移する
            InitializeCommand = new RelayCommand(() =>
            {
                MessengerInstance.Send(new NavigationMessage(NavigationDestination.ProcessPage, new InitializeViewModel()));
            });
        }
    }
}
