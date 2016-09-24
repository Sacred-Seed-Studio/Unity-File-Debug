# Unity-File-Debug
Enhanced debug logging for Unity, with JSON export and HTML viewer. [Read the blog post](http://www.sacredseedstudio.com/blog/2016/06/05/Output-the-Unity-console-to-file). [See the demo](http://www.sacredseedstudio.com/Unity-File-Debug/).

## Why
This project has a few goals:
- Output Unity debug info to log files
- A nice web interface to view the logs
  - HTML5
  - No external dependencies
  - Searchable via message, stacktrace, timestamp, logtype
  - Filterable by logtype
- Be able to drop it into existing projects

## How to use
1. Import the [latest release's package](https://github.com/Sacred-Seed-Studio/Unity-File-Debug/releases) into your project
2. Move the prefab `Unity File Debug` into your scene
3. Setup the filepath and settings in the inspector
4. Copy the HTML to your output path via inspector button
5. Use `Debug.Log` as normal, or for more advanced usage see Tester script in `Demo` folder
6. Open the `index.html` file from your log folder, browse for a `*.json` log in the top left

## Developing
- Fork/clone this repository
- Open in Unity
- Hack away

## Release
In the Unity Editor, click the menu option `Package/Update Package`. The `UnityFileDebug.unitypackage` will be in the root of this project.
