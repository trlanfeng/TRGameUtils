//对2D相机位置进行修正，防止超出显示范围

using UnityEngine;

public class Camera2DFix : MonoBehaviour
{

    public float cameraMinX;
    public float cameraMaxX;
    public float cameraMinY;
    public float cameraMaxY;

    //针对Tile类型地图的行和列进行计算最小和最大位置
    public int row;
    public int column;

    void caclCameraPosition()
    {
        float gridSize = Screen.height / (Camera.main.orthographicSize * 2f);
        float showColumn = Screen.width / gridSize;
        cameraMinX = showColumn / 2f - 0.5f;
        cameraMaxX = column - (showColumn / 2f) - 0.5f;
        cameraMinY = Camera.main.orthographicSize - 0.5f;
        cameraMaxY = row - Camera.main.orthographicSize - 0.5f;
    }

    void fixCameraPosition()
    {
        Vector3 pos = transform.position;
        if (pos.y > cameraMaxY)
        {
            pos.y = cameraMaxY;
        }
        else if (pos.y < cameraMinY)
        {
            pos.y = cameraMinY;
        }
        if (pos.x < cameraMinX)
        {
            pos.x = cameraMinX;
        }
        else if (pos.x > cameraMaxX)
        {
            pos.x = cameraMaxX;
        }
        Camera.main.transform.position = pos;
    }
}
