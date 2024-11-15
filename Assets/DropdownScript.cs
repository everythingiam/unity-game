using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DropdownScript : MonoBehaviour
{
    [SerializeField] private ActionBasedSnapTurnProvider snapTurn;
    [SerializeField] private ActionBasedContinuousTurnProvider continuousTurn;

    public void TurnProviderSelect(int value)
    {
        if (value == 0)
        {
            snapTurn.enabled = true;
            continuousTurn.enabled = false;
        }

        if (value == 1)
        {
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }
    }

    public void Start()
    {
    }
}
