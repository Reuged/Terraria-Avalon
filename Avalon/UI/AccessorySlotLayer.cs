﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using TAPI;
using Microsoft.Xna.Framework;

namespace Avalon.UI
{
    /// <summary>
    /// The <see cref="InterfaceLayer" /> that contains the accessory slots.
    /// </summary>
    public sealed class AccessorySlotLayer : InterfaceLayer
    {
        /// <summary>
        /// Gets the <see cref="AccessorySlotLayer" /> instance.
        /// </summary>
        public static AccessorySlotLayer Instance
        {
            get;
            internal set;
        }

        /// <summary>
        /// A wrapper class, used to protect the underlying <see cref="Item" /> array.
        /// </summary>
        public sealed class Items
        {
            // ha. ha. ha.
            internal Items() { }

            /// <summary>
            /// Gets the content of the item slot at the given index.
            /// </summary>
            /// <param name="index">The zero-based index of the item slot.</param>
            /// <returns>The content of the item slot.</returns>
            public Item this[int index]
            {
                get
                {
                    return MWorld.localAccessories[index];
                }
                set
                {
                    MWorld.localAccessories[index] = value;
                }
            }
        }
        /// <summary>
        /// Gets the item slot content.
        /// </summary>
        public static Items Slots
        {
            get;
            private set;
        }

        ExtraAccessorySlot[] slots = new ExtraAccessorySlot[Mod.ExtraSlots];
        Item[] items = new Item[Mod.ExtraSlots];

        internal AccessorySlotLayer()
            : base("Avalon:AccessorySlotLayer")
        {
            Instance = this;

            for (int i = 0; i < slots.Length; i++)
                slots[i] = new ExtraAccessorySlot(i);

            Slots = new Items();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        protected override void OnDraw(SpriteBatch sb)
        {
            float
                x = Main.screenWidth - 139f,
                y = 364f;

            for (int i = 0; i < slots.Length; i++)
                slots[i].UpdateAndDraw(sb, new Vector2(x - i / 3 * 48f, y + (i % 3) * 48f));
        }
    }
}