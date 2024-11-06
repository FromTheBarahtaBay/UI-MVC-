using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BundleSupplies2DNotAnimated : View
{
    // -------------- UI -----------------
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private GameObject _frameSupplies;
    [SerializeField] private GameObject _cellPrefub;
    [SerializeField] private Image _mainImage;
    [SerializeField] private TextMeshProUGUI _priceTMPro;
    [SerializeField] private TextMeshProUGUI _discontTMPro;
    [SerializeField] private GameObject WindowIsPurchaseSuccess;

    public override void DisplayBundleSupplies(Bundles bundle)
    {
        _header.SetText(bundle.HeaderText);
        _description.SetText(bundle.DescriptionText);
        _mainImage.sprite = bundle.MainSprite;
        _priceTMPro.SetText($"{bundle.PriceString}");
        _discontTMPro.SetText($"{bundle.Discount}");
        CreateCells(bundle);
    }

    public override void DisplayWindowIsPurchaseSuccess()
    {
        WindowIsPurchaseSuccess.SetActive(true);
        StartCoroutine(ScreenOff());
    }

    private IEnumerator ScreenOff()
    {
        yield return new WaitForSeconds(1);
        WindowIsPurchaseSuccess.SetActive(false);
    }

    private void CreateCells(Bundles bundle)
    {
        for (int i = 0; i < bundle.Supplies.Count; i++)
        {
            UICell cell = Instantiate(_cellPrefub, _frameSupplies.transform).GetComponent<UICell>();
            if (cell)
                cell.SetCellData(bundle.Supplies[i].Sprite, bundle.Supplies[i].Count);
        }
    }

    private void OnDisable()
    {
        DestroyCells();
    }

    private void DestroyCells()
    {
        foreach (Transform child in _frameSupplies.transform)
            Destroy(child.gameObject);
    }
}