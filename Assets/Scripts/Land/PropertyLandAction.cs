using UnityEngine;
using UnityEngine.UI;

public class PropertyLandAction : MonoBehaviour
{
    private Player _playerExecutingAction;
    private Land _actionExecutedOnLand;

    [SerializeField] private GameObject _landActionUI;
    [SerializeField] private Text _level1HousePriceText;
    [SerializeField] private Text _level2HousePriceText;
    [SerializeField] private Text _level3HousePriceText;
    [SerializeField] private Text _level4HousePriceText;
    [SerializeField] private Text _rentRateText;

    [SerializeField] private Button _level1HouseButton;

    public void Display(PropertyLandData propertyLandData)
    {
        _playerExecutingAction = propertyLandData.LandedPlayer;
        _actionExecutedOnLand = propertyLandData.Land;

        _landActionUI.SetActive(true);

        _level1HousePriceText.text = propertyLandData.HousePurchasePrices[1].ToString();
        _level2HousePriceText.text = propertyLandData.HousePurchasePrices[2].ToString();
        _level3HousePriceText.text = propertyLandData.HousePurchasePrices[3].ToString();
        _level4HousePriceText.text = propertyLandData.HousePurchasePrices[4].ToString();
        _rentRateText.text = propertyLandData.RentRate.ToString();

        if (_actionExecutedOnLand.Owner == _playerExecutingAction)
        {
            _level1HouseButton.interactable = false;
        }
    }

    public void OnLevel1HouseButtonClicked()
    {
        _landActionUI.SetActive(false);
        _playerExecutingAction.TryBuyPropertyOn(_actionExecutedOnLand as PropertyLand);
    }

    public void OnCancelButtonClicked()
    {
        _landActionUI.SetActive(false);
    }
}
