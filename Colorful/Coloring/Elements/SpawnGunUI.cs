using UnityEngine.UI;

namespace Colorful.Coloring;

internal static class SpawnGunUI
{
    internal static void Apply()
    {
        var color = Core.Instance.PreferencesManager.SpawnGunUI.Value;
        var ui = BoneLib.Player.UIRig.popUpMenu.spawnablesPanelView;

        foreach (var tabButton in ui.tabButtons)
        {
            tabButton.tmp.color = color;
            tabButton.highlight.color = color;
            tabButton.transform.FindChild("image_icon").GetComponent<Image>().color = color;
        }

        foreach (var treeButton in ui.treeButtons)
        {
            treeButton.tmp.color = color;
            treeButton.highlight.color = color;
            treeButton.special.color = color;
        }

        foreach (var itemButton in ui.itemButtons)
        {
            itemButton.tmp.color = color;
            itemButton.highlight.color = color;
        }

        ui.treeBackButton.highlight.color = color;
        ui.treeBackButton.special.color = color;

        ui.swapSortButton.highlight.color = color;
        ui.swapSortButton.special.color = color;

        ui.treeScrollUpButton.highlight.color = color;
        ui.treeScrollUpButton.special.color = color;

        ui.treeScrollDownButton.highlight.color = color;
        ui.treeScrollDownButton.special.color = color;

        ui.itemScrollUpButton.highlight.color = color;
        ui.itemScrollUpButton.special.color = color;

        ui.itemScrollDownButton.highlight.color = color;
        ui.itemScrollDownButton.special.color = color;

        ui.treePathText.color = color;
        ui.labelText.color = color;
        ui.itemPageText.color = color;

        ui.selectedTitle.color = color;
        ui.selectedPallet.color = color;
        ui.selectedAuthor.color = color;
        ui.selectedDescription.color = color;
        ui.selectedTags.color = color;

        ui.capsuleButton.tmp.color = color;
        ui.capsuleButton.special.color = color;
        ui.capsuleButton.transform.parent.GetComponent<Image>().color = color;

        ui.transform.Find("group_tabs/image----------------").GetComponent<Image>().color = color;
        ui.transform.Find("HEADER/button_Close/image_frontline").GetComponent<Image>().color = color;
    }
}
