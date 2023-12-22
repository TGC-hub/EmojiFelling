using UnityEngine;

public class CameraController : MyMonoBehavior
{
    private static CameraController instance;
    public static CameraController Instance => instance;

    [SerializeField] protected Camera mainCamera;
    [SerializeField] protected Camera cameraZoom;
    [SerializeField] protected Camera cameraFollowEvent;
    [SerializeField] protected Camera cameraStart;

    public Camera currentCamera { get; private set; }

    private bool onActiveCameraStart = true;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMainCamera();
        LoadCameraZoom();
        LoadCameraFollowEvent();
        LoadCameraStart();
    }



    protected virtual void LoadCameraStart()
    {
        if (cameraStart != null) return;
        cameraStart = GameObject.FindGameObjectWithTag("CameraStart").GetComponent<Camera>();
    }
    protected virtual void LoadCameraFollowEvent()
    {
        if (cameraFollowEvent != null) return;
        cameraFollowEvent = GameObject.FindGameObjectWithTag("CameraFollowEvent").GetComponent<Camera>();
    }
    protected virtual void LoadMainCamera()
    {
        if (mainCamera != null) return;
        mainCamera = Camera.main;
    }

    protected virtual void LoadCameraZoom()
    {
        if(cameraZoom != null) return;
        cameraZoom = GameObject.FindGameObjectWithTag("CameraZoom").GetComponent<Camera>();
    }

    protected override void Start()
    {
        base.Start();
        cameraZoom.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);
        cameraFollowEvent.gameObject.SetActive(false);
        cameraStart.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(onActiveCameraStart == false) 
        {
            SetCamera();
            SetCurrentCamera();
        }
        else
        {
            SetCameraWhenStart();
        }
    }

    protected virtual void SetCameraWhenStart()
    {
        if (PlaneCtrl.Instance.PlaneIntro.StartGame == false)
        {
            onActiveCameraStart = false;
            cameraStart.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }
    }

    protected virtual void SetCurrentCamera()
    {
        if (cameraFollowEvent.isActiveAndEnabled == true) 
        {
            currentCamera = cameraFollowEvent;
        }else if(cameraZoom.isActiveAndEnabled == true) 
        {
            currentCamera = cameraZoom;
        }
        else
        {
            currentCamera = mainCamera;
        }
    }

    protected virtual void SetCamera()
    {
        if (transform.GetComponent<CameraFollowEvent>().FollowEvent == true) OnEnableCameraFollowEvent();
        else
        {
            InputManager.Instance.lockInput = false;
            if (InputManager.Instance.EnableZoom == true)
            {
                OnEnableCameraZoom();
            }
            else
            {
                OnDisableCameraZoom();
            }
        }

    }

    protected virtual void OnEnableCameraZoom()
    {
        mainCamera.gameObject.SetActive(false);
        cameraZoom.gameObject.SetActive(true);
        cameraFollowEvent.gameObject.SetActive(false);
    }
    protected virtual void OnDisableCameraZoom()
    {
        cameraZoom.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        cameraFollowEvent.gameObject.SetActive(false);
    }

    protected virtual void OnEnableCameraFollowEvent()
    {
        cameraZoom.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);
        cameraFollowEvent.gameObject.SetActive(true);
        InputManager.Instance.lockInput = true;
    }
}
