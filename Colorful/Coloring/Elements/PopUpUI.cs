using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace Colorful.Coloring;

internal static class PopUpUI
{
    private static readonly Regex RegionNamePattern = new Regex("Region_([A-Z]+)", RegexOptions.Compiled);

    internal static void ApplyAll()
    {
        var ui = BoneLib.Player.UIRig.popUpMenu.radialPageView;

        foreach (var button in ui.buttons)
        {
            var match = RegionNamePattern.Match(button.gameObject.name);
            if (match.Success)
            {
                string regionDirection = match.Groups[1].Value;
                Color regionColor = GetColorForRegion(regionDirection);

                button.color1 = regionColor;
                button.color2 = regionColor;
                button.textMesh.color = regionColor;
                button.icon.GetComponent<Image>().color = regionColor;
            }
            else
            {
                button.color1 = Color.white;
                button.color2 = Color.white;
            }
        }
    }

    private static Color GetColorForRegion(string regionDirection)
    {
        var preferences = Core.Instance.PreferencesManager;

        return regionDirection switch
        {
            "N"  => preferences.PopUpUI_N.Value,
            "NE" => preferences.PopUpUI_NE.Value,
            "E"  => preferences.PopUpUI_E.Value,
            "SE" => preferences.PopUpUI_SE.Value,
            "S"  => preferences.PopUpUI_S.Value,
            "SW" => preferences.PopUpUI_SW.Value,
            "W"  => preferences.PopUpUI_W.Value,
            "NW" => preferences.PopUpUI_NW.Value,
            _    => Color.white,
        };
    }
}
