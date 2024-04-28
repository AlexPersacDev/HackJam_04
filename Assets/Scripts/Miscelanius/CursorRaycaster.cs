using System;
using UnityEngine;
using DG.Tweening;

public class CursorRaycaster : MonoBehaviour
{
    [SerializeField] private Camera currentCamera;
    [SerializeField] private float maxDistance;
    [SerializeField] private Texture2D maxCursor;
    [SerializeField] private Texture2D startCursor;
    private bool interacting;
    private Vector2 mousePoint;
    

    private void Start ()
    {
        Cursor.SetCursor(startCursor, Vector3.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        Raycast();
    }

    private void Raycast ()
    {
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        
        //Ray ray = new Ray(mousePoint, transform.forward);
        bool raycasting = Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance);

        if (!raycasting)
        {
            interacting = false;
            //ChangeScale();
            return;
        }
        
        interacting = hitInfo.transform.gameObject.TryGetComponent<IInteractuable>(out IInteractuable interact);
        
        if(interacting)
        {
            if(Input.GetMouseButtonDown(0))
            {
                interact.Interact();
            }
        }
        //ChangeScale();
    }

    private void ChangeScale ()
    {
        Texture2D targetCursor = interacting ? maxCursor : startCursor;
        
        Cursor.SetCursor(targetCursor,Vector3.zero, CursorMode.ForceSoftware);
    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Ray ray =currentCamera.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(ray);
    }
}
