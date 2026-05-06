namespace Colorful.Coloring;

internal static class InventoryUI
{
    internal static void Apply()
    {
        var color = Core.Instance.PreferencesManager.InventoryUI.Value;
        var ui = BoneLib.Player.UIRig.popUpMenu.itemSlotsPanelView;

        foreach (var slot in ui.slots)
        {
            slot.color1 = color;
            slot.color2 = color;
            slot.highlightColor1 = color;
            slot.highlightColor2 = color;

            foreach (var element in slot.elements)
            {
                element.SetColors(color, color);
            }
        }
    }
}
