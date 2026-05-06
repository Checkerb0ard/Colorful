using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;

namespace Colorful.UserData;

internal class PreferencesManager
{
    private MelonPreferences_Category Category { get; set; }

    internal MelonPreferences_Entry<Color> PreferencesUI { get; private set; }
    internal MelonPreferences_Entry<Color> InventoryUI { get; private set; }
    internal MelonPreferences_Entry<Color> AvatarUI { get; private set; }
    internal MelonPreferences_Entry<Color> LevelUI { get; private set; }
    internal MelonPreferences_Entry<Color> SpawnGunUI { get; private set; }
    internal MelonPreferences_Entry<Color> Cursor { get; private set; }

    internal MelonPreferences_Entry<Color> PopUpUI_N { get; private set; }
    internal MelonPreferences_Entry<Color> PopUpUI_NE { get; private set; }
    internal MelonPreferences_Entry<Color> PopUpUI_E { get; private set; }
    internal MelonPreferences_Entry<Color> PopUpUI_SE { get; private set; }
    internal MelonPreferences_Entry<Color> PopUpUI_S { get; private set; }
    internal MelonPreferences_Entry<Color> PopUpUI_SW { get; private set; }
    internal MelonPreferences_Entry<Color> PopUpUI_W { get; private set; }
    internal MelonPreferences_Entry<Color> PopUpUI_NW { get; private set; }

    internal PreferencesManager()
    {
        Category = MelonPreferences.CreateCategory(BuildInfo.Name);
        Category.SetFilePath($"{MelonEnvironment.UserDataDirectory}/{BuildInfo.Name}.cfg", true, false);

        PreferencesUI = Category.CreateEntry("PreferencesUI", Color.white, "Preferences UI Color");
        InventoryUI   = Category.CreateEntry("InventoryUI",   Color.white, "Inventory Slot Color");
        AvatarUI      = Category.CreateEntry("AvatarUI",      Color.white, "Avatar UI Color");
        LevelUI       = Category.CreateEntry("LevelUI",       Color.white, "Level UI Color");
        SpawnGunUI    = Category.CreateEntry("SpawnGunUI",    Color.white, "Spawn Gun UI Color");
        Cursor        = Category.CreateEntry("Cursor",        Color.white, "Cursor Color");

        PopUpUI_N  = Category.CreateEntry("PopUpUI_N",  Color.white, "PopUp UI Color (North)");
        PopUpUI_NE = Category.CreateEntry("PopUpUI_NE", Color.white, "PopUp UI Color (North East)");
        PopUpUI_E  = Category.CreateEntry("PopUpUI_E",  Color.white, "PopUp UI Color (East)");
        PopUpUI_SE = Category.CreateEntry("PopUpUI_SE", Color.white, "PopUp UI Color (South East)");
        PopUpUI_S  = Category.CreateEntry("PopUpUI_S",  Color.white, "PopUp UI Color (South)");
        PopUpUI_SW = Category.CreateEntry("PopUpUI_SW", Color.white, "PopUp UI Color (South West)");
        PopUpUI_W  = Category.CreateEntry("PopUpUI_W",  Color.white, "PopUp UI Color (West)");
        PopUpUI_NW = Category.CreateEntry("PopUpUI_NW", Color.white, "PopUp UI Color (North West)");

        Save();
    }

    internal void Save() => Category.SaveToFile(false);
}
