using Il2CppTMPro;
using UnityEngine.UI;

namespace Colorful.Coloring;

internal static class LevelUI
{
    internal static void Apply()
    {
        var color = Core.Instance.PreferencesManager.LevelUI.Value;
        var ui = BoneLib.Player.UIRig.popUpMenu.levelsPanelView;

        if (ui.pageText != null)
            ui.pageText.color = color;

        var titleText = ui.transform.Find("text_TITLE")?.GetComponent<TextMeshProUGUI>();
        if (titleText != null)
            titleText.color = color;

        var dividerImage = ui.transform.Find("image----------------")?.GetComponent<Image>();
        if (dividerImage != null)
            dividerImage.color = color;

        if (ui.items != null)
        {
            foreach (var sceneButton in ui.items)
            {
                var backlineImage = sceneButton?.transform.Find("image_backline")?.GetComponent<Image>();
                if (backlineImage != null)
                    backlineImage.color = color;
            }
        }

        if (ui.text != null)
        {
            foreach (var sceneButtonText in ui.text)
            {
                if (sceneButtonText != null)
                    sceneButtonText.color = color;
            }
        }

        ApplyColorToButtonImages(ui.forwardButton, color);
        ApplyColorToButtonImages(ui.backButton, color);

        var returnButton = ui.transform.Find("button_return");
        if (returnButton != null)
            ApplyColorToButtonImages(returnButton.gameObject, color);
    }

    private static void ApplyColorToButtonImages(UnityEngine.GameObject button, UnityEngine.Color color)
    {
        if (button == null)
            return;

        foreach (var image in button.GetComponentsInChildren<Image>(true))
        {
            image.color = color;
        }
    }
}
