# Unity-File-Debug
![Unity Version][unity-badge]&nbsp;
[![Platform][platform-badge]][repo]&nbsp;
[![GitHub license][license-badge]][license]&nbsp;
[![GitHub release][version-badge]][releases]&nbsp;
[![GitHub issues][issues-badge]][issues]&nbsp;
[![Pull Requests][pr-badge]][pulls]&nbsp;

Enhanced debug logging for Unity, with file export and HTML viewer. 
- [Read the blog post](http://www.sacredseedstudio.com/blog/2016/06/05/Output-the-Unity-console-to-file)
- [See the demo](http://www.sacredseedstudio.com/Unity-File-Debug/)
- [Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/unity-file-debug-72250)

## Why
- Output Unity debug info to log files (csv, tsv, json, txt)
- A nice web interface to view the log files (csv, tsv, json)
  - HTML5 (single file)
  - No external dependencies
  - Searchable via message, stacktrace, timestamp, logtype
  - Filterable by logtype
- Be able to drop it into existing projects

## How to use
1. Import the [latest release's package](https://github.com/Sacred-Seed-Studio/Unity-File-Debug/releases) into your project
2. Move the prefab `Unity File Debug` into your scene
3. Setup the filepath and settings in the inspector
4. Copy the HTML to your output path via inspector button
5. Use `Debug.Log` as normal, or for more advanced usage see [Tester](/Assets/UnityFileDebug/Demo/Tester.cs) script in `Demo` folder
6. Open the `UnityFileDebugViewer.html` file from your log folder, browse for a log file from the top left

If you don't specify an absolute filepath, Application.persistentDataPath will be used.

HTML viewer is designed for modern browsers (chrome/firefox)

## Developing
- Fork/clone this repository
- Open in Unity
- Hack away

## How to Customize
### Custom log types
1. Change DLogType enumeration in [DebugWrapper.cs](/Assets/UnityFileDebug/Lib/Logger/Scripts/DebugWrapper.cs)
2. Update `topLogTypes` and `nestedLogTypes` arrays in [UnityFileDebugViewer.html](/Assets/UnityFileDebug/Lib/Viewer/UnityFileDebugViewer.html)
3. Update `LogTypeColors` css in [UnityFileDebugViewer.html](/Assets/UnityFileDebug/Lib/Viewer/UnityFileDebugViewer.html)
4. Update svg icons in [UnityFileDebugViewer.html](/Assets/UnityFileDebug/Lib/Viewer/UnityFileDebugViewer.html)

### No nesting in viewer
1. Move all elements from `nestedLogTypes` array to `topLogTypes` in [UnityFileDebugViewer.html](/Assets/UnityFileDebug/Lib/Viewer/UnityFileDebugViewer.cs)

### Using other log sources
The viewer supports a few different file formats

##### JSON format:
```js
{
  t: '', // type
  tm: '', // time
  l: '', // log message
  s: '', // log stack trace
}
```

##### CSV header:
`type,time,log,stack`

##### TSV header:
`type	time	log	stack`

---

## Release
In the Unity Editor, click the menu option `SSS/Util/Package/Unity File Debug`. The `UnityFileDebug.unitypackage` will be in the root of this project.

<!--
Badge References
-->
[version-badge]:https://img.shields.io/github/release/Sacred-Seed-Studio/Unity-File-Debug.svg
[platform-badge]:https://img.shields.io/badge/platform-All-blue.svg
[issues-badge]:https://img.shields.io/github/issues/Sacred-Seed-Studio/Unity-File-Debug.svg
[license-badge]:https://img.shields.io/github/license/Sacred-Seed-Studio/Unity-File-Debug.svg
[unity-badge]:https://img.shields.io/badge/Unity-5.4+-blue.svg
[pr-badge]:https://img.shields.io/github/issues-pr/Sacred-Seed-Studio/Unity-File-Debug.svg

<!--
URL References
-->
[releases]:https://github.com/Sacred-Seed-Studio/Unity-File-Debug/releases
[repo]:https://github.com/Sacred-Seed-Studio/Unity-File-Debug
[issues]:https://github.com/Sacred-Seed-Studio/Unity-File-Debug/issues
[license]:https://github.com/Sacred-Seed-Studio/Unity-File-Debug/blob/master/LICENSE
[pulls]:https://github.com/Sacred-Seed-Studio/Unity-File-Debug/pulls
