using Microsoft.JSInterop;

namespace Demo3.Shared
{
    public partial class Header
    {
        private string currentTheme;

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
