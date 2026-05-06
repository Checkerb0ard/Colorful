using System.Collections;
using MelonLoader;

namespace Colorful.Coloring;

internal enum Element
{
    PreferencesUI,
    InventoryUI,
    AvatarUI,
    LevelUI,
    SpawnGunUI,
    Cursor,
    PopUpUI,
}

internal class ColoringManager
{
    internal ColoringManager()
    {
        BoneLib.Hooking.OnLevelLoaded += _ => MelonCoroutines.Start(ApplyAll());
    }

    private IEnumerator ApplyAll()
    {
        if (!BoneLib.Player.HandsExist)
            yield break;

        // Wait 5 frames to ensure all UI elements are fully loaded.
        for (int i = 0; i < 5; i++)
            yield return null;

#if DEBUG
        Core.Instance.LoggerInstance.Msg("Applying coloring...");
#endif

        PreferencesUI.Apply();
        InventoryUI.Apply();
        AvatarUI.Apply();
        LevelUI.Apply();
        SpawnGunUI.Apply();
        Cursor.Apply();
        PopUpUI.ApplyAll();
    }

    internal void Apply(Element element)
    {
        if (!BoneLib.Player.HandsExist)
            return;

#if DEBUG
        Core.Instance.LoggerInstance.Msg($"Applying coloring for {element}...");
#endif

        switch (element)
        {
            case Element.PreferencesUI:
                PreferencesUI.Apply();
                break;
            case Element.InventoryUI:
                InventoryUI.Apply();
                break;
            case Element.AvatarUI:
                AvatarUI.Apply();
                break;
            case Element.LevelUI:
                LevelUI.Apply();
                break;
            case Element.SpawnGunUI:
                SpawnGunUI.Apply();
                break;
            case Element.Cursor:
                Cursor.Apply();
                break;
            case Element.PopUpUI:
                PopUpUI.ApplyAll();
                break;
        }
    }
}
