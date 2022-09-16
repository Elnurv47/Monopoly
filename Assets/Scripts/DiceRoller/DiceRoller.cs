using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DiceRoller : MonoBehaviour
{
    private const int DICE_MIN_VALUE = 1;
    private const int DICE_MAX_VALUE = 6;

    private int _firstRolledDiceValue;
    private int _secondRolledDiceValue;

    [SerializeField] private Button _rollDiceButton;
    [SerializeField] private TextMesh _firstDiceText;
    [SerializeField] private TextMesh _secondDiceText;

    public Action<int, int> OnDiceRolled;

    private void Start()
    {
        _rollDiceButton.onClick.AddListener(RollDiceButton_OnClick);
    }

    private void RollDiceButton_OnClick()
    {
        StartCoroutine(RollDiceCoroutine());
    }

    private IEnumerator RollDiceCoroutine()
    {
        _firstRolledDiceValue = Random.Range(DICE_MIN_VALUE, DICE_MAX_VALUE + 1);
        _secondRolledDiceValue = Random.Range(DICE_MIN_VALUE, DICE_MAX_VALUE + 1);
        DisplayDiceValues(_firstRolledDiceValue, _secondRolledDiceValue);
        yield return new WaitForSeconds(0.5f);
        OnDiceRolled?.Invoke(_firstRolledDiceValue, _secondRolledDiceValue);
    }

    private void DisplayDiceValues(int firstDiceValue, int secondDiceValue)
    {
        _firstDiceText.text = firstDiceValue.ToString();
        _secondDiceText.text = secondDiceValue.ToString();
    }
}
