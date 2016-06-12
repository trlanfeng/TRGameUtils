#TRGameUtils（TR游戏工具包）

本项目用于共享使用Unity3D开发游戏时，经常需要使用的包与组件。

基于MIT协议开源。

## 项目内容：

BlinkIt （闪烁效果）

> BlinkSprite : 支持Sprite、UI Image、UI Text三个组件的闪烁效果。

> BlinkUIImage : 支持Sprite、UI Image、UI Text三个组件的闪烁效果。

> BlinkUIText : 支持Sprite、UI Image、UI Text三个组件的闪烁效果。

Camera2D （2D摄像机）

> Camera2D : 用于Unity中开发2D游戏时的屏幕适应

> Camera2DFix : 相机范围限制，防止显示超出边界，主要用于Tile类地图

Charactor （角色控制类）

> Move8Direction : 8方向移动控制

ColorPicker（调色板）

> 用于从调色板中选择一个颜色

FlyText （飘字效果）

> 用于受到伤害时，飘出伤害的具体数值

JoyStick（摇杆）

> 用于游戏中的摇杆操作

MovePath （贝塞尔曲线路径生成工具）

> 用于生成一个贝塞尔曲线的路径（注：本代码来源于李总，为适应项目（类似大富翁的走格系统）进行了少量修改。）

MyJson （JSON处理辅助）

> 用于在C#中处理JSON

ScreenView （视图导航框架）

> 使用导航的方式进行界面设计

Sprite （Sprite辅助处理）

> SpriteBox : 获取Sprite像素大小，方便2D类型计算，而不使用3D的Unit单位来计算

> SpriteFrames : 序列帧动画辅助脚本，可选首帧是否静态，存储多个动画状态用于调用

TRAnimation（Sprite动画系统）

> 用于类似RPG Maker的行走图切图