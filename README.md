# unity3d api search addin for MonoDevelop
# 用于 MonoDevelop 的 unity3d api 搜索插件

Help主菜单列表中会出现两个菜单项：

- Unity API Reference(Local)
- Unity API Reference(Online)

分别对应本地文档与联机官方最新文档。

## 安装方法

复制生成的 UnityAPISearch.dll 和 UnityAPISearch.config.xml 到 MonoDevelop 安装目录下的 Addins 目录内即可。

重启 MonoDevelop 即可自动加载。

## 配置项

配置位于 UnityAPISearch.config.xml 中。
其中有三个配置项：

- 本地文档路径 LocalApiBase
- 联机文档路径 OnlineApiBase
- 搜索页面名字 SearchPage

## 参考

原始 UnityUtilities 插件源代码地址：https://github.com/Unity-Technologies/MonoDevelop.Debugger.Soft.Unity/tree/unity-staging/UnityUtilities