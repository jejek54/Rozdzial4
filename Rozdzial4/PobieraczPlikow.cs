using System;
using System.Collections.Generic;
using System.Text;

namespace Rozdzial4
{
    class PobieraczPlikow
    {

        public delegate void PobieranieOkDelegat();
        public event PobieranieOkDelegat PobieranieEventHandler;

        public delegate void PobieranieBladDelegat();
        public event PobieranieBladDelegat PobieranieBladEventHandler;

        private int _doPobrania;
        public int doPobrania
        {
            get
            {
                return _doPobrania;
            }
            set
            {
                if (_doPobrania == 4)
                {
                    if (PobieranieEventHandler != null)
                    {
                        PobieranieEventHandler();
                    }
                }
                else
                {
                    if (PobieranieBladEventHandler != null)
                    {
                        PobieranieBladEventHandler();
                    }
                }
                _doPobrania = value;
            }
        }
        
        public void PoszloOk()
        {
            if (PobieranieEventHandler != null) PobieranieEventHandler();

        }

        public PobieraczPlikow(int n)
        {
            this.doPobrania = n;
        }


    }
}
