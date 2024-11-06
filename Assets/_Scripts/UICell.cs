using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICell : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _tmPro;

    public void SetCellData(Sprite sprite, int text)
    {
        _image.sprite = sprite;
        _tmPro.SetText($"{text}");
    }
}