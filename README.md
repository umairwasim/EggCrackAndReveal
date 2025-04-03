# Egg Crack And Reveal
Egg Cracking and Revealing 3D Character Animation
Unity 2022.3.60f1 LTS

# Instructions
1. Number of Taps Required for the Egg to Fully Crack and Reveal the Character
Total Taps Required: 2

On the first tap, the egg's crack intensity will increase from 0.3 to 0.6.

On the second tap, the crack intensity will increase from 0.6 to 1, fully breaking the egg and revealing the character inside.

2. Approach to the Egg Cracking Animation
Multiple Models:
The cracking effect is achieved by gradually increasing the glow intensity of the egg. The material's _ColorIntensity property changes with each click, representing the visual cracking of the egg. After the second tap, a fractured version of the egg is instantiated to simulate the cracking effect, revealing the character inside.

Animated Deformation:
Similar to the previous implementation, the cracking effect is visualized by altering the material properties (glow intensity), and two 3D models (the intact egg and the fractured version) are used to simulate the cracking process.

3. Implementation of the 3D Character Reveal
After the second tap (when the egg fully cracks), the character is revealed by spawning a 3D model (the character inside the egg). This is triggered by the second click when the glow intensity reaches 1, signaling the egg's complete breakage.

The fractured egg model is instantiated at the same time as the character reveal to create the visual effect of the egg breaking open.

4. Assumptions and Decisions Made During Development
Glow-based Cracking:
The decision to use the material's glow intensity to simulate the cracking effect remains in place. This keeps the process simple and effective while providing a smooth visual transition.

Interactivity and Feedback:
The click-counter UI provides feedback to the user, showing the number of taps left until the egg is fully cracked. This helps guide the user through the interaction process.

Character Reveal:
The character is revealed only after the second tap is made, ensuring a smooth and satisfying progression from the egg cracking to the final reward.

5. Instructions on How to Run the APK
1. Set up your Unity Project:

Ensure the Unity project is configured for the target platform (e.g., Android).

Make sure all the necessary assets (such as the egg, fractured models, and character) are added to the project.

2. Build Settings:

Go to File → Build Settings and select Android as your platform.

Click on Switch Platform to ensure the project is set up for Android.

3. Configure the Player Settings:

Go to Edit → Project Settings → Player, and configure settings like Package Name, Version Number, and Minimum API Level as required.

4. Build the APK:

Once everything is set up, click on Build or Build and Run in the Build Settings window.

Select a location to save the APK, and Unity will generate the file.

5. Install the APK on Your Device:

Transfer the generated APK to your Android device.

Enable Install from Unknown Sources in the Settings on your Android device if it’s not already enabled.

Open the APK file on your device to install and run the app.
OR
Install the APK

