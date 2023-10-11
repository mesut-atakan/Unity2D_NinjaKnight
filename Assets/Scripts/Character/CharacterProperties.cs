using UnityEngine;



namespace Character
{
    internal abstract class CharacterProperties : MonoBehaviour
    {
#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        [Header("Character Properties")]

        [Tooltip("Character Move Speed")]
        [SerializeField] protected float characterMoveSpeed = 5;



#endregion ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||










#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| Private Fields ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        protected bool _isDead = false;

#endregion ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||








#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| PROPERTIES ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||

        internal bool _isDeadProperties
        {
            get { return this._isDead; }
            set { this._isDead = value; }
        }

#endregion ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||










    
#region ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| ABSTRACT FUNCTIONS ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||
    
        protected abstract void CharacterMove();


        internal abstract void TakeDamage();



        protected abstract void Damage();
#endregion ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~~|| X ||~~~~~~~~~~~~~||
    }
}