using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] [Min(0)] private Vector2Int _gridSize;
    [SerializeField] private Vector2 _gridShift;
    [Space] [SerializeField] private Vector2 _cellGap;
    [SerializeField] [Min(0)] private Vector2 _cellSize;
    [Space] [SerializeField] private Color _debugColor = Color.green;

    #region EDITOR

    [ContextMenu("Snap")]
    public void SnapAllObjectsByGrid()
    {
        var tiles = GetComponentsInChildren<Platform>();
        foreach (var tile in tiles)
        {
            tile.transform.position = NearestPoint(tile.transform.position, out var distance);
        }
    }


    public Vector3 NearestPoint(Vector3 point, out float minDistance)
    {
        point.z = transform.position.z;

        minDistance = float.MaxValue;
        Vector3 minVector = Vector3.zero;

        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                var vector = GetCenterOfCell(x, y);
                var distance = Vector3.Distance(point, vector);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    minVector = vector;
                }
            }
        }

        return minVector;
    }

    #endregion

    private Vector3 GetCenterOfCell(int x, int y)
    {
        var shiftX = ShiftX();
        var shiftY = ShiftY();

        var generalShift = new Vector3(
            _cellSize.x * x + _cellGap.x * x - shiftX + _gridShift.x,
            _cellSize.y * y + _cellGap.y * y - shiftY + _gridShift.y
        );

        return transform.position + generalShift;
    }

    private float ShiftX()
    {
        var gapXShift = _gridSize.x / 2 * _cellGap.x;
        if (_gridSize.x % 2 == 0)
        {
            gapXShift -= _cellGap.x / 2;
        }

        var gridXShift = _gridSize.x / 2 * _cellSize.x;
        if (_gridSize.x % 2 == 0)
        {
            gridXShift -= _cellSize.x / 2;
        }

        return gridXShift + gapXShift;
    }

    private float ShiftY()
    {
        var gapYShift = _gridSize.y / 2 * _cellGap.y;
        if (_gridSize.y % 2 == 0)
        {
            gapYShift -= _cellGap.y / 2;
        }

        var gridYShift = (_gridSize.y / 2 * _cellSize.y);
        if (_gridSize.y % 2 == 0)
        {
            gridYShift -= _cellSize.y / 2;
        }

        return gridYShift + gapYShift;
    }

    private void OnDrawGizmos()
    {
        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                var centerOfShiftedPosition = GetCenterOfCell(x, y);

                var leftUpPoint = centerOfShiftedPosition + new Vector3(-_cellSize.x / 2, _cellSize.y / 2);
                var rightUpPoint = centerOfShiftedPosition + new Vector3(_cellSize.x / 2, _cellSize.y / 2);

                var leftDownPoint = centerOfShiftedPosition + new Vector3(-_cellSize.x / 2, -_cellSize.y / 2);
                var rightDownPoint = centerOfShiftedPosition + new Vector3(_cellSize.x / 2, -_cellSize.y / 2);

                Gizmos.color = _debugColor;

                Gizmos.DrawSphere(centerOfShiftedPosition, 0.1f);

                Gizmos.DrawLine(leftUpPoint, rightUpPoint);
                Gizmos.DrawLine(leftDownPoint, rightDownPoint);

                Gizmos.DrawLine(leftUpPoint, leftDownPoint);
                Gizmos.DrawLine(rightUpPoint, rightDownPoint);
            }
        }
    }
}