using Game_UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game_UI
{
    public class RestartScreen : UI_Screen
    {
        [SerializeField] private TextMeshProUGUI _resultTextTMP;
        [SerializeField] private TextMeshProUGUI _timeTextTMP;
        [SerializeField] private Button _restartButton;
        [SerializeField] private UnityEvent OnGameRestart;

        [SerializeField] private string _winText = "Победа!";
        [SerializeField] private string _loseText = "Поражение!";

        private string _timeText = "Время прохождения:";

        private void Start()
        {
            _restartButton.onClick.AddListener(InvokeOnRestart);
        }

        private void InvokeOnRestart()
        {
            OnGameRestart?.Invoke();
        }

        public void MakeOnPlayerWin(float time)
        {
            _resultTextTMP.text = _winText;
            _timeTextTMP.text = $"{_timeText} {time}";
        }

        public void MakeOnPlayerLose()
        {
            _resultTextTMP.text = _loseText;
            _timeTextTMP.text = "";
        }
    }
}
