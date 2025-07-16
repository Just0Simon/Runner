using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayEntryPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private InputActionAsset _inputActionAsset;
    [SerializeField]
    private SwipeConfiguration _swipeConfiguration;
    [SerializeField]
    private StrafeConfiguration _strafeConfiguration;
    [SerializeField]
    private IntegerVariableScriptableObject _gameScoreVariable;
    
    [Header("Scene References")]    
    [SerializeField]
    private Transform _playerSpawnPoint;
    [SerializeField]
    private PlayerCameraFollow _playerCameraFollow;
    
    [Header("Prefabs")]
    [SerializeField]
    private PlayerController _playerControllerPrefab;
    [SerializeField]
    private GameplayInterface _gameplayInterfacePrefab;
    [SerializeField]
    private GameplayManager _gameplayManagerPrefab;
    
    private InputSystem _inputSystem;
    private GameplayManager _gameplayManager;

    private void Awake()
    {
        // Clear value of game score in case last gameplay scene leave was unexpected.
        _gameScoreVariable.Reset();
        
        // Setup Gameplay Manager
        _gameplayManager = Instantiate(_gameplayManagerPrefab);
        
        SetupInputSystem();

        // Setup Gameplay Interface
        Instantiate(_gameplayInterfacePrefab);
    }

    private void Start()
    {
        var playerController = Instantiate(_playerControllerPrefab, _playerSpawnPoint.position, Quaternion.identity);
        playerController.Initialize(_inputSystem.GetProcessor<SwipeInputProcessor>(), _inputSystem.GetProcessor<StrafeInputProcessor>());

        var playerTransformModel = new PlayerTransformModel(playerController.transform);
        
        _playerCameraFollow.Initialize(playerTransformModel);
        
        _gameplayManager.Initialize(playerController);
    }

    private void SetupInputSystem()
    {
        _inputSystem = new InputSystem(_inputActionAsset);

        ITouchInputProcessor touchInputProcessor = new TouchInputProcessor();
        _inputSystem.AddProcessor(touchInputProcessor);
        
        ISwipeInputProcessor swipeDetector = new SwipeInputProcessor(_swipeConfiguration, touchInputProcessor);
        _inputSystem.AddProcessor(swipeDetector);
        
        IStrafeInputProcessor strafeInputProcessor = new StrafeInputProcessor(_strafeConfiguration, touchInputProcessor);
        _inputSystem.AddProcessor(strafeInputProcessor);
    }
}
