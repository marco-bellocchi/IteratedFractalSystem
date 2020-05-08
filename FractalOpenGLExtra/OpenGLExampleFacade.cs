using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Examples.Tutorial;

namespace FractalOpenGLExtra
{
    public class OpenGLExampleFacade
    {
        public void RunJuliaSet()
        {
            using (JuliaSetFractal example = new JuliaSetFractal())
            {
                example.Run(30.0);
            }
        }

        public void RunSierpinskiCarpet()
        {
            using (Anaglyph game = new Anaglyph())
            {
                game.Run(10.0);
            }
        }

    }
}
