using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuits.HyperV.Switch.Model
{
    /// <summary>
    /// HyperVisorLaunchType
    /// </summary>
    public enum HyperVisorLaunchType : ulong
    {
        /// <summary>
        /// OFF
        /// </summary>
        Off = 0,
        /// <summary>
        /// AUTO
        /// </summary>
        Auto = 1,
        /// <summary>
        /// ブートローダーに該当の設定が存在しない
        /// </summary>
        None = 2
    }
}
