using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Nuits.HyperV.Switch.Messaging;
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
    /// 処理中画面のViewModel基底クラス
    /// </summary>
    public abstract class ProcessViewModel : ViewModelBase
    {
        /// <summary>
        /// 処理中メッセージ
        /// </summary>
        public ReactiveProperty<string> Message { get; } = new ReactiveProperty<string>();
        /// <summary>
        /// 処理実施コマンド
        /// </summary>
        public ICommand ProcessCommand { get; private set; }
        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        /// <param name="message"></param>
        public ProcessViewModel(string message)
        {
            this.Message.Value = message;
            ProcessCommand = new RelayCommand(async () => MessengerInstance.Send(await Process()));
        }

        /// <summary>
        /// 何らかの処理を実装する
        /// </summary>
        protected abstract Task<NavigationMessage> Process();
    }
}
