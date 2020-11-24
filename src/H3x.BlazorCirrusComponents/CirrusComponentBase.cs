using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3x.BlazorCirrusComponents
{
    public abstract class CirrusComponentBase : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> UnmatchedAttributes { get; set; }

        [CascadingParameter]
        private ForwardRef Me { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (Me != null)
                Me.Current = this;
        }
    }
}
