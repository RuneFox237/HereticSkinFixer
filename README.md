# Heretic Fix Extension

An Extension for King Ender Brine's RoR2 Skin Builder that fixes heretic skins as they need some special attention to make sure they work.
Uses [RoRSkinBuilderExtension](https://github.com/RuneFox237/RoRSkinBuilderExtension) so make sure you check out the tutorial on [how to use RoRSkinBuilderExtension](https://github.com/RuneFox237/RoRSkinBuilderExtension/wiki/Using-the-Skin-Builder-Extension)
You can import this extension the same as other extensions, by going to the Unity Package Manager and adding from git URL and pasting in the package link:

`https://github.com/RuneFox237/RoRSkinBuilderExtension.git`

---

### Important note about importing the Heretic Rig and Mesh into Blender after ripping:

When importing the ripped model into blender the bones are going to look weird, i.e. they're set 90 degrees off of what you'd expect.
This is fine and trying to fix it will cause your model to look all messed up in-game.

If you still want to have a standard looking armature I would suggest making a new blender project where you import the model with the automatic bone orientation turned ON. this will visually the bone orientation.
You can then make your skin. BUT when you're done making the skin you need to move the meshes to your blender project that has the weird looking armature and parent the meshes to that armature.
Now you can export that armature and meshes and it should work.
