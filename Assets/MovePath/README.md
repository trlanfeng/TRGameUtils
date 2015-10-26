# MovePath
路径生成，按路径移动工具。
本代码来源于李总，为适应项目（类似大富翁的走格系统）进行了少量修改。

### 使用说明：
1.存放路径点的父物体，添加 `com_path`
2.路径点添加 `com_pathpoint`
3.贝塞尔曲线的节点，GameObject的name的第一个字母必须为`b`，并勾选 `Bezier Control Point`
4.所有路径点必须按行走顺序在路径容器中存放
5.行走步数会去掉贝塞尔曲线点的数量，假如从第1个点到第7个点，共6步。若其中有一个点为贝塞尔曲线点，则走了5步。