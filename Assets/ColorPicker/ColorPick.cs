using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace TRGameUtils
{
	public class ColorPick : MonoBehaviour
	{
		public Color useColor = Color.white;
		public Transform PickPanel;
		Transform m;//彩度亮度设置面板
		Color hColor = Color.white;//色度值
		Slider sc;
		Transform pointer;
		Image pointerColor;
		Image pointerCenterColor;
		void Start()
		{
			initPicker();
		}
		private void initPicker()
		{
			if (PickPanel == null) PickPanel = this.transform;
			sc = PickPanel.Find("mc/SliderSC").GetComponent<Slider>();
			m = PickPanel.Find("m/Quad");
			pointer = PickPanel.Find("m/Pointer");
			pointerColor = pointer.GetComponent<Image>();
			pointerCenterColor = pointer.Find("Image").GetComponent<Image>();
			var rC = PickPanel.Find("m/ColorPick").GetComponent<RawImage>();
			Texture2D picktex;
			picktex = new Texture2D(2, 2, TextureFormat.ARGB32, false, false);
			//picktex.filterMode = FilterMode.Point;
			picktex.wrapMode = TextureWrapMode.Clamp;
			rC.texture = picktex;
			picktex.SetPixel(0, 0, Color.black);
			picktex.SetPixel(0, 1, Color.white);
			picktex.SetPixel(1, 0, Color.black);
			picktex.SetPixel(1, 1, hColor);
			picktex.Apply();
			var rC2 = PickPanel.Find("mc/ColorPick").GetComponent<RawImage>();
			Texture2D pickColor;
			pickColor = new Texture2D(2, 7, TextureFormat.ARGB32, false, true);
			pickColor.wrapMode = TextureWrapMode.Repeat;
			pickColor.SetPixel(0, 0, new Color(1, 0, 0));
			pickColor.SetPixel(0, 1, new Color(1, 1, 0));
			pickColor.SetPixel(0, 2, new Color(0, 1, 0));
			pickColor.SetPixel(0, 3, new Color(0, 1, 1));
			pickColor.SetPixel(0, 4, new Color(0, 0, 1));
			pickColor.SetPixel(0, 5, new Color(1, 0, 1));
			pickColor.SetPixel(0, 6, new Color(1, 0, 0));
			pickColor.SetPixel(1, 0, new Color(1, 0, 0));
			pickColor.SetPixel(1, 1, new Color(1, 1, 0));
			pickColor.SetPixel(1, 2, new Color(0, 1, 0));
			pickColor.SetPixel(1, 3, new Color(0, 1, 1));
			pickColor.SetPixel(1, 4, new Color(0, 0, 1));
			pickColor.SetPixel(1, 5, new Color(1, 0, 1));
			pickColor.SetPixel(1, 6, new Color(1, 0, 0));
			pickColor.Apply();
			rC2.texture = pickColor;
			//rC.color = useColor;
			{
				var ssC = sc;
				UnityAction<float> onSCChange = (v) =>
				{
					if (v < 1.0f)
					{
						hColor.r = 1;
						hColor.g = Mathf.Lerp(0, 1, v);
						hColor.b = 0;

					}
					else if (v < 2.0f)
					{
						hColor.r = Mathf.Lerp(1, 0, v - 1);
						hColor.g = 1;
						hColor.b = 0;
					}
					else if (v < 3.0f)
					{
						hColor.r = 0;
						hColor.g = 1;
						hColor.b = Mathf.Lerp(0, 1, v - 2);
					}
					else if (v < 4.0f)
					{
						hColor.r = 0;
						hColor.g = Mathf.Lerp(1, 0, v - 3);
						hColor.b = 1;
					}
					else if (v < 5.0f)
					{
						hColor.r = Mathf.Lerp(0, 1, v - 4);
						hColor.g = 0;
						hColor.b = 1;
					}
					else if (v < 6.0f)
					{
						hColor.r = 1;
						hColor.g = 0;
						hColor.b = Mathf.Lerp(1, 0, v - 5);
					}
					picktex.SetPixel(1, 1, hColor);
					picktex.Apply();
				};
				ssC.onValueChanged.AddListener(onSCChange);
			}
		}
		void Update()
		{
			if (Input.GetMouseButton(0))
			{
				RaycastHit hit;
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					Debug.Log("hit.point:::" + hit.point);
					if (hit.collider.gameObject.transform == m) //选色
					{
						//四边形插值
						float vx = hit.textureCoord.x;
						Color hc = Color.white * (1 - vx) + hColor * vx;
						float vy = hit.textureCoord.y;
						useColor = Color.black * (1 - vy) + hc * vy;

						pointer.transform.position = hit.point;
						pointerCenterColor.color = useColor;
						if (useColor.r < 0.5f && useColor.g < 0.5f && useColor.b < 0.5f)
						{
							pointerColor.color = new Color(1, 1, 1);
						}
						else
						{
							pointerColor.color = new Color(0, 0, 0);
						}
					}
				}
			}
		}
	}

}
