using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset _inputActionAsset;
    [SerializeField]
    private SwipeConfiguration _swipeConfiguration;
    [SerializeField]
    private StrafeConfiguration _strafeConfiguration;
    [SerializeField]
    private PlayerCameraFollow _playerCameraFollow;
    
    [SerializeField]
    private PlayerController _playerControllerPrefab;
    
    [SerializeField]
    private Transform _playerSpawnPoint;
    
    private InputSystem _inputSystem;

    private void Awake()
    {
        SetupInputSystem();
    }

    private void Start()
    {
        var playerController = Instantiate(_playerControllerPrefab, _playerSpawnPoint.position, Quaternion.identity);
        playerController.Initialize(_inputSystem.GetProcessor<SwipeInputProcessor>(), _inputSystem.GetProcessor<StrafeInputProcessor>());

        var playerTransformModel = new PlayerTransformModel(playerController.transform);
        
        _playerCameraFollow.Initialize(playerTransformModel);
    }

    private void SetupInputSystem()
    {
        _inputSystem = new InputSystem(_inputActionAsset);

        var touchInputProcessor = new TouchInputProcessor();
        _inputSystem.AddProcessor(touchInputProcessor);
        
        var swipeDetector = new SwipeInputProcessor(_swipeConfiguration, touchInputProcessor);
        _inputSystem.AddProcessor(swipeDetector);
        
        var strafeInputProcessor = new StrafeInputProcessor(_strafeConfiguration, touchInputProcessor);
        _inputSystem.AddProcessor(strafeInputProcessor);
    }
}
