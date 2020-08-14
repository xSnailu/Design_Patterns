using BigTask2.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigTask2.DisplaySystems
{
    class SpecyficSystem : ISystem
    {
        IForm form;
        IDisplay display;

        public SpecyficSystem(IForm form, IDisplay display)
        {
            this.form = form;
            this.display = display;
        }

        public IForm Form => form;

        public IDisplay Display => display;
    }
}
