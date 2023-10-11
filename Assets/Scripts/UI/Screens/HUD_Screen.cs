using TMPro;
using UnityEngine;
using PlayerLogic;

namespace Game_UI
{
    public class HUD_Screen : UI_Screen
    {
        [Header("HUD_Screen Variables")]
        [SerializeField] private TextMeshProUGUI _hpText;

        public void Initialize()
        {
            var playerStats = FindObjectOfType<PlayerBus>().GetStatsProvider();

            if(playerStats != null)
            {
                _hpText.text = playerStats.Hp.ToString();
                playerStats.OnHpChanged += UpdateHpText;
            }
        }

        public void UpdateHpText(float hp)
        {
            _hpText.text = hp.ToString();
        }
    }
}

