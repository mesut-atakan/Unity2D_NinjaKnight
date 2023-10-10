using UnityEngine;
using DG.Tweening;


namespace Character
{
    internal class PlayerController : CharacterProperties
    {
#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        [Header("Scripts And Components")]

        [Tooltip("Charact in RigidBody component")]
        [SerializeField] private Rigidbody2D rb;



        [Tooltip("This Character in Transform Get Component")]
        [SerializeField] private Transform characterTransform;



        [Tooltip("This Character Get Animator Component")]
        [SerializeField] private Animator animator;



        [Tooltip("Add the game manager `GameManager` class here!")]
        [SerializeField] private GameManager gameManager;























        [Header("Character Other Properties")]
        

        [Tooltip("Character Jump Force Amout")]
        [SerializeField] private float jumpForce;



        [Tooltip("Cahracter Run Speed")]
        [SerializeField] private float characterRunSpeed;





        [Header("War properties")]

        [Tooltip("War Area Transform")]
        [SerializeField] private Transform warTransform;


        [Tooltip("War Layer Mask")]
        [SerializeField] private LayerMask warLayerMask;










        
        [Header("Jump Properties")]


        [Tooltip("Add the object that will be used to check whether the character touches the ground or not!")]
        [SerializeField] private Transform groudTransform;


        [Tooltip("Which layer is on which the character is eligible to jump?")]
        [SerializeField] private LayerMask groundLayerMask;

#endregion ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||






#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        private float _characterCurrentSpeed;       // The instant speed of the character will be observed here!


        private bool _isGrounded;                   // If the character touches the ground, this boolean value will be true!


        private bool _isDamage;                     // With this variable, we will control whether the character's sword swinging animation starts and ends!

#endregion






        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.tag == "Win")
            {
                this.gameManager._enemyActive = false;
                this.gameManager._cameraController._cameraIsMoveProperties = false;
                this._isDead = true;
                this.gameManager._winnerObject.SetActive(true);
                StartCoroutine(this.gameManager.RestartGame(3f));
            }
        }






        /// <summary>
        /// With this method, you can make your character move with Horizontal inputs!
        /// </summary>
        protected override void CharacterMove()
        {
            // ~~ Variables ~~
            float _horizontal;      // input variable that will read the (left, right) values ​​on the horizontal axis
            
            _horizontal = Input.GetAxis("Horizontal");  // If the player uses Horizontal inputs, the 'horizontal' float variable will take a value between -1 and +1, and this way we will know which way our character will go!


            // The character's speed has been determined!
            if (_horizontal != 0)
            {
                if (!this._isDamage)
                    AnimatorController(1);

                // We check whether the characters can run or not!
                if (CharacterRun())
                {
                    this.animator.speed = 1.0f;
                    this._characterCurrentSpeed = this.characterRunSpeed;
                }
                else
                {
                    this.animator.speed = 0.75f;
                    this._characterCurrentSpeed = this.characterMoveSpeed;
                }
            }
            else
            {
                this.animator.speed = 1.0f;
                
                if (!this._isDamage)
                    AnimatorController(0);
            }
        
        
            // The character moves by multiplying the 'horizontal' value with the character's speed!
            this.rb.velocity = new Vector2(_horizontal * this._characterCurrentSpeed, rb.velocity.y);
            
            if (_horizontal < 0)
            {
                this.characterTransform.localScale = new Vector2(-1.3f, +1.3f);
            }
            else if (_horizontal > 0)
            {
                this.characterTransform.localScale = new Vector2(+1.3f, +1.3f);
            }
        }













        /// <summary>
        /// With this method, you can make your character damage other enemies!
        /// </summary>
        protected override void Damage()
        {
            Collider2D _otherObject;
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                this._isDamage = true;
                _otherObject = Physics2D.OverlapCapsule(warTransform.position, new Vector2(1f,2f), CapsuleDirection2D.Horizontal, 0, this.warLayerMask);
                AnimatorController(3);

                if (_otherObject != null)
                {
                    _otherObject.GetComponent<EnemyAI>().TakeDamage();
                }
            }
        }







        internal void DamageOff()
        {
            this._isDamage = false;
        }











        /// <summary>
        /// With this method, you can ensure that your character takes damage!
        /// </summary>
        internal override void TakeDamage()
        {
            this.gameManager._gameOverObject.SetActive(true);
            AnimatorController(4);
            this.gameManager._cameraController.CameraShake();
            Debug.Log("Player Damage Alior!");
            Destroy(this.gameObject, 3f);
            StartCoroutine(this.gameManager.RestartGame(2.8f));
        }










        
        /// <summary>
        /// With this method, the character will be able to jump while touching the ground!
        /// </summary>
        private void Jump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                this._isGrounded = Physics2D.OverlapCapsule(groudTransform.position, new Vector2(0.6f,0.3f), CapsuleDirection2D.Horizontal, 0, groundLayerMask);
                if (this._isGrounded)
                {
                    AnimatorController(2);
                    this.rb.velocity = new Vector2(this.rb.velocity.x, this.jumpForce);
                }
            }
        }











        /// <summary>
        /// With this method, you can run private methods in other classes (`Game Manager`)!
        /// </summary>
        internal void PlayerCharacterController()
        {
            if (!this._isDead)
            {
                CharacterMove();
                Jump();
                Damage();
            }
        }
        
        








        /// <summary>
        /// With this method, you can understand whether the Character is running or not!
        /// </summary>
        /// <returns>If the player presses the required key to run, the method will return true, otherwise the method will return false!</returns>
        private bool CharacterRun()
        {
            return Input.GetKey(KeyCode.LeftShift);
        } 















        /// <summary>
        /// This connects to the character's animation and changes the character's animation!
        /// </summary>
        /// <param name="index">Enter the index number of the animation!</param>
        private void AnimatorController(int index)
        {
            this.animator.SetInteger("playerState", index);
        }
    }
}
