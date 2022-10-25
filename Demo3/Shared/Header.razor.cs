using Microsoft.JSInterop;

namespace Demo3.Shared
{
    public partial class Header
    {
        private bool collapseNavMenu = false;
        private string currentTheme;
        private string ToolsCssClass => collapseNavMenu ? "active" : null;
        private void ToggleNavMenu() => collapseNavMenu = !collapseNavMenu;

        protected override async Task OnInitializedAsync()
        {
            currentTheme = await Common.GetStorageAsync("theme") ?? "Light";

            await Common.InvokeAsync("window.func.switchTheme");
        }

        private async Task SwitchTheme()
        {
            currentTheme = currentTheme == "Light" ? "Dark" : "Light";

            await Common.SetStorageAsync("theme", currentTheme);

            await Common.InvokeAsync("window.func.switchTheme");
        }
    }
}
