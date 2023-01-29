using Microsoft.JSInterop;

namespace Demo3.Shared
{
    public partial class Header
    {
        private string themeColor = "background-color:#121212;color:#a9a9b3";
        private string currentTheme = "Light";

        protected override async Task OnInitializedAsync()
        {
            currentTheme = await Common.GetStorageAsync("theme") ?? "Light";
            if (currentTheme == "Dark")
            {
                themeColor = "background-color:#121212;color:#a9a9b3";
            }
            else
            {
                themeColor = "";
            }
            await Common.InvokeAsync("window.func.switchTheme");
        }

        private async Task SwitchTheme()
        {
            currentTheme = currentTheme == "Light" ? "Dark" : "Light";
            if (currentTheme == "Dark")
            {
                themeColor = "background-color:#121212;color:#a9a9b3";
            }
            else
            {
                themeColor = "";
            }

            await Common.SetStorageAsync("theme", currentTheme);

            await Common.InvokeAsync("window.func.switchTheme");
        }
    }
}
