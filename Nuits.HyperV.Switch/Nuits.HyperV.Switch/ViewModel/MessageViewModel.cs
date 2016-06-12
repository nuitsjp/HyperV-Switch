using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nuits.HyperV.Switch.ViewModel
{
    /// <summary>
    /// メッセージ画面用ViewModel
    /// </summary>
    public class MessageViewModel : ViewModelBase
    {
        /// <summary>
        /// メッセージ
        /// </summary>
        public ReactiveProperty<string> Message { get; } = new ReactiveProperty<string>();
        /// <summary>
        /// ボタンの表示文字列
        /// </summary>
        public ReactiveProperty<string> ButtonContent { get; } = new ReactiveProperty<string>();
        /// <summary>
        /// 実行コマンド
        /// </summary>
        public ICommand ExecCommand { get; private set; }
        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttonContent"></param>
        /// <param name="execAction"></param>
        public MessageViewModel(string message, string buttonContent, Action execAction)
        {
            this.Message.Value = message;
            this.ButtonContent.Value = buttonContent;
            this.ExecCommand = new RelayCommand(execAction);
        }
    }
}
