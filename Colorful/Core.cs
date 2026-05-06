using Colorful.BoneMenu;
using Colorful.Coloring;
using Colorful.UserData;
using MelonLoader;

[assembly: MelonInfo(typeof(Colorful.Core), Colorful.BuildInfo.Name, Colorful.BuildInfo.Version, Colorful.BuildInfo.Author)]
[assembly: MelonGame(Colorful.BuildInfo.GameDeveloper, Colorful.BuildInfo.GameName)]

namespace Colorful;

internal class Core : MelonMod
{
    internal static Core Instance { get; private set; }
    
    internal PreferencesManager PreferencesManager { get; private set; }
    internal ColoringManager ColoringManager { get; private set; }
    internal BoneMenuManager BoneMenuManager { get; private set; }
    
    public override void OnInitializeMelon()
    {
        Instance = this;
        
        PreferencesManager = new PreferencesManager();
        ColoringManager = new ColoringManager();
        BoneMenuManager = new BoneMenuManager();
    }
}