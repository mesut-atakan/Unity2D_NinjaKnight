using UnityEngine;
using DG.Tweening;


internal class CameraController : MonoBehaviour
{
#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| SERIALIZE FIELDS ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||

    [Header("Transform & Objects")]

    [Tooltip("Get Player Character Transform Position")]
    [SerializeField] private Transform characterTransform;


    [Tooltip("Get Main Camera")]
    [SerializeField] private new Camera camera; 

    
    [Tooltip("Camera Move Speed")]
    [SerializeField] [Range(0.00001f, 0.01f)] private float cameraMoveSpeed;




    [Header("Shake Properties")]

    [Tooltip("Shake Duration")]
    [SerializeField] [Range(0, 5)] private float shakeDuration = 1;
    
    [Tooltip("Shake Force")]
    [SerializeField] [Range(0, 10)] private float shakeForce;
    
    

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||





#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| PRIVATE FIELDS ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||

    private bool _cameraIsMove = true;

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||







#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| PROPERTIES ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||

    internal Camera _camera
    {
        get { return this.camera; }
        set { this.camera = value; }
    }


    internal bool _cameraIsMoveProperties
    {
        set { this._cameraIsMove = value; }
    }

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||


























#region ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| FUNCTIONS ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||


    internal void CameraMove()
    {
        // If the camera does not allow movement, this method will not work!
        if (!this._cameraIsMove)
            return;

        // ~~ Variables ~~
        Vector3 _targetPos = new Vector3(this.characterTransform.position.x, this.characterTransform.position.y, this.transform.position.z);
        
        this.transform.position = Vector3.Lerp(this.transform.position, _targetPos, cameraMoveSpeed);

    }




    /// <summary>
    /// You can give the camera a shake effect with this method!
    /// </summary>
    internal void CameraShake()
    {
        this.camera.DOShakePosition(this.shakeDuration, shakeForce, fadeOut: true);
    }

#endregion ||~~~~~~~~~~~~||X||~~~~~~~~~~~~|| XXXX ||~~~~~~~~~~~~||X||~~~~~~~~~~~~||
}