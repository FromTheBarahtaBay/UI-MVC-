using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] private Model _model;

    private void Awake()
    {
        _model.ButtonBuy.onClick.AddListener(ShowPurchaseCompletedBunner);
        _model.Button.onClick.AddListener(ShowSuppliesMenu);
        _model.TmPro = _model.Button.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void ShowSuppliesMenu()
    {
        if (!_model.UISupplies) return;
        _model.WindowIsActive = !_model.WindowIsActive;

        if (_model.WindowIsActive)
        {
            _model.UISupplies.SetActive(true);
            _model.TmPro.SetText("Close window");
            _model.FillBundleBanner(SetRandomBundleOnBoard());
        }  
        else
        {
            _model.UISupplies.SetActive(false);
            _model.TmPro.SetText("Buy supplies");
        }
    }

    private Bundles SetRandomBundleOnBoard()
    {
        Bundles bundle;
        _model.TurnBunner = !_model.TurnBunner;
        if (_model.TurnBunner)
            bundle = _model.BundlesList[0];
        else bundle = _model.BundlesList[1];

        bundle.SetSuppliesValues();

        return bundle;
    }

    private void ShowPurchaseCompletedBunner()
    {
        _model.View.DisplayWindowIsPurchaseSuccess();
    }
}