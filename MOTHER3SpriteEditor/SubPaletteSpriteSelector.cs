using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOTHER3SpriteEditor
{
    class SubPaletteSpriteSelector : System.Windows.Forms.ComboBox
    {
        public Sprite sprite;

        public SubPaletteSpriteSelector() : base()
        {
        }

        public void setSprite(Sprite sprite)
        {
            this.sprite = sprite;
            if (sprite.Pal.palBank != 0)
            {
                this.Items.Clear();
                this.Items.Add("Custom");
                this.SelectedIndex = 0;
                this.Enabled = false;
            }
            else
            {
                this.Items.Clear();
                String[] pals = new string[16];
                for (int i = 0; i < 16; i++)
                    pals[i] = i.ToString();
                this.Items.AddRange(pals);
                this.SelectedIndex = sprite.Pal.palSubBank;
                this.Enabled = true;
            }
        }

        public void setSpriteSubPalette()
        {
            sprite.Pal.SetPalSubBank(this.SelectedIndex);
            sprite.ComputeSubSprites();
        }
    }
}
