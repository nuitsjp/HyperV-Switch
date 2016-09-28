using Nuits.HyperV.Switch.Messaging;
using Nuits.HyperV.Switch.Model;
using System.Threading.Tasks;

namespace Nuits.HyperV.Switch.ViewModel
{
    /// <summary>
    /// Hyper-Vの設定変更ViewModel
    /// </summary>
    public class UpdateViewModel : ProcessViewModel
    {
        /// <summary>
        /// 変更先ののHyperVisorLaunchType
        /// </summary>
        private readonly HyperVisorLaunchType _launchType;
        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        /// <param name="launchType"></param>
        public UpdateViewModel(HyperVisorLaunchType launchType) : base(Properties.Resources.UpdatingMessage)
        {
            _launchType = launchType;
        }
        /// <summary>
        /// Hyper-Vの設定を変更する
        /// </summary>
        /// <returns></returns>
        protected override async Task<NavigationMessage> Process()
        {
            await WmiService.Instance.SetHyperVisorLaunchType(_launchType);
            return new NavigationMessage(NavigationDestination.CompletePage, new CompleteViewModel());
        }
    }
}
