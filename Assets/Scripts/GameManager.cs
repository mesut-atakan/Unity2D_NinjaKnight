using Character;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;


internal class GameManager : MonoBehaviour
{
#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||

    [Header("Classes")]

    [Tooltip("Add the class that will manage the player's character to this variable!")]
    [SerializeField] private PlayerController playerController;



    [Tooltip("With this boolean variable you can block or unblock enemies!")]
    [SerializeField] private bool enemyActive = true;

    [Tooltip("Add Enemy Characters here!")]
    [SerializeField] private List<Character.EnemyAI> enemyCharacters = new List<EnemyAI>();


    [Tooltip("Add the class that provides camera controls here!")]
    [SerializeField] private CameraController cameraController;







    










    [Header("UI")]


    [Tooltip("Winner UI Object")]
    [SerializeField] private GameObject winnerObject;



    [Tooltip("Game Over UI Object")]
    [SerializeField] private GameObject gameOverObject;

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||







#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| PROPERTIES ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||

    internal PlayerController _playerController
    {
        get { return this.playerController; }
        set { this.playerController = value; }
    }



    internal CameraController _cameraController
    {
        get { return this.cameraController; }
        set { this.cameraController = value; }
    }


    internal List<EnemyAI> _enemyCharacters
    {
        get { return this.enemyCharacters; }
        set { this.enemyCharacters = value; }
    }

    internal GameObject _winnerObject
    {
        get { return this.winnerObject; }
        set { this.winnerObject = value;}
    }

    internal GameObject _gameOverObject
    {
        get { return this.gameOverObject; }
        set { this.gameOverObject = value; }
    }

    internal bool _enemyActive
    {
        set { this.enemyActive = value; }
    }

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||













#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| MonoBehaviour Life return Functions||~~~~~~~~~~~~||X||~~~~~~~~~~~~||

    private void Awake() 
    {
        
    }


    private void Start() 
    {
        
    }


    private void Update()
    {
        this.playerController.PlayerCharacterController();

        if (this.enemyCharacters.Count > 0 && this.enemyActive)
        {
            foreach(EnemyAI enemy in this.enemyCharacters)
            {
                enemy.EnemyAICharacterController();
            }
        }


        
    }


    private void FixedUpdate() 
    {
        
    }




    private void LateUpdate() 
    {
        this.cameraController.CameraMove();
    }





    /// <summary>
    /// Method that will restart the active scene!
    /// </summary>
    /// <param name="duration">Leveli acmak icin bekleme suresini giriniz!</param>
    internal IEnumerator RestartGame(float duration)
    {
        // ~~ Variables ~~ 
        ushort _currentSceneIndex;

        _currentSceneIndex = (ushort)SceneManager.GetActiveScene().buildIndex;  // The index number of the actively running scene is kept in temporary memory!

        // standby time
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(_currentSceneIndex); // Load Level!
    }

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||
}