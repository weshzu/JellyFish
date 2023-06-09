using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    

	public static GameManager instance = null;




    [SerializeField] private GameObject mainMenu;

    [SerializeField] private GameObject resetButton;

    public Text scoreText;

    private int score = 0;


	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;



   
   

	//public acessors and mutatator this will retrieve the data

	public bool PlayerActive {
		get { return playerActive; }
	}

	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStarted {
		get { return gameStarted; }
	}


	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

        //DontDestroyOnLoad (gameObject);  removed

        Assert.IsNotNull (mainMenu);


	}

	// Use this for initialization
	void Start () {

        scoreText.text = "Score:" + score;



     
    

	}

	// Update is called once per frame
	void Update () {

	}

    public void PlayerCollided(){
        gameOver = true;
        resetButton.SetActive(true);
     
		
	}

	public void PlayerStartedGame() {
		playerActive = true;
	}

    public void EnterGame() {
        mainMenu.SetActive(false);
    gameStarted = true;

    }

    public void AddPoint(){
        score = score + 1;
        scoreText.text = "Score:" + score;
    }

   
  
	
   }
