using UnityEngine;
using UnityEngine.UI;
using RiseOfTurkics.Core;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private Text turnText;
    [SerializeField] private Text factionText;
    [SerializeField] private Text livestockText;
    [SerializeField] private Text tradeText;
    [SerializeField] private Text cultureText;
    [SerializeField] private Text techText;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Button battleButton;
    [SerializeField] private Button saveButton;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        if (gameController.TurnManager != null)
        {
            gameController.TurnManager.TurnStarted += UpdateUI;
            gameController.TurnManager.TurnEnded += UpdateUI;
        }

        endTurnButton.onClick.AddListener(OnEndTurnClicked);
        battleButton.onClick.AddListener(OnBattleClicked);
        saveButton.onClick.AddListener(OnSaveClicked);

        UpdateUI(null, null);
    }

    private void UpdateUI(object sender, TurnEventArgs e)
    {
        if (gameController == null) return;

        turnText.text = $"TURN: {gameController.TurnManager.CurrentTurn}";
        factionText.text = $"FACTION: {gameController.TurnManager.CurrentFaction}";
        livestockText.text = $"LIVESTOCK: {gameController.Resources["livestock"]}";
        tradeText.text = $"TRADE: {gameController.Resources["trade"]}";
        cultureText.text = $"CULTURE: {gameController.Resources["culture"]}";
        techText.text = $"TECH: {gameController.Resources["technology"]}";
    }

    private void OnEndTurnClicked()
    {
        gameController.EndTurn();
        Debug.Log("Turn ended!");
    }

    private void OnBattleClicked()
    {
        SimulateBattle();
    }

    private void OnSaveClicked()
    {
        var saveData = new SaveData
        {
            SaveName = "QuickSave",
            Campaign = "TurkicExpansion",
            CurrentBattle = gameController.TurnManager.CurrentTurn,
            PlayerFaction = gameController.TurnManager.CurrentFaction,
            GameYear = 1200 + gameController.TurnManager.CurrentTurn,
            Livestock = gameController.Resources["livestock"],
            Trade = gameController.Resources["trade"],
            Culture = gameController.Resources["culture"],
            Technology = gameController.Resources["technology"]
        };

        string path = Application.persistentDataPath + "/save.json";
        SaveLoadManager.Save(path, saveData);
    }

    private void SimulateBattle()
    {
        var attackers = new Unit[]
        {
            new Unit(UnitType.HeavyCavalry, 50, 2),
            new Unit(UnitType.TurkicInfantry, 60, 2)
        };

        var defenders = new Unit[]
        {
            new Unit(UnitType.Archer, 40, 2),
            new Unit(UnitType.TurkicInfantry, 80, 2)
        };

        var result = gameController.ResolveBattle(
            gameController.TurnManager.CurrentFaction,
            attackers,
            "Enemy",
            defenders,
            Biome.Steppe
        );

        Debug.Log($"Battle: {result.WinnerFaction} wins!");
        Debug.Log($"Attacker losses: {result.AttackerLosses}");
        Debug.Log($"Defender losses: {result.DefenderLosses}");
    }

    private void OnDestroy()
    {
        if (gameController != null && gameController.TurnManager != null)
        {
            gameController.TurnManager.TurnStarted -= UpdateUI;
            gameController.TurnManager.TurnEnded -= UpdateUI;
        }
    }
}
