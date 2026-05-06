using BoneLib.BoneMenu;
using Colorful.Utilities;
using System;
using UnityEngine;
using Element = Colorful.Coloring.Element;

namespace Colorful.BoneMenu;

internal class BoneMenuManager
{
    private Page Page { get; set; }

    internal Page ColorPickerPage { get; private set; }
    internal Color CurrentSelectedColor = Color.white;

    internal Page MainUIPage { get; private set; }
    internal FunctionElement PreferencesUI { get; private set; }
    internal FunctionElement InventoryUI { get; private set; }
    internal FunctionElement AvatarUI { get; private set; }
    internal FunctionElement LevelUI { get; private set; }
    internal FunctionElement SpawnGunUI { get; private set; }
    internal FunctionElement Cursor { get; private set; }

    internal Page RadialUIPage { get; private set; }
    internal FunctionElement PopUpUI_N { get; private set; }
    internal FunctionElement PopUpUI_NE { get; private set; }
    internal FunctionElement PopUpUI_E { get; private set; }
    internal FunctionElement PopUpUI_SE { get; private set; }
    internal FunctionElement PopUpUI_S { get; private set; }
    internal FunctionElement PopUpUI_SW { get; private set; }
    internal FunctionElement PopUpUI_W { get; private set; }
    internal FunctionElement PopUpUI_NW { get; private set; }

    internal BoneMenuManager()
    {
        Page = Page.Root.CreatePage(RichTextUtilities.Rainbowify("Colorful"), Color.white);

        SetupColorPickerPage();
        SetupMainUIPage();
        SetupRadialUIPage();
    }

    private void SetupColorPickerPage()
    {
        ColorPickerPage = Page.CreatePage("Color Picker", Color.white);

        var colorPreview = ColorPickerPage.CreateFunction("Color Preview", Color.white, null);

        ColorPickerPage.CreateFloat("Red", Color.red, 1f, 0.1f, 0f, 1f, value =>
        {
            CurrentSelectedColor.r = value;
            colorPreview.ElementColor = CurrentSelectedColor;
        });
        ColorPickerPage.CreateFloat("Green", Color.green, 1f, 0.1f, 0f, 1f, value =>
        {
            CurrentSelectedColor.g = value;
            colorPreview.ElementColor = CurrentSelectedColor;
        });
        ColorPickerPage.CreateFloat("Blue", Color.blue, 1f, 0.1f, 0f, 1f, value =>
        {
            CurrentSelectedColor.b = value;
            colorPreview.ElementColor = CurrentSelectedColor;
        });
    }

    private void SetupMainUIPage()
    {
        var preferences = Core.Instance.PreferencesManager;

        MainUIPage = Page.CreatePage("Main UI", Color.white);

        PreferencesUI = CreateColorButton(MainUIPage, "Apply to Preferences UI", preferences.PreferencesUI.Value, Element.PreferencesUI,
            color => { preferences.PreferencesUI.Value = color; PreferencesUI.ElementColor = color; });

        InventoryUI = CreateColorButton(MainUIPage, "Apply to Inventory UI", preferences.InventoryUI.Value, Element.InventoryUI,
            color => { preferences.InventoryUI.Value = color; InventoryUI.ElementColor = color; });

        AvatarUI = CreateColorButton(MainUIPage, "Apply to Avatar UI", preferences.AvatarUI.Value, Element.AvatarUI,
            color => { preferences.AvatarUI.Value = color; AvatarUI.ElementColor = color; });

        LevelUI = CreateColorButton(MainUIPage, "Apply to Level UI", preferences.LevelUI.Value, Element.LevelUI,
            color => { preferences.LevelUI.Value = color; LevelUI.ElementColor = color; });

        SpawnGunUI = CreateColorButton(MainUIPage, "Apply to Spawn Gun UI", preferences.SpawnGunUI.Value, Element.SpawnGunUI,
            color => { preferences.SpawnGunUI.Value = color; SpawnGunUI.ElementColor = color; });

        Cursor = CreateColorButton(MainUIPage, "Apply to Cursor", preferences.Cursor.Value, Element.Cursor,
            color => { preferences.Cursor.Value = color; Cursor.ElementColor = color; });
    }

    private void SetupRadialUIPage()
    {
        var preferences = Core.Instance.PreferencesManager;

        RadialUIPage = Page.CreatePage("Radial UI", Color.white);

        PopUpUI_N = CreateColorButton(RadialUIPage, "Apply to North Region", preferences.PopUpUI_N.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_N.Value = color; PopUpUI_N.ElementColor = color; });

        PopUpUI_NE = CreateColorButton(RadialUIPage, "Apply to North East Region", preferences.PopUpUI_NE.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_NE.Value = color; PopUpUI_NE.ElementColor = color; });

        PopUpUI_E = CreateColorButton(RadialUIPage, "Apply to East Region", preferences.PopUpUI_E.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_E.Value = color; PopUpUI_E.ElementColor = color; });

        PopUpUI_SE = CreateColorButton(RadialUIPage, "Apply to South East Region", preferences.PopUpUI_SE.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_SE.Value = color; PopUpUI_SE.ElementColor = color; });

        PopUpUI_S = CreateColorButton(RadialUIPage, "Apply to South Region", preferences.PopUpUI_S.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_S.Value = color; PopUpUI_S.ElementColor = color; });

        PopUpUI_SW = CreateColorButton(RadialUIPage, "Apply to South West Region", preferences.PopUpUI_SW.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_SW.Value = color; PopUpUI_SW.ElementColor = color; });

        PopUpUI_W = CreateColorButton(RadialUIPage, "Apply to West Region", preferences.PopUpUI_W.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_W.Value = color; PopUpUI_W.ElementColor = color; });

        PopUpUI_NW = CreateColorButton(RadialUIPage, "Apply to North West Region", preferences.PopUpUI_NW.Value, Element.PopUpUI,
            color => { preferences.PopUpUI_NW.Value = color; PopUpUI_NW.ElementColor = color; });
    }
    
    private FunctionElement CreateColorButton(Page page, string label, Color initialColor, Element element, Action<Color> saveAndUpdate)
    {
        var preferences = Core.Instance.PreferencesManager;
        var coloring = Core.Instance.ColoringManager;

        return page.CreateFunction(label, initialColor, () =>
        {
            saveAndUpdate(CurrentSelectedColor);
            preferences.Save();
            coloring.Apply(element);
        });
    }
}
