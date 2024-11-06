using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Model : MonoBehaviour
{
    [SerializeField] private BundleSupplies2DNotAnimated _view;
    public BundleSupplies2DNotAnimated View
    {
        get => _view;
        private set { }
    }


    [SerializeField] private List<Bundles> _bundlesList;
    public List<Bundles> BundlesList
    {
        get => _bundlesList; 
        private set { }
    }

    [SerializeField] private GameObject _uiSupplies;
    public GameObject UISupplies
    {
        get => _uiSupplies;
        private set { }
    }
    [SerializeField] private Button _buttonShowBunner;
    public Button Button
    {
        get => _buttonShowBunner;
        private set { }
    }
    [SerializeField] private Button _buttonBuy;
    public Button ButtonBuy
    {
        get => _buttonBuy;
        private set { }
    }

    public TextMeshProUGUI TmPro { get; set; }
    public bool WindowIsActive { get; set; }
    public bool TurnBunner { get; set; }

    private HashSet<Bundles> _bundlesHash;

    private void Awake()
    {
        //_suppliesHash = new HashSet<Supplies>(_suppliesList);
        _bundlesHash = new HashSet<Bundles>(_bundlesList);
    }

    public void FillBundleBanner(Bundles bundle)
    {
        _view.gameObject.SetActive(true);
        _view.DisplayBundleSupplies(bundle);
    }
}