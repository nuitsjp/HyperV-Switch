﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nuits.HyperV.Switch.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    var temp = new global::System.Resources.ResourceManager("Nuits.HyperV.Switch.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   設定を変更しました。
        ///変更を有効にするためにはWindowsを再起動する必要があります。
        ///今すぐ再起動しますか？ に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string CompletedMessage {
            get {
                return ResourceManager.GetString("CompletedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Hyper-Vの状態を取得中です。
        ///しばらくお待ちください。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string InitializeMessage {
            get {
                return ResourceManager.GetString("InitializeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Hyper-Vの設定が取得できませんでした。
        ///アプリケーションを終了します。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NotExistHyperVSettingMessage {
            get {
                return ResourceManager.GetString("NotExistHyperVSettingMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   予期せぬエラーが発生しました。システムを終了します。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string UnexpectedErrorMessage {
            get {
                return ResourceManager.GetString("UnexpectedErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   設定を更新中です。
        ///しばらくお待ちください。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string UpdatingMessage {
            get {
                return ResourceManager.GetString("UpdatingMessage", resourceCulture);
            }
        }
    }
}
