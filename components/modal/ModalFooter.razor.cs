﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AntDesign
{
    public partial class ModalFooter
    {
        [CascadingParameter]
        public DialogOptions ModalProps { get; set; }

        private async Task HandleCancel(MouseEventArgs e)
        {
            var onCancel = ModalProps.OnCancel;
            if (onCancel.HasDelegate)
            {
                await onCancel.InvokeAsync(e);
            }
        }

        private async Task HandleOk(MouseEventArgs e)
        {
            var onOk = ModalProps.OnOk;
            if (onOk.HasDelegate)
            {
                await onOk.InvokeAsync(e);
            }
        }
    }
}
