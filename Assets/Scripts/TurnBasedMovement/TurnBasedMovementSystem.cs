using System;
using UnityEngine;
using System.Collections;

public class TurnBasedMovementSystem : MonoBehaviour
{
    private int _turnIndex;

    [SerializeField] private Player[] _players;
    [SerializeField] private DiceRoller _diceRoller;
    [SerializeField] private Board _board;

    public static TurnBasedMovementSystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _diceRoller.OnDiceRolled += DiceRoller_OnDiceRolled;
        InitializePlayers();
    }

    private void InitializePlayers()
    {
        foreach (var player in _players)
        {
            player.Land = _board.GetLandAt(0);
        }
    }

    private void DiceRoller_OnDiceRolled(int firstDiceValue, int secondDiceValue)
    {
        StartCoroutine(MovePlayerToLand(firstDiceValue, secondDiceValue));
    }

    private IEnumerator MovePlayerToLand(int firstDiceValue, int secondDiceValue)
    {
        Player currentPlayer = _players[_turnIndex];

        int totalMoveAmount = firstDiceValue + secondDiceValue;
        int playerLandIndex = currentPlayer.Land.Index;
        int nextLandIndexToMove = playerLandIndex + totalMoveAmount;

        for (int i = playerLandIndex; i < nextLandIndexToMove; i++)
        {
            Land currentLand = _board.GetLandAt(i);
            Land nextLand = currentLand.NextLand;

            bool isMoving = true;

            currentPlayer.MoveTo(
                nextLand.Position,
                onArrived: () => {
                    isMoving = false;
                    currentPlayer.Land = nextLand;
                });

            yield return new WaitUntil(() => isMoving == false);
        }

        Land arrivedLand = currentPlayer.Land;
        arrivedLand.InvokeOnLanded(currentPlayer);

        _turnIndex = (_turnIndex + 1) % _players.Length;
    }
}
