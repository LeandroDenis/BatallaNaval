using System.Collections.Generic;

namespace BE
{
    public class Juego
    {
        public List<Usuario> Jugadores { get; set; }

        public Juego()
        {
            Jugadores = new List<Usuario>();
        }
    }
}
