using GalaSoft.MvvmLight.Messaging;
using Nuits.HyperV.Switch.Messaging;
using System;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Nuits.HyperV.Switch.View.Behavior
{
    public class NavigationPageBehavior : Behavior<Frame>
    {
        // 要素にアタッチされたときの処理。大体イベントハンドラの登録処理をここでやる
        protected override void OnAttached()
        {
            base.OnAttached();
            // メッセンジャーへ画面遷移イベント受信ハンドラを登録する
            Messenger.Default.Register<NavigationMessage>(this, NavigationPage);
        }

        // 要素にデタッチされたときの処理。大体イベントハンドラの登録解除をここでやる
        protected override void OnDetaching()
        {
            base.OnDetaching();
            Messenger.Default.Unregister<NavigationMessage>(this, NavigationPage);
        }

        /// <summary>
        /// 画面遷移を行う
        /// </summary>
        /// <param name="message"></param>
        private void NavigationPage(NavigationMessage message)
        {
            // 遷移先の画面インスタンスを生成する
            // message.Destinationと同名のPageクラスのインスタンスを生成する
            var nextPage = 
                Activator.CreateInstance(
                    Type.GetType($"{typeof(MainWindow).Namespace}.{message.Destination.ToString()}", false)) as Page;

            // 遷移先の画面が無い場合（バグ）、例外をスローする
            if(nextPage == null)
                throw new NotImplementedException($"NavigationDestination:{message.Destination}");

            // ViewModelが明示的に指定されていた場合、DataContextへバインドする
            if (message.ViewModel != null)
                nextPage.DataContext = message.ViewModel;

            AssociatedObject.Navigate(nextPage);
        }
    }
}
