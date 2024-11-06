using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bundle", menuName = "Bundle/NewBundle")]
public class Bundles : ScriptableObject
{
    public string HeaderText;
    public string DescriptionText;
    public Sprite MainSprite;
    public float Price;
    [HideInInspector] public string PriceString;
    public int Discount;
    public List<Supplies> Supplies;
    public int[] Values;

    public void SetSuppliesValues()
    {
        for (int i = 0; i < Supplies.Count; i++)
            Supplies[i].Count = Values[i];
        if (Discount != 0)
            FormPriceString();
    }

    private void FormPriceString()
    {
        float newPrice = Price * (100 - Discount) / 100;
        PriceString = $"${newPrice} \n<size=17><s>${Price}</s></size>";
    }
}