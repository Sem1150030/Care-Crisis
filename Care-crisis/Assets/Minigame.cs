using UnityEngine;

namespace DefaultNamespace

{
    public abstract class Minigame : MonoBehaviour
    {
        public abstract void StartGame(string gameName); // Start de minigame
        public abstract void EndGame(bool success); // Eindig de minigame
    }
}