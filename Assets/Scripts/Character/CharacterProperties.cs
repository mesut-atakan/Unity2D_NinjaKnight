using UnityEngine;



namespace Character
{
    internal abstract class CharacterProperties : MonoBehaviour
    {
#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        [Header("Character Properties")]

        [Tooltip("Character Move Speed")]
        [SerializeField] protected float characterMoveSpeed = 5;



        [Tooltip("Character Max Health amount")]
        [SerializeField] protected ushort _maxHealth = 100;




        




#endregion ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||










#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| Private Fields ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        protected bool _isDead = false;

#endregion


#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| PROPERTIES ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        internal bool _isDeadProperties
        {
            get { return this._isDead; }
            set { this._isDead = value; }
        }

#endregion


    
    
    
        protected abstract void CharacterMove();


        internal abstract void TakeDamage();



        protected abstract void Damage();
    }
}