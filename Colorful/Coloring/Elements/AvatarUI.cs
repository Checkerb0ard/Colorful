using Il2CppTMPro;
using UnityEngine.UI;

namespace Colorful.Coloring;

internal static class AvatarUI
{
    internal static void Apply()
    {
        var color = Core.Instance.PreferencesManager.AvatarUI.Value;
        var ui = BoneLib.Player.UIRig.popUpMenu.avatarsPanelView;

        foreach (var image in ui.GetComponentsInChildren<Image>(true))
        {
            if (image.name != "image_bgFade")
                image.color = color;
        }

        foreach (var text in ui.GetComponentsInChildren<TMP_Text>(true))
        {
            text.color = color;
        }
    }
}
