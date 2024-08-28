using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Sexiled
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        public bool Debug { get; set; }

        [Description("Whether or not the sexiled text will be printed after startup")]
        public bool ShowRandomly { get; set; } = true;
        
        [Description("The minimum seconds needed for sexiled text to appear")]
        public float MinSeconds { get; set; } = 160;

        [Description("The maximum seconds needed for sexiled text to appear")]
        public float MaxSeconds { get; set; } = 240;

        [Description("The chance needed for sexiled text to appear")]
        public int Chance { get; set; } = 75;
    }
}