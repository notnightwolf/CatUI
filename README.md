# CatUI
A Button API for ChilloutVR made by пıɢнтшσʟғ#2058
![CatUI](https://user-images.githubusercontent.com/89876523/189545014-30e53fef-913a-4f7b-9894-153d1712f2e9.jpg)
Looks like this at the beginning:
![CatUI2](https://user-images.githubusercontent.com/89876523/189545130-e8a429a6-f380-4f48-b040-2bda137f96ad.jpg)
Buttons:
- simple click button
- toggle button
- menu button
 
Sliders:
- coming soon...

Instructions:
1. Download these Folders: https://github.com/nwightwolf/CatUI/tree/main/CatUI + https://github.com/nwightwolf/CatUI/tree/main/Utils (includes cs files)
and put them into your project.
2. Download this Folder: https://github.com/nwightwolf/CatUI/releases/download/1.0/CatUI.zip (includes textures)
and put it into your cvr directory.
3. Create your mod and do it like here: https://github.com/nwightwolf/CatUI/blob/main/CatUI.cs
- Patch must be made that GameObject CatUIMain.CatUIPanel shows up at the same time as the quickmenu does on ApplicationStart.
- start IEnumerator InitializeCatUI() on ApplicationStart.
4. Scroll down in CatUIMain.cs and add your buttons in CatUIMenu() (there are 3 button examples)
5. Create your button textures and change the image paths for all of your buttons.

You should keep blankbtn.png as sprite in CatUIToggleButton.cs otherwise the green indicator outline will not be displayed correctly.
Build your DLL :)
