Dot Product
Use Case:
The dot product is used in your game to determine if a target (like a player) is within the field of view of an observer (like an enemy or a security camera). By comparing the angle between the observer's forward direction and the direction to the target, the dot product helps decide whether the observer can "see" the target.

Implementation:
In the game, I made it so two lines are drawn using the Unity Editor’s Gizmos - a red line indicating the observer’s forward direction and a green line toward the player if the player is within the observer’s field of view. This visualization helps in debugging and gameplay adjustments by visually confirming the detection logic.

Linear Interpolation (Lerp)
Use Case:
Linear interpolation is employed to smoothly move the game character to a position clicked by the mouse, enhancing the movement aesthetics and user experience.

Implementation:
In the game, I made it so when the player clicks a point in the game world (the walls), the character's position interpolates towards this point, resulting in smooth and visually pleasing movement. This is particularly evident in transitioning between points, avoiding abrupt jumps or snaps. However, this implementation was a little hard for me so it doesnt look the best haha

Particle Effect
Use Case:
Particles are used to create a visual effect that follows the character but stops emitting when the character is moving. This can indicate magic, power, or other in-game elements tied to the character's state.

Implementation:
In the game, I made it so that the particle system is attached to the character and programmed to emit particles when the character is stationary. This adds a dynamic visual cue that helps convey the state of the character to the player.

Sound Effect
Use Case:
A humming sound effect plays when the character is not moving, creating an auditory signal that enhances the ambient feel of the game or indicates a state change like powering down.

Implementation:
In game, an erie AudioSource on the character plays a looping humming sound when the character is stationary. This sound stops when the character starts moving, providing audio feedback aligned with the visual and interactive elements. Kinda makes it seem spooky to stay still.
