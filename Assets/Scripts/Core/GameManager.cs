// GameManager.cs
using Soleria.World;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TilemapGroundManager tilemapGroundManager;

    public enum GameState { Booting, MainMenu, Playing, Paused, GameOver }

    public GameState CurrentState { get; private set; } = GameState.Booting;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameManager already exists - was destroyed.");
            return;
        }

        Instance = this;
        GameObject tileGroundManagerGO = new GameObject("GroundMan");
        tilemapGroundManager = tileGroundManagerGO.AddComponent<TilemapGroundManager>();
        tilemapGroundManager.groundTile = Resources.Load<GameTile>("Tiles/GroundTile"); // Adjust the path to your asset
        tilemapGroundManager.Initialize();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log("GameManager started.");

        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.orthographic = true;
            mainCam.transform.position = new Vector3(0, 0, -10);
        }
        else
        {
            Debug.LogWarning("Main Camera not found!");
        }

        SetGameState(GameState.MainMenu);
    }

    private void Update()
    {
        // Global game logic (optional)
    }

    public void SetGameState(GameState newState)
    {
        if (newState == CurrentState) return;

        Debug.Log($"Game State changed: {CurrentState} ➜ {newState}");
        CurrentState = newState;

        // Optional: Trigger events here (e.g., OnGameStateChanged)
    }
}
