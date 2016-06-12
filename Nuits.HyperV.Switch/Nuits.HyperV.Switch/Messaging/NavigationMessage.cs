using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuits.HyperV.Switch.Messaging
{
    /// <summary>
    /// 画面遷移メッセージ
    /// </summary>
    public class NavigationMessage : MessageBase
    {
        /// <summary>
        /// 遷移先
        /// </summary>
        public NavigationDestination Destination { get; private set; }
        /// <summary>
        /// ViewModel
        /// </summary>
        public object ViewModel { get; private set; }
        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="viewModel"></param>
        public NavigationMessage(NavigationDestination destination, object viewModel) : base()
        {
            this.Destination = destination;
            this.ViewModel = viewModel;
        }
    }
}
