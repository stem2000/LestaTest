using Cinemachine;
using GeneralLogic;
using PlayerLogic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField] private Transform _playerPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _deathHeight = -20;   
    

    [SerializeField] private UnityEvent<float> OnPlayerWin;
    [SerializeField] private UnityEvent OnPlayerLose; 
    [SerializeField] private UnityEvent OnPlayerSpawned;

    private GameTimer _timer;
    private Transform _playerTransform;

    private void Start()
    {
        SpawnPlayer();
        _timer = new GameObject("Timer").AddComponent<GameTimer>();
        OnPlayerSpawned?.Invoke();
    }

    private void FixedUpdate()
    {
        ControlPlayerPosition();
    }

    private void SpawnPlayer()
    {
        var player = Instantiate(_playerPrefab);  
        var worldInteractor = player.GetComponent<PlayerBus>().GetComponent<IWorldInteractionsProvider>();
        
        worldInteractor.OnPlayerDeath += ReactToPlayerDeath;

        _playerTransform = player.transform;
        _playerTransform.position = _spawnPoint.position;
    }

    private void ControlPlayerPosition()
    {
        if( _playerTransform.gameObject.activeSelf && _playerTransform.transform.position.y < _deathHeight)
        {
            var playerDamagable = _playerTransform.GetComponentInChildren<IDamageable>();

            if(playerDamagable != null)
                playerDamagable.MakeDamage(10000);
        }
    }

    private void ReactToPlayerDeath()
    {
        _timer.StopTimer();
        _playerTransform.gameObject.SetActive(false);
        OnPlayerLose?.Invoke();
    }

    public void ReactToPlayerWin()
    {
        _timer.StopTimer();
        _playerTransform.gameObject.SetActive(false);
        OnPlayerWin?.Invoke(_timer.GameTime);
    }

    public void ReactToPlayerStart()
    {
        _timer.StartTimer();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
