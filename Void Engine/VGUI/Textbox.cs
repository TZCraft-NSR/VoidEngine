using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VoidEngine.VGame;

namespace VoidEngine.VGUI
{
	/// <summary>
	/// The Scrollbar class for VoidEngine
	/// </summary>
    public class Textbox : Sprite
    {
        Game myGame;

        /// <summary>
        /// Creates the Scrollbar
        /// </summary>
        /// <param name="position">The position of the sprite</param>
        /// <param name="animationSetList">The list of animation sets</param>
        /// <param name="myGame">The class of the game that this is created in</param>
        public Textbox(Vector2 position, Color color, List<AnimationSet> animationSetList, Game myGame)
            : base(position, color, animationSetList)
        {
            Color = color;
            this.myGame = myGame;
            AnimationSets = animationSetList;
            this.position = position;
        }
    }
}