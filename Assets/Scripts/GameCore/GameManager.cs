using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore
{
    public class GameManager : MonoBehaviour
    {
        private Queue<Action> gameEventsQueue = new();

        private void Update()
        {
            if (gameEventsQueue.Any())
            {
                gameEventsQueue.Dequeue()?.Invoke();
            }
        }
    }
}