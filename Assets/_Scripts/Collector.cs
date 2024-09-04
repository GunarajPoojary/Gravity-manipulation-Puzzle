using TMPro;
using UnityEngine;

namespace GravityManipulationPuzzle
{
    /// <summary>
    /// Manages the collection of items in the game and updates the UI accordingly.
    /// </summary>
    public class Collector : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _collectedCountText;
        [SerializeField] private int _numberOfAvailableCubes = 10;

        private int _collectedCount = 0;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;

            UpdateCollectedCountUI();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collectible"))
            {
                _collectedCount++;

                UpdateCollectedCountUI();

                Destroy(other.gameObject);

                if (_collectedCount >= _numberOfAvailableCubes)
                {
                    GameManager.Instance.StopTimer();

                    _gameManager.ShowGameOver("You Win!");
                }
            }
        }

        private void UpdateCollectedCountUI()
        {
            _collectedCountText.text = $"Collected Cubes: {_collectedCount} / {_numberOfAvailableCubes}";
        }
    }
}