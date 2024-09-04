using TMPro;
using UnityEngine;

namespace GravityManipulationPuzzle
{
    /// <summary>
    /// Manages the game timer and handles end-of-time events.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [Tooltip("Time in Seconds")]
        [SerializeField][Range(0f, 600)] private float _timeLimit = 120f;

        [SerializeField] private TextMeshProUGUI _timerText;

        private float _currentTime;
        private bool _isTimerRunning;

        private void Start()
        {
            ResetTimer();
            StartTimer();
        }

        private void Update()
        {
            if (_isTimerRunning)
            {
                _currentTime -= Time.deltaTime;
                UpdateTimerUI(_currentTime);

                if (_currentTime <= 0)
                {
                    _currentTime = 0;
                    _isTimerRunning = false;
                    TimeEnded();
                }
            }
        }

        private void UpdateTimerUI(float currentTime)
        {
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            _timerText.text = $"{minutes:00}:{seconds:00}";
        }

        public void StartTimer() => _isTimerRunning = true;

        public void StopTimer() => _isTimerRunning = false;

        public void ResetTimer()
        {
            _currentTime = _timeLimit;
            _isTimerRunning = false;
        }

        private void TimeEnded() => GameManager.Instance.ShowGameOver("Game Over: Time's Up!");
    }
}
