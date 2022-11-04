using System;
using System.Collections.Generic;
using UnityEngine;

public class PropertyLand : Land
{
    private Dictionary<int, int> _propertyPurchasePrices = new Dictionary<int, int>()
    {
        { 1, 200 },
        { 2, 500 },
        { 3, 1000 },
        { 4, 2000 },
    };

    public Dictionary<int, int> PropertyPurchasePrices { get => _propertyPurchasePrices; }

    public int RentRate { get; } = 150;

    private PropertyLandData _propertyLandData;
    private PropertyLandAction _propertyLandAction;

    [SerializeField] private TextMesh _ownerNameText;

    private void Start()
    {
        _propertyLandData = new PropertyLandData(_propertyPurchasePrices, RentRate);
        _propertyLandAction = LandActionFactory.Instance.GetPropertyLandAction();
    }

    public override void InvokeOnLanded(Player landedPlayer)
    {
        base.InvokeOnLanded(landedPlayer);
        Debug.Log(landedPlayer.name + " landed on property land");

        HandleRent(landedPlayer);

        _propertyLandData.LandedPlayer = landedPlayer;
        _propertyLandData.Land = this;
        _propertyLandAction.Display(_propertyLandData);
    }

    private void HandleRent(Player landedPlayer)
    {
        if (landedPlayer == Owner || Owner == null) return;

        landedPlayer.PayMoneyTo(RentRate, Owner);
    }

    public void SetOwner(Player newOwner)
    {
        Owner = newOwner;
        _ownerNameText.text = Owner.name;
    }
}

public class PropertyLandData
{
    public Dictionary<int, int> HousePurchasePrices { get; private set; }
    public int RentRate { get; private set; }
    public Player LandedPlayer { get; set; }
    public Land Land { get; set; }

    public PropertyLandData(Dictionary<int, int> housePurchasePrices,int rentRate)
    {
        HousePurchasePrices = housePurchasePrices;
        RentRate = rentRate;
    }
}
