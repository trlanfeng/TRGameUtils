using UnityEngine;
using UnityEngine.EventSystems;

namespace TRGameUtils
{
	public class JoyStick : MonoBehaviour
	{

		private TouchState touchState = TouchState.None;

		public enum TouchState
		{
			None,
			OnTouch,
			End
		}

		void Start()
		{
			touchState = TouchState.None;
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0) && !isOnUI())
			{
				touchState = TouchState.OnTouch;
				startPos = Input.mousePosition;
			}
			if (Input.GetMouseButtonUp(0) && !isOnUI())
			{
				touchState = TouchState.End;
			}
			switch (touchState)
			{
			case TouchState.None:
				break;
			case TouchState.OnTouch:
				TouchMove();
				break;
			case TouchState.End:
				pointer.position = Vector3.zero;
				touchState = TouchState.None;
				break;
			}
		}
		/// <summary>
		/// 判断是否点击在UI上，这里需要 using UnityEngine.EventSystems
		/// </summary>
		/// <returns><c>true</c>, 点击在UI上 <c>false</c> 没有点在UI上.</returns>
		bool isOnUI()
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		Vector2 startPos;												//记录点击屏幕时的位置
		public Transform pointer;										//小圆点
		//摇杆移动
		void TouchMove()
		{
			Vector2 offset = (Vector2)Input.mousePosition - startPos;	//获取鼠标点击后的偏移距离
			Vector3 np = (Vector3)offset * 0.01f;						//转化为Vector3，乘以0.02f是因为屏幕坐标和世界坐标的比例
			if (np.sqrMagnitude > 1f) {								//如果距离超出1.5f，则限制到边界
				np = np.normalized;								//最大为1.5f
			}
			pointer.transform.position = np;							//小圆点的位置
		}
	}

}