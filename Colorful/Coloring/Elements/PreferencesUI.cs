using Il2CppTMPro;
using UnityEngine.UI;

namespace Colorful.Coloring;

internal static class PreferencesUI
{
    internal static void Apply()
    {
        var color = Core.Instance.PreferencesManager.PreferencesUI.Value;
        var ui = BoneLib.Player.UIRig.popUpMenu.preferencesPanelView;
        
        var tmpTexts = ui.GetComponentsInChildren<TMP_Text>(true);
        foreach (var tmp in tmpTexts)
        {
            tmp.color = color;
        }
        
        var uiImages = ui.GetComponentsInChildren<Image>(true);
        foreach (var image in uiImages)
        {
            if (image.name.Contains("Viewport"))
            {
                var childImages = image.GetComponentsInChildren<Image>(true);
                foreach (var childImage in childImages)
                {
                    if (childImage != image)
                    {
                        childImage.color = color;
                    }
                }
                continue;
            }
            if (image.name.Contains("image_bgFade"))
            {
                continue;
            }
            image.color = color;
        }
        
        var rawImages = ui.GetComponentsInChildren<RawImage>(true);
        foreach (var image in rawImages)
        {
            image.color = color;
        }
    }
}