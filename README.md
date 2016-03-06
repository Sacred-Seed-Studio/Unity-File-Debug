# Unity-File-Debug
Enhanced debug logging for Unity, with JSON export and HTML viewer

## Why
This project has a few goals
- Output Unity debug info to log files
- Have a nice interface to view the logs
  - No external dependencies
  - HTML5
  - Searchable via message, stacktrace, timestamp, logtype
  - Filterable by logtype

## How to use
1. Import the [latest release's package](https://github.com/Sacred-Seed-Studio/Unity-File-Debug/releases) into your project
2. Move the prefab into your scene
3. Setup the filepath and settings in the prefab instance inspector
4. Copy the HTML to your output path via inspector
5. Use `Debug.Log` as normal, or for more advanced usage see Tester script in `Demo` folder
6. Open the HTML file from your log folder, open a JSON log in the top left
