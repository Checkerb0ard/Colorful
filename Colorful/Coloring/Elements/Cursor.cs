using Il2CppSLZ.Bonelab;

namespace Colorful.Coloring;

internal static class Cursor
{
    internal static void Apply()
    {
        var color = Core.Instance.PreferencesManager.Cursor.Value;
        var cursor = BoneLib.Player.UIRig.popUpMenu.cursorStart.transform.parent;

        foreach (var pageElementView in cursor.GetComponentsInChildren<PageElementView>(true))
        {
            pageElementView.color1 = color;
            pageElementView.color2 = color;
            pageElementView.highlightColor1 = color;
            pageElementView.highlightColor2 = color;
        }

        foreach (var highlightUI in cursor.GetComponentsInChildren<HighlightUI>(true))
        {
            highlightUI.color1 = color;
            highlightUI.color2 = color;
        }
    }
}
