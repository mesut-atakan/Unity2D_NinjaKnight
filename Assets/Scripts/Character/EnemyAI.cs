using System.Collections;
using UnityEngine;



namespace Character
{
    internal class EnemyAI : CharacterProperties
    {
#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||


        [Header("Other Character Properties")]

        [Tooltip("Character Slow Speed")]
        [SerializeField] private float characterSlowMoveSpeed = 3f;


        [Tooltip("Enter how high the character will jump!")]
        [SerializeField] private float jumpForce = 4;


        [Tooltip("Enter the wall and floor layer")]
        [SerializeField] private LayerMask groundLayerMask;









        [Header("Components")]

        [Tooltip("Let me put the `GameManager` class, which is the game manager, here!")]
        [SerializeField] private GameManager gameManager;



        [Tooltip("Add the character's `RigidBody` component here!")]
        [SerializeField] private Rigidbody2D rb;



        [Tooltip("Add the `Animator` Component of this enemy character here!")]
        [SerializeField] private Animator animator;


        [Tooltip("Add the character's Collider component here")]
        [SerializeField] private Collider2D characterCollider;

        








        [Header("Transform And Objects")]

        [Tooltip("Add the player's character here!")]
        [SerializeField] private Transform playerCharacter;



        [Tooltip("Wall Control Transform")]
        [SerializeField] private Transform wallControlTransform;




        









        [Header("Porperties")]


        [Tooltip("Assign the layer owned by the player here!")]
        [SerializeField] private LayerMask playerLayerMask;


        [Tooltip("At what distance will the enemy follow the player's character?")]
        [SerializeField] [Range(1,20)] float interactionAreaDistance = 8; 


        [Tooltip("Enter how close this character must be to the player to deal damage to the player!")]
        [SerializeField] [Range(0.08f, 4)] private double damageAreaDistance = 0.8f;


        [Space(10f)]
        [Tooltip("Enter the player's minimum distance on the y-axis to attack!")]
        [SerializeField] [Range(-3, 0.5f)] private float minYAxis;

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||
















#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||


        private float _characterCurrentSpeed;



        private bool _wall = false;          // eger karakter bir duvara takilirsa bu degisken true degerini alacak!

        private bool _isGrounded = true;    // We will find out whether the character is in contact with the ground or not with this variable!


#endregion











        private void OnCollisionStay2D(Collision2D other) 
        {
            if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                this._isGrounded = true;
            }
        }





        private void OnCollisionExit2D(Collision2D other) 
        {
            if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                this._isGrounded = false;
        }





















        protected override void CharacterMove()
        {
            if (PlayerInteractionArea() && !this._isDead)
            {
                Vector2 _localScale = WhichDirectionPlayer();
                short _velocityValue;
                
                
                if (_localScale.x < 0)
                {
                    this._characterCurrentSpeed = this.characterMoveSpeed;
                    if (!DamageArea() && !this._isDead) 
                        AnimatorController(1);

                    _velocityValue = +1;
                }
                else if (_localScale.x > 0)
                {
                    this._characterCurrentSpeed = this.characterMoveSpeed;
                    if (!DamageArea() && !this._isDead)
                        AnimatorController(1);

                    _velocityValue = -1;
                }
                else
                {
                    this._characterCurrentSpeed = 0;
                    if (!DamageArea() && !this._isDead)
                        AnimatorController(0);

                    _velocityValue = 0;
                }






                this.transform.localScale = _localScale; // It has been determined which direction this enemy should look!
                this.rb.velocity = new Vector2(_velocityValue * characterMoveSpeed, this.rb.velocity.y);
            }
            else
            {
                if (!this._isDead)
                    AnimatorController(0);
            }
        }





        /// <summary>
        /// This method will cause damage to the game!
        /// </summary>
        protected override void Damage()
        {
            if (DamageArea() && !this._isDead && !this.gameManager._playerController._isDeadProperties)
            {
                this.gameManager._cameraController._cameraIsMoveProperties = false;
                gameManager._playerController._isDeadProperties = true;
                gameManager._playerController.TakeDamage();
                this._characterCurrentSpeed = this.characterSlowMoveSpeed;
                if (!this._isDead)
                    AnimatorController(3);
            }
        }





        internal override void TakeDamage()
        {
            this.gameManager._enemyCharacters.Remove(this);
            this._isDead = true;
            this.characterCollider.excludeLayers = this.playerLayerMask;
            AnimatorController(4);
            Destroy(this.gameObject, 3);
        }



        internal void DestroyThisObject()
        {
            
        }





        private void Jump()
        {
            
            if (this._isGrounded && !this._isDead)
            {
                //Debug.Log("Is Grounded TRUE");
                this._wall = Physics2D.OverlapCapsule(this.wallControlTransform.position, new Vector2(1f, 1f), CapsuleDirection2D.Vertical, 0, groundLayerMask);
                
                if (_wall && !this._isDead)
                {
                    this.rb.velocity = new Vector2(this.rb.velocity.x, this.jumpForce);
                    Debug.Log("JUMP!");
                }
                else
                    return;
            }
        }




        internal void EnemyAICharacterController()
        {
            if (!this.gameManager._playerController._isDeadProperties)
            {
                CharacterMove();
                Damage();
                Jump();
            }
        }








        /// <summary>
        /// It is checked whether the character the player is connected to enters the interaction area!
        /// </summary>
        /// <returns>If the player's character entered the interaction area, this method returns true!</returns>
        private bool PlayerInteractionArea()
        {
            return Vector2.Distance(this.transform.position, playerCharacter.position) < this.interactionAreaDistance;
        }








        /// <summary>
        /// With this method, you will find out which direction the character is in!
        /// </summary>
        /// <returns>The character's Local scale value will be returned!</returns>
        private Vector2 WhichDirectionPlayer()
        {
            float _value;
            _value = this.transform.position.x - this.playerCharacter.position.x;


            if (_value < 0)
            {
                return new Vector2(-1.6f, +1.6f);
            }
            else
            {
                return new Vector2(+1.6f, +1.6f);
            }
        }




        /// <summary>
        /// If the enemy character comes within a certain distance of the player's character, he will be able to damage the player!
        /// </summary>
        /// <returns>If the player is close enough this method will return true!</returns>
        private bool DamageArea()
        {
            Vector2 _distance;

            _distance = new Vector2(Mathf.Abs(this.transform.position.x - this.playerCharacter.position.x), this.transform.position.y - this.playerCharacter.position.y);


            if (_distance.x <= this.damageAreaDistance)
            {
                if (_distance.y >= this.minYAxis && _distance.y <= 0.5f)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }






        /// <summary>
        /// With this method, you can easily switch between character animations.
        /// </summary>
        /// <param name="value">Enter as a parameter which animation you want to switch to!</param>
        private void AnimatorController(ushort value)
        {
            this.animator.SetInteger("playerState", value);
        }
    }
}