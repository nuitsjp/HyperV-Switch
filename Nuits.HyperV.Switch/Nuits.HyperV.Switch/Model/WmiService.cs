using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Nuits.HyperV.Switch.Model
{
    /// <summary>
    /// Boot Configuration Dataへの操作を提供するサービスインターフェース
    /// </summary>
    public class WmiService
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Lazy<WmiService> lazy = new Lazy<WmiService>(() => new WmiService(), true);
        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/aa362670(v=vs.85).aspx
        /// </summary>
        private const uint BcdOSLoaderInteger_HypervisorLaunchType = 0x250000F0;
        /// <summary>
        /// カレントブートローダー
        /// </summary>
        private BcdObject currentLoaderObject;
        /// <summary>
        /// 唯一のインスタンスを取得する。
        /// </summary>
        public static WmiService Instance { get { return lazy.Value; } }
        /// <summary>
        /// インスタンスを初期化する
        /// </summary>
        private WmiService()
        {
            //ユーザー特権を有効にするための設定を作成
            var connectionOptions = new ConnectionOptions();
            connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            connectionOptions.EnablePrivileges = true;

            var managementScope = new ManagementScope(@"root\WMI", connectionOptions);
            var managementPath = new ManagementPath("root\\WMI:BcdObject.Id=\"{fa926493-6f1c-4193-a414-58f0b2456d1e}\",StoreFilePath=\"\"");
            currentLoaderObject = new BcdObject(managementScope, managementPath);
        }
        /// <summary>
        /// HyperVisorLaunchTypeを取得する
        /// </summary>
        /// <returns></returns>
        public Task<HyperVisorLaunchType> GetHyperVisorLaunchType()
        {
            return Task.Run(() =>
            {
                try
                {
                    // カレントのブートローダーからHypervisorLaunchTypeを取得する
                    ManagementBaseObject element;
                    if (currentLoaderObject.GetElement(BcdOSLoaderInteger_HypervisorLaunchType, out element))
                    {
                        return (HyperVisorLaunchType)element.Properties["Integer"].Value;
                    }
                    else
                    {
                        return HyperVisorLaunchType.None;
                    }
                }
                catch
                {
                    // Hyper-Vがインストールされていない場合例外が発生する。
                    // Elementを検索してから処理すれば例外は発生しないが
                    // 通常処理が遅くなる（WMIの呼び出しが増える）為、この処理とする。
                    return HyperVisorLaunchType.None;
                }
            });
        }

        /// <summary>
        /// HyperVisorLaunchTypeを設定する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetHyperVisorLaunchType(HyperVisorLaunchType value)
        {
            return Task.Run(() =>
            {
                currentLoaderObject.SetIntegerElement((uint)value, BcdOSLoaderInteger_HypervisorLaunchType);
            });
        }

        /// <summary>
        /// システムをリブートする
        /// </summary>
        public void RebootSystem()
        {
            //ユーザー特権を有効にするための設定を作成
            var connectionOptions = new ConnectionOptions();
            connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            connectionOptions.EnablePrivileges = true;

            var managementScope = new ManagementScope("\\ROOT\\CIMV2", connectionOptions);
            managementScope.Connect();

            using (var searcher = new ManagementObjectSearcher(managementScope, new ObjectQuery("select * from Win32_OperatingSystem")))
            {
                //Shutdownメソッドを呼び出す
                foreach (ManagementObject mo in searcher.Get())
                {
                    System.IO.File.AppendAllText("log.txt", string.Format("bar"));
                    //パラメータを指定
                    var inParameters = mo.GetMethodParameters("Win32Shutdown");
                    inParameters["Flags"] = 2;
                    inParameters["Reserved"] = 0;
                    //Win32Shutdownメソッドを呼び出す
                    var outParameters = mo.InvokeMethod("Win32Shutdown", inParameters, null);
                }
            }
        }
    }
}
