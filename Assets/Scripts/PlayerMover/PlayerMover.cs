using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private UIController _controllerUI;
    [SerializeField] private LineRenderer _lineRenders;

    private List<Vector3> _targetPositions = new List<Vector3>();

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Move(Camera.main.ScreenPointToRay(touch.position).origin);
            }

        }
        if (Input.GetButtonDown("Fire1"))
        {
            Move(Camera.main.ScreenPointToRay(Input.mousePosition).origin);
        }
    }

    private void Move(Vector3 positionMove)
    {
        _targetPositions.Add(positionMove);
        _lineRenders.positionCount++;
        _lineRenders.SetPosition(_lineRenders.positionCount - 1, _targetPositions[_targetPositions.Count - 1]);
    }

    private void FixedUpdate()
    {
        if (_targetPositions.Count == 0) return;
        transform.position = Vector3.MoveTowards(transform.position, _targetPositions[0], _controllerUI.Spead);
        if (transform.position == _targetPositions[0])
        {
            _targetPositions.RemoveAt(0);
        }
    }
}
