﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AntDesign
{
    public partial class Icon : AntDomComponentBase
    {
        [Parameter]
        public bool Spin { get; set; }

        [Parameter]
        public int Rotate { get; set; } = 0;

        [Parameter]
        public string Type { get; set; }

        /// <summary>
        /// 'fill' | 'outline' | 'twotone';
        /// </summary>
        [Parameter]
        public string Theme { get; set; } = IconThemeType.Outline;

        [Parameter]
        public string TwotoneColor { get; set; }

        [Parameter]
        public string IconFont { get; set; }

        [Parameter]
        public string Width { get; set; } = "1em";

        [Parameter]
        public string Height { get; set; } = "1em";

        [Parameter]
        public string Fill { get; set; } = "currentColor";

        [Parameter]
        public string TabIndex { get; set; }

        [CascadingParameter]
        public Button Button { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Inject]
        public IconService IconService { get; set; }

        [Parameter]
        public RenderFragment Component { get; set; }

        protected string _svgImg;

        protected override async Task OnInitializedAsync()
        {
            if (Type == "loading")
            {
                Spin = true;
            }

            await SetupSvgImg();

            if (this is Icon icon)
            {
                Button?.Icons.Add(icon);
            }

            ClassMapper.Add("anticon anticon-sync");

            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            await SetupSvgImg();
            await base.OnParametersSetAsync();
        }

        protected virtual async Task SetupSvgImg()
        {
            if (Component != null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(IconFont))
            {
                var svg = $"<svg><use xlink:href=#{IconFont} /></svg>";
                _svgImg = IconService.GetStyledSvg(svg, Width, Height, Fill, Rotate, Spin);
            }
            else
            {
                var svg = await IconService.GetIconImg(Type.ToLowerInvariant(), Theme.ToLowerInvariant());
                _svgImg = IconService.GetStyledSvg(svg, Width, Height, Fill, Rotate, Spin);
            }

            StateHasChanged();
        }

        private async Task HandleOnClick(MouseEventArgs args)
        {
            if (OnClick.HasDelegate)
            {
                await OnClick.InvokeAsync(args);
            }
        }
    }
}
